using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using StorageSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gameplay
{
    public class PlayerController : MonoBehaviour
    {
        public HealthBar healthBar;

        private void Start()
        {
            StartCoroutine(InitHP());
        }

        IEnumerator InitHP()
        {
            yield return new WaitForSeconds(0.001f);
            healthBar.SetHealth(Player.GetHealth);
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
            Game.PlayerDie();
        }
    }
}