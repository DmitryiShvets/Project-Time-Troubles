using System;
using System.Collections;
using Core;
using UnityEngine;

namespace Gameplay
{
    public class BankComponent : MonoBehaviour
    {

        // Start is called before the first frame update
        void Start()
        {
           Game.Run();  

        }


        public IEnumerator StartGame()
        {
            yield return null;
            if (Bank.isInitialized) Debug.Log($"Bank initialize - now {Bank.GetCoins}");
        }

        // Update is called once per frame
        public void Add()
        {
            if (!Bank.isInitialized)
            {
                Debug.Log($"BankInteractor is not valid");
                return;
            }

            Bank.AddCoins(this, 10);
            Debug.Log($"10 coins add - now {Bank.GetCoins}");
        }

        public void Spend()
        {
            if (!Bank.isInitialized)
            {
                Debug.Log($"BankInteractor is not valid");
                return;
            }

            Bank.SpendCoins(this, 5);
            Debug.Log($"5 coins remove - now {Bank.GetCoins}");
        }
    }
}