using UnityEngine;

namespace Core
{
    public class BankRepository : Repository
    {
        private const string KEY = "BANK_KEY";

        public int Coins { get; set; }


        public override void OnInitialize()
        {
            Debug.Log($"BankRepository - Initialize ");
            Coins = PlayerPrefs.GetInt(KEY, 0);
        }

        public override void Save()
        {
            PlayerPrefs.SetInt(KEY, Coins);
        }
    }
}