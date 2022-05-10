using System;
using System.Collections;
using UnityEngine;

namespace Core
{
    public class PortalFinishGame : MonoBehaviour
    {
        private SpriteRenderer _renderer;
        public Sprite notLocked;
        public Sprite locked;
        private GameModel model = Schedule.GetModel<GameModel>();
        private bool gameFinished = false;

        private void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            StartCoroutine(Delay());
        }

        IEnumerator Delay()
        {
            yield return new WaitForSeconds(1);
            if (model.HasItem("Scroll")) gameFinished = true;
            Check();
        }

        public void Check()
        {
            _renderer.sprite = gameFinished ? notLocked : locked;
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            if (gameFinished)
            {
                Debug.Log("GAME finish");
                Game.LoadSceneSave("Finish");
            }
        }
    }
}