using System;
using Core.GameData.Storage;
using UnityEngine;


namespace Core
{
    /// <summary>
    /// Marks a gameObject as a collectable item.
    /// </summary>
    [ExecuteInEditMode]
    [RequireComponent(typeof(SpriteRenderer), typeof(CircleCollider2D))]
    public class InventoryItem : MonoBehaviour
    {
        public int count = 1;
        public Sprite sprite;
        private SaveableGameObject state;
        GameModel model = Schedule.GetModel<GameModel>();

        private void Awake()
        {
            state = GetComponent<SaveableGameObject>();
        }

        void Reset()
        {
            GetComponent<CircleCollider2D>().isTrigger = true;
        }

        void OnEnable()
        {
            GetComponent<SpriteRenderer>().sprite = sprite;
        }

        public void OnTriggerEnter2D(Collider2D collider)
        {
            MessageBar.Show($"You collected: {name} x {count}");
            model.AddInventoryItem(this);
            UserInterfaceAudio.OnCollect();
            state.isActive = false;
            gameObject.SetActive(false);
        }
    }
}