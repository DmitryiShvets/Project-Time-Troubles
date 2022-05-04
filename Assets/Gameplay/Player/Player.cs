using System;
using Core;
using UnityEngine;

namespace Gameplay
{
    public static class Player
    {
        private static PlayerHealthInteractor _healthInteractor;
        public static bool isInitialized { get; private set; }
        
        public static void Initialize(PlayerHealthInteractor healthInteractor)
        {
            _healthInteractor = healthInteractor;
            isInitialized = true;
            
        }
        
        public static int GetHealth
        {
            get
            {
                CheckState();
                return _healthInteractor.GetHealth;
            }
            
        }
        
        public static void AddHealth(object sender, int value)
        {
            CheckState();
            _healthInteractor.AddHealth(sender, value);
            Debug.Log($"Player health increased by {value} - now {GetHealth}");
        }

        public static void DecreaseHealth(object sender, int value)
        {
            CheckState();
            _healthInteractor.DecreaseHealth(sender, value);
            Debug.Log($"Player health decreased by {value} - now {GetHealth}");
        }
        private static void CheckState()
        {
            if (!isInitialized) throw new Exception("PlayerHealthInteractor is not valid");
        }
    }
}