using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gameplay
{
    public class PlayerController : MonoBehaviour
    {
        public HealthBar healthBar;

        private void Start()
        {
            healthBar.SetMaxHealth(5);
        }
        public void TakeDamage(int damage)
        {
            if (!Player.isInitialized)
            {
                Debug.Log($"PlayerInteractor is not valid");
                return;
            }

            Player.DecreaseHealth(this, damage);
            if (Player.GetHealth <= 0)
            {
                Die();
            }

            healthBar.SetHealth(Player.GetHealth);
        }

        private void Die()
        {
            Game.LoadScene("Menu");
            //SceneManager.LoadScene(0);
        }
    }
}