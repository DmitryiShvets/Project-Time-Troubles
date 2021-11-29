using System;
using UnityEditor;
using UnityEngine.PlayerLoop;
using Core;
using UnityEngine;

namespace Gameplay
{
    public static class Bank
    {
        private static BankInteractor _bankInteractor;
        public static int GetCoins
        {
            get
            {
                CheckState();
                return _bankInteractor.GetCoins;
            }
        }

        public static bool isInitialized { get; private set; }

        public static void Initialize(BankInteractor bankInteractor)
        {
            _bankInteractor = bankInteractor;
            isInitialized = true;
            
        }

        public static void AddCoins(object sender, int value)
        {
            CheckState();
            _bankInteractor.AddCoins(sender, value);
        }

        public static void SpendCoins(object sender, int value)
        {
            CheckState();
            _bankInteractor.SpendCoins(sender, value);
        }

        private static void CheckState()
        {
            if (!isInitialized) throw new Exception("BankInteractor is not valid");
        }
    }
}