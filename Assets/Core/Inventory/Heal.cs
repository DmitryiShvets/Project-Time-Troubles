using Core.GameData.Storage;
using Gameplay;
using UnityEngine;

namespace Core
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(CircleCollider2D))]
    public class Heal : MonoBehaviour
    {
        public int count = 1;
        private SaveableGameObject state;
        private PlayerController _controller;

        private void Awake()
        {
            state = GetComponent<SaveableGameObject>();
        }

        void Reset()
        {
            GetComponent<CircleCollider2D>().isTrigger = true;
        }

        public void OnTriggerEnter2D(Collider2D collider)
        {
            Player.AddHealth(this, count);
            _controller=collider.gameObject.GetComponentInParent<PlayerController>();
            _controller.healthBar.SetHealth(Player.GetHealth);
            MessageBar.Show($"You healed: + {count} hp");
            UserInterfaceAudio.OnCollect();
            state.isActive = false;
            gameObject.SetActive(false);
        }
    }
}