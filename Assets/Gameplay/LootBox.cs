using Gameplay;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Core
{
    public class LootBox : MonoBehaviour
    {
        private bool canUse = false;
        [HideInInspector] public bool isUsed;
        private SpriteRenderer _renderer;
        public Sprite notLooted;
        public Sprite looted;
        public GameObject loot;
        private Vector3 _spawnPos;

        private void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
            _spawnPos = GetComponentInChildren<SpawnPoint>().transform.position;
        }


        void Update()
        {
            if (!isUsed)
            {
                if (canUse && Keyboard.current.eKey.wasPressedThisFrame)
                {
                    Debug.Log("Сундук открыт");
                    ChangeState();
                }
            }
        }

        private void ChangeState()
        {
            isUsed = true;
            Check();
            GameObject obj = PrefabUtility.InstantiatePrefab(loot) as GameObject;
            if (obj != null) obj.transform.position = _spawnPos;
        }

        public void Check()
        {
            _renderer.sprite = isUsed ? looted : notLooted;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.name == "PlayerCollider")
            {
                canUse = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.name == "PlayerCollider")
            {
                canUse = false;
            }
        }
    }
}