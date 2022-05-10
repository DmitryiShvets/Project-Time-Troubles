using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Core
{
    /// <summary>
    /// This class implements quests.
    /// </summary>
    public class Quest : MonoBehaviour
    {
        public enum SpawnMode
        {
            CloneAndEnable,
            CloneOnly
        }

        [System.Serializable]
        public class ItemRequirement
        {
            public InventoryItem item;
            public int count = 1;
        }
        
        public string title;
        public string desc;
        public RQInfo requirementQuest;
        public ConversationScript questInProgressConversation, questCompletedConversation;

        public SpawnMode spawnMode = SpawnMode.CloneAndEnable;
        bool disableItemsOnStart = true;

        //Массив игровых объектов которые становятся активными при старте квеста
        public GameObject[] enableOnQuestStart;
        public GameObject[] spawnOnQuestStart;
        public ItemRequirement[] requiredItems;
        public GameObject[] spawnOnQuestComplete;
        public InventoryItem[] rewardItems;

        public bool destroySpawnsOnQuestComplete = true;

        //Лист предметов которые будут удалены после завершения квеста
        List<GameObject> destroyItemsList = new List<GameObject>();

        public bool isStarted = false;
        public bool isFinished = false;

        GameModel model = Schedule.GetModel<GameModel>();

        void Awake()
        {
           model.inventory.Clear();
            //(Если требуется) убедиться что предметы которые должны быть активными для квеста - неактивные
            if (disableItemsOnStart)
            {
                
                if (enableOnQuestStart != null)
                    foreach (var i in enableOnQuestStart)
                        if (i != null)
                            i.SetActive(false);

                switch (spawnMode)
                {
                    case SpawnMode.CloneAndEnable:
                        foreach (var i in spawnOnQuestStart)
                        {
                            i.SetActive(false);
                        }
                        break;
                }
            }
        }

        //При старте квеста спавнятся либо активируются квестовые предметы 
        public void OnStartQuest()
        {
            isFinished = false;
            // if (introCutscenePrefab != null)
            // {
            //     var cs = Instantiate(introCutscenePrefab);
            //     if (cs.audioClip != null)
            //     {
            //         cs.OnFinish += (i) => model.musicController.CrossFade(model.musicController.audioClip);
            //     }
            // }
            
            //Сделать активными предметы которые должны быть активными для выполнения задания
            if (enableOnQuestStart != null)
                foreach (var i in enableOnQuestStart)
                    if (i != null)
                        i.SetActive(true);
            switch (spawnMode)
            {
                case SpawnMode.CloneAndEnable:
                    foreach (var i in spawnOnQuestStart)
                    {
                        var clone = GameObject.Instantiate(i);
                        clone.SetActive(true);
                        if (destroySpawnsOnQuestComplete) destroyItemsList.Add(clone);
                    }
                    break;
                case SpawnMode.CloneOnly:
                    foreach (var i in spawnOnQuestStart)
                    {
                        var clone = GameObject.Instantiate(i);
                        if (destroySpawnsOnQuestComplete) destroyItemsList.Add(clone);
                    }
                    break;
            }

        }

        //Проверка хватает ли квестовых предметов в инвентаре для сдачи квеста
        public bool IsQuestComplete()
        {
            var inv = new HashSet<string>(model.InventoryItems);
            foreach (var i in requiredItems)
            {
                if (inv.Contains(i.item.name) && model.GetInventoryCount(i.item.name) >= i.count) continue;
                return false;
            }
            return true;
        }
        //Выдача предметов за квест в инвентарь игрока
        public void RewardItemsToPlayer()
        {
            foreach (var i in rewardItems)
            {
                MessageBar.Show($"You collected: {i.name} x {i.count}");
                model.AddInventoryItem(i);
                UserInterfaceAudio.OnCollect();
                i.gameObject.SetActive(false);
            }
            // if (outroCutscenePrefab != null)
            // {
            //     var cs = Instantiate(outroCutscenePrefab);
            //     if (cs.audioClip != null)
            //     {
            //         cs.OnFinish += (i) => model.musicController.CrossFade(model.musicController.audioClip);
            //     }
            // }

        }
        //При завершении квеста происходит удаление квестовых предметов и спавн новых предметов 
        public void OnFinishQuest()
        {
            if (destroySpawnsOnQuestComplete)
            {
                foreach (var item in destroyItemsList)
                {
                    if (item != null) Destroy(item);
                }
            }

            foreach (var item in spawnOnQuestComplete)
            {
                var clone = GameObject.Instantiate(item);
                clone.SetActive(true);
            }
            isFinished = true;
        }

    }
}