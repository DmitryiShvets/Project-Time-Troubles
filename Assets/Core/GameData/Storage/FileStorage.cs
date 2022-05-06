using System;
using System.Collections;
using System.IO;
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

        public override void Save()
        {
            var root = new XElement("root");
            root.Add(_dictSurrogate.Serialize(model.inventory));
            root.Add(_dictSurrogate.Serialize(model.inventorySprites));
            root.Add(_npcSurrogate.Serialize(model.npsList));
            var data = new XDocument(root);
            File.WriteAllText(filePath, data.ToString());
        }

        #endregion


        #region LOAD

        public override void Load()
        {
            if (File.Exists(filePath))
            {
                var data = File.ReadAllText(filePath);
                var inventory = _dictSurrogate.DeserializeItems(data);
                var inventorySprites = _dictSurrogate.DeserializeSprite(data);
                var npc = _npcSurrogate.DeserializeItems(data);
                model.inventory = inventory;
                model.inventorySprites = inventorySprites;
                model.inventoryController.Refresh();
                model.InitializeNpc(npc);
            }
        }

        #endregion
    }
}