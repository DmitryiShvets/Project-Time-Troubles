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


        #region SAVE

        public override void Save(string sceneName)
        {
            var root = new XElement("root");
            root.Add(_dictSurrogate.Serialize(model.inventory));
            root.Add(_dictSurrogate.Serialize(model.inventorySprites));

            root.Add(_npcSurrogate.Serialize(Game.GetActualScene(), model.npsList));
            var scenes = GetAllScenesNpc(Game.GetActualScene());
            if (scenes.Any())
            {
                foreach (var x in scenes)
                {
                    root.Add(x);
                }
            }

            root.Add(_gameStateSurrogate.Serialize(Game.GetActualScene()));
            var data = new XDocument(root);
            File.WriteAllText(filePath, data.ToString());
            Debug.Log(_gameStateSurrogate.Serialize(Game.GetLastScene()).ToString());
        }

        #endregion


        #region LOAD

        public override void Load(string sceneName)
        {
            if (File.Exists(filePath))
            {
                var data = File.ReadAllText(filePath);
                var inventory = _dictSurrogate.DeserializeItems(data);
                var inventorySprites = _dictSurrogate.DeserializeSprite(data);
                var npc = _npcSurrogate.DeserializeItems(Game.GetActualScene(), data);
                var lastScene = _gameStateSurrogate.DeserializeItems(data);
                model.inventory = inventory;
                model.inventorySprites = inventorySprites;
                if (Game.GetActualScene() != "Menu") model.inventoryController.Refresh();
                model.InitializeNpc(npc);
                model.InitializeLastScene(lastScene);
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