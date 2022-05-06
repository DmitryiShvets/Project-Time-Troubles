using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Core.Events
{
    /// <summary>
    /// This event will start a conversation with an NPC using a conversation script.
    /// </summary>
    /// <typeparam name="ShowConversation"></typeparam>
    public class ShowConversation : Event<ShowConversation>
    {
        public NPCController npc; //
        public GameObject gameObject; //Ссылка на игровой обькт вызвавший это событие
        public ConversationScript conversation; //скрипт который мы передали при вызове ивента
        public string conversationItemKey; //id диалога который нужно отрисовать

        public override void Execute()
        {
            ConversationPiece ci;
            //По умолчанию показывается первый диалог у нпс если ключ пустой иначе находится уже показанный диалог
            if (string.IsNullOrEmpty(conversationItemKey))
                ci = conversation.items[0]; //Текущие диалоги у нпс
            else
                ci = conversation.Get(conversationItemKey);


           
            //Если у диалога есть квест то обрабатываем это 
            // если этот квест еще не начат то вызываем ивент StartQuest
            // если этот квест уже завершен то присваиваем диалогу первый диалог при завершении квеста
            if (ci.quest != null)
            {
                if (!ci.quest.isStarted)
                {
                    var ev = Schedule.Add<StartQuest>(1); //Добавление квеста в очередь
                    ev.quest = ci.quest;
                    ev.npc = npc;
                }
                if (ci.quest.isFinished && ci.quest.questCompletedConversation != null)
                {
                    ci = ci.quest.questCompletedConversation.items[0];
                    
                }
            }

            //вычисляем позицию возле игрока где рисовать диалог
            var position = gameObject.transform.position;
            var sr = gameObject.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                position += new Vector3(0, 2 * sr.size.y + (ci.options.Count == 0 ? 0.1f : 0.2f), 0);
            }

            //отрисовываем текст
            model.dialog.Show(position, ci.text);
            var animator = gameObject.GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetBool("Talk", true);
                var ev = Schedule.Add<StopTalking>(2);
                ev.animator = animator;
            }

            if (ci.audio != null)
            {
                UserInterfaceAudio.PlayClip(ci.audio);
            }

            //speak some gibberish at two speech syllables per word.
            UserInterfaceAudio.Speak(gameObject.GetInstanceID(), ci.text.Split(' ').Length * 2, 1);

            //если у диалога есть id то регистрируем его в моделе
            if (!string.IsNullOrEmpty(ci.id))
                model.RegisterConversation(gameObject, ci.id);

            //отрисовывает кнопки диалога (ответы персонажа)
            if (ci.options.Count == 0)
            {
                //ни делаем ничего
            }
            else
            {
                //Создает кнопку отвеса чу чуть ниже диалога
                for (var i = 0; i < ci.options.Count; i++)
                {
                    model.dialog.SetButton(i, ci.options[i].text);
                }

                //устанавливем каллбек когда игрок нажал на кнопку (выбрал вариант ответа)
                model.dialog.onButton += (index) =>
                {
                    //скрываем текст
                    model.dialog.Hide();

                    //получаем id следующего диалога который нужно отрисовать.
                    var next = ci.options[index].targetId;

                    //проверка что этот диалог существуюет!
                    if (conversation.ContainsKey(next))
                    {
                        //вызывает новый ивент ShowConversation что бы отрисовать следующий диалог
                        var c = conversation.Get(next);
                        var ev = Schedule.Add<ShowConversation>(0.25f);
                        ev.conversation = conversation;
                        ev.gameObject = gameObject;
                        ev.conversationItemKey = next;
                    }
                    else
                    {
                        Debug.LogError($"No conversation with ID:{next}");
                    }
                };

            }

            //если у диалога есть иконка отрисовываем её
            model.dialog.SetIcon(ci.image);
        }

    }
}