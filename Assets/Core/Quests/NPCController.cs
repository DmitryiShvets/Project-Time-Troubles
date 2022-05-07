using System.Collections.Generic;
using System.Linq;
using Core.Events;
using UnityEngine;

namespace Core
{
    /// <summary>
    /// Main class for implementing NPC game objects.
    /// </summary>
    public class NPCController : MonoBehaviour
    {
        //Лист диалогов у нпс которые будут отрисовываться 
        public List<ConversationScript> conversationList;

        Quest activeQuest = null;

        //Массив квестов у нпс которые
        public Quest[] quests;

        GameModel model = Schedule.GetModel<GameModel>();

        void OnEnable()
        {
            quests = gameObject.GetComponentsInChildren<Quest>();
            Check();
        }
        //Проверка завершенных квестов если квест у нпс завершен то из списка диалогов удаляется диалог начинающий этот квест
        public void Check()
        {
            foreach (var q in quests)
            {
                if (q.isFinished)
                {
                    conversationList.Remove(conversationList.First());
                }
            }
        }

        //При попадании игрока в коллайдер происходит вызов ивента "Показать диалог"
        public void OnCollisionEnter2D(Collision2D collision)
        {
            var c = GetConversation();
            if (c != null)
            {
                Debug.Log("QUEST GIVER!");

                var ev = Schedule.Add<ShowConversation>();
                ev.conversation = c; //Текущий диалог
                ev.npc = this; // У кого взят квест
                ev.gameObject = gameObject; // У кого взят квест
                ev.conversationItemKey = "";
            }
        }

        //При завершении квеста удалить квестовые предметы из инвентаря и дать награду игроку
        public void CompleteQuest(Quest q)
        {
            if (activeQuest != q) throw new System.Exception("Completed quest is not the active quest.");
            foreach (var i in activeQuest.requiredItems)
            {
                model.RemoveInventoryItem(i.item, i.count);
            }

            activeQuest.RewardItemsToPlayer();
            activeQuest.OnFinishQuest();
            activeQuest = null;
        }

        public void StartQuest(Quest q)
        {
            if (activeQuest != null) throw new System.Exception("Only one quest should be active.");
            activeQuest = q;
        }

        //Возвращает диалог который будет отрисовываться на экране 
        ConversationScript GetConversation()
        {
            //Если аквтивных ксестов нету то возвращается первый диалог в списке диалогов нпс
            if (activeQuest == null)
                return conversationList.Count > 0 ? conversationList[0] : null;
            foreach (var q in quests)
            {
                if (q == activeQuest)
                {
                    if (q.IsQuestComplete())
                    {
                        CompleteQuest(q);
                        //Когда текущий квест у нпс завершается то удаляется диалог который выдает этот квест
                        conversationList.Remove(conversationList.First());

                        return q.questCompletedConversation;
                    }

                    return q.questInProgressConversation;
                }
            }

            return null;
        }
    }
}