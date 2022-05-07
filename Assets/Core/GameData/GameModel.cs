using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Core.GameData.Storage;
using ScriptableObjects;
using UnityEngine;

namespace Core
{
    /// <summary>
    /// This class provides all the data you need to control and change gameplay.
    /// </summary>
    [Serializable]
    public class GameModel
    {
        //public CharacterController2D player;
        public DialogController dialog;
        public InputController input;
        public InventoryController inventoryController;
        public MusicController musicController;
        public List<NPCController> npsList;

        public DataStorage _dataStorage;

        public IsometricPlayerMovementController _PlayerMovement;
        public List<SaveableGameObject> saveableGameObjects;
        private static ActualSceneState _scriptableObject;
        private static PositionState _positionState;

        Dictionary<GameObject, HashSet<string>> conversations = new Dictionary<GameObject, HashSet<string>>();
        public Dictionary<string, int> inventory = new Dictionary<string, int>();
        public Dictionary<string, Sprite> inventorySprites = new Dictionary<string, Sprite>();

        HashSet<string> storyItems = new HashSet<string>();

        public IEnumerable<string> InventoryItems => inventory.Keys;

        public void InitializeNpc(Dictionary<string, Dictionary<string, bool>> map)
        {
            foreach (var npc in npsList)
            {
                if (map.ContainsKey(npc.name))
                {
                    foreach (var quest in npc.quests)
                    {
                        quest.isFinished = map[npc.name][quest.name];
                    }
                }

                npc.Check();
            }
        }

        public void InitializeGameObj(Dictionary<string, bool> objects)
        {
            if (objects.Any())
            {
                foreach (var obj in saveableGameObjects)
                {
                    obj.isActive = objects[obj.name];
                    obj.Check();
                }
            }
        }

        public void Save(string sceneName)
        {
            _dataStorage.Save(sceneName);
        }

        public void InitializeLastScene(string lastScene)
        {
            _scriptableObject = Resources.Load<ActualSceneState>("LastScene");
            _scriptableObject.lastScene = lastScene;
        }

        public void InitializeLastPosition(Vector3 pos)
        {
            _positionState = Resources.Load<PositionState>("PositonState");
            if (pos != Vector3.zero)
            {
                _positionState.pos = pos;
                _PlayerMovement.Init();
            }
        }

        public Sprite GetInventorySprite(string name)
        {
            Sprite s;
            inventorySprites.TryGetValue(name, out s);
            return s;
        }

        public int GetInventoryCount(string name)
        {
            int c;
            inventory.TryGetValue(name, out c);
            return c;
        }

        //Добавляет только предмет по ссылке
        public void AddInventoryItem(InventoryItem item)
        {
            int c = 0;
            inventory.TryGetValue(item.name, out c);
            c += item.count;
            inventorySprites[item.name] = item.sprite;
            inventory[item.name] = c;
            inventoryController.Refresh();
        }

        //Добавляет любой предмет
        public void AddInventoryItem(string name, int count, Sprite icon)
        {
            int c = 0;
            inventory.TryGetValue(name, out c);
            c += count;
            inventorySprites[name] = icon;
            inventory[name] = c;
            inventoryController.Refresh();
        }

        public bool HasInventoryItem(string name, int count = 1)
        {
            int c = 0;
            inventory.TryGetValue(name, out c);
            return c >= count;
        }

        public bool RemoveInventoryItem(InventoryItem item, int count)
        {
            int c = 0;
            inventory.TryGetValue(item.name, out c);
            c -= count;
            if (c < 0) return false;
            inventory[item.name] = c;
            inventoryController.Refresh();
            return true;
        }

        public void RegisterStoryItem(string ID)
        {
            storyItems.Add(ID);
        }

        public bool HasSeenStoryItem(string ID)
        {
            return storyItems.Contains(ID);
        }

        public void RegisterConversation(GameObject owner, string id)
        {
            if (!conversations.TryGetValue(owner, out HashSet<string> ids))
                conversations[owner] = ids = new HashSet<string>();
            ids.Add(id);
        }

        public bool HasHadConversationWith(GameObject owner, string id)
        {
            if (!conversations.TryGetValue(owner, out HashSet<string> ids))
                return false;
            return ids.Contains(id);
        }

        public bool HasMet(GameObject owner)
        {
            return conversations.ContainsKey(owner);
        }
    }
}