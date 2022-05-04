using UnityEngine;

namespace Core
{
    public class PlayerHealthRepository : Repository
    {
        private const string KEY = "PLAYER_HEALTH_KEY";

        public int Health { get; set; }


        public override void OnInitialize()
        {
            //  Health = PlayerPrefs.GetInt(KEY, 5); //Пока не инициализируем из памяти для тестов
            Health = 5;
            Debug.Log($"PlayerHealthRepository - Initialize. Current hp - {Health}");
        }

        public override void Save()
        {
            PlayerPrefs.SetInt(KEY, Health);
        }
    }
}