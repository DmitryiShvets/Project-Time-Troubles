using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using StorageSystem;
using UnityEngine.InputSystem;

namespace Core
{
    public class DataStorage : MonoBehaviour
    {
        private string _storageFileName = Game.SaveFile;

        private bool _savingComplete;
        private FileStorage _storage;

        public bool IsCompleteQuest(string sceneName, string npc, string quest)
        {
            return _storage.IsCompleteQuest(sceneName, npc, quest);
        }

        private void Start()
        {
            _storage = new FileStorage(_storageFileName);

            Debug.Log(_storage.filePath);
            _storage.Load(Game.GetActualScene());
        }

        public void Save(string sceneName)
        {
            _storage.Save(sceneName);
        }
    }
}