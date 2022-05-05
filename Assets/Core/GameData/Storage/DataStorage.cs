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
        [SerializeField] private string _storageFileName = "save.xml";

        private bool _savingComplete;
        private FileStorage _storage;


        private void Start()
        {
            _storage = new FileStorage(_storageFileName);
            Debug.Log(_storage.filePath);
            _storage.Load();
        }

        private void Update()
        {
            if (Keyboard.current.pKey.wasPressedThisFrame)
            {
                _storage.Save();
            }
        }
    }
}