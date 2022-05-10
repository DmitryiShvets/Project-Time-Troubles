using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Xml.Linq;
using Core;
using UnityEngine;
using Tools;

namespace StorageSystem
{
    public sealed class FileStorage : Storage
    {
        public string filePath { get; }


        GameModel model = Schedule.GetModel<GameModel>();

        public FileStorage(string fileName)
        {
            var folder = "Saves";
            var folderPath = $"{Application.persistentDataPath}/{folder}";
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            filePath = $"{folderPath}/{fileName}";
        }

        public bool IsCompleteQuest(string sceneName, string npc, string quest)
        {
            if (File.Exists(filePath))
            {
                var data = File.ReadAllText(filePath);
                return _npcSurrogate.IsCompleteQuest(sceneName, npc, quest, data);
            }
            else
            {
                return false;
            }
        }

        #region SAVE

        public override void Save(string sceneName)
        {
            var root = new XElement("root");
            root.Add(_dictSurrogate.Serialize(model.inventory)); //сохранение предметов в инвентаре
            root.Add(_dictSurrogate.Serialize(model.inventorySprites)); //сохранение иконок предметов в инвентаре

            XElement sceneXElement = new XElement(Game.GetActualScene()); //сохранение всех квестов на текущей локации
            sceneXElement.Add(_npcSurrogate.Serialize(model.npsList));
            sceneXElement.Add(_gameStateSurrogate.SerializationPlayerLocation(Game.GetPlayerPosition()));
            sceneXElement.Add(_gameObjectSurrogate.SerializeGameObj(model.saveableGameObjects));
            sceneXElement.Add(_lootBoxesSurrogate.SerializeLootBoxObj(model.saveableLootBoxes));
            root.Add(sceneXElement);

            var scenes = GetAllScenesNpc(Game.GetActualScene()); //сохранение всех квестов на других локациях
            if (scenes != null && scenes.Any())
            {
                foreach (var x in scenes)
                {
                    root.Add(x);
                }
            }

            //сохранение последней посещенной локации
            XElement gameStateElement = new XElement("game-state");
            gameStateElement.Add(_gameStateSurrogate.SerializeLastScene(Game.GetActualScene()));

            root.Add(gameStateElement);
            var data = new XDocument(root);
            File.WriteAllText(filePath, data.ToString());
            Debug.Log(_gameStateSurrogate.SerializeLastScene(Game.GetLastScene()).ToString());
        }

        #endregion


        #region LOAD

        public override void Load(string sceneName)
        {
            if (File.Exists(filePath))
            {
                var data = File.ReadAllText(filePath);
                var inventory = _dictSurrogate.DeserializeItems(data); //загрузка предметов в инвентаре
                var inventorySprites = _dictSurrogate.DeserializeSprite(data); //загрузка иконок предметов в инвентаре
                var npc = _npcSurrogate.DeserializeItems(Game.GetActualScene(),
                    data); //загрузка всех квестов на текущей локации
                var lastScene = _gameStateSurrogate.DeserializeLastScene(data); //загрузка последней посещенной локации
                var playerPos =
                    _gameStateSurrogate.DeserializePlayerLocation(Game.GetActualScene(),
                        data); //загрузка последней посещенной локации
                var gameObjects = _gameObjectSurrogate.DeserializeGameObj(Game.GetActualScene(), data);
                var lootBoxes = _lootBoxesSurrogate.DeserializeLootBoxObj(Game.GetActualScene(), data);
                model.inventory = inventory;
                model.inventorySprites = inventorySprites;
                if (Game.GetActualScene() != "Menu")
                    model.inventoryController.Refresh(); //проверка что мы сейчас не на локации меню
                if (Game.GetActualScene() != "Menu") model.InitializeNpc(npc);
                model.InitializeLastScene(lastScene);
                if (Game.GetActualScene() != "Menu") model.InitializeLastPosition(playerPos);
                if (Game.GetActualScene() != "Menu") model.InitializeGameObj(gameObjects);
                if (Game.GetActualScene() != "Menu") model.InitializeLootBoxObj(lootBoxes);
            }
        }

        private List<XElement> GetAllScenesNpc(string sceneName)
        {
            if (!File.Exists(filePath)) return null;
            var data = File.ReadAllText(filePath);
            return _gameStateSurrogate.DeserializeScenes(sceneName, data);
        }

        #endregion
    }
}