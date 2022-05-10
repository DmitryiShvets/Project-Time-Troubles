using System;
using System.Collections;
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
        private List<ConversationScript> _conversationList = new List<ConversationScript>();

        Quest activeQuest = null;

        //Массив квестов которые у нпс
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
                    for (int i = 0; i < conversationList.Count(); i++)
                    {
                        if (q.name == conversationList[i].GetQuest())
                        {
                            Debug.Log(q.name);
                            conversationList.Remove(conversationList[i]);
                        }
                    }
                }
            }
        }


        private void CheckQuest()
        {
            foreach (var q in quests)
            {
                if (q.requirementQuest != null)
                {
                    bool xxx = model.IsCompleteQuest(q.requirementQuest.sceneName, q.requirementQuest.npcName,
                        q.requirementQuest.questName);

                    if ((!xxx && (q.requirementQuest.quest != null &&
                                  !q.requirementQuest.quest.isFinished)) || !xxx)
                    {
                        for (int i = 0; i < conversationList.Count(); i++)
                        {
                            if (q.name == conversationList[i].GetQuest())
                            {
                                Debug.Log(q.name);
                                _conversationList.Add(conversationList[i]);
                                conversationList.Remove(conversationList[i]);
                            }
                        }
                    }
                    else
                    {
                        bool exist = false;
                        for (int i = 0; i < conversationList.Count(); i++)
                        {
                            if (q.name == conversationList[i].GetQuest())
                            {
                                exist = true;
                            }
                        }

                        if (!exist)
                        {
                            foreach (var x in _conversationList)
                            {
                                if (q.name == x.GetQuest())
                                {
                                    conversationList.Insert(0, x);
                                }
                            }
                        }
                    }
                }
            }
        }


        //При попадании игрока в коллайдер происходит вызов ивента "Показать диалог"
        public void OnCollisionEnter2D(Collision2D collision)
        {
            CheckQuest();
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