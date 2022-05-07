using System;
using UnityEngine;

namespace Core.GameData.Storage
{
    public class SaveableGameObject : MonoBehaviour
    {
        public bool isActive = true;

        private void Start()
        {
            if (!isActive) gameObject.SetActive(false);
        }

        public void Check()
        {
            if (!isActive) gameObject.SetActive(false);
        }
    }
}