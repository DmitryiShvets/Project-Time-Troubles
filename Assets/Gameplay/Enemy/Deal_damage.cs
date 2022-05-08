using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Gameplay
{
    public class Deal_damage : MonoBehaviour
    {
        private int damage = 1;

        // private void OnTriggerEnter2D(Collider2D other)
        // {
        //     if (other.name == "PlayerCollider")
        //     {
        //         other.GetComponentInParent<PlayerController>().TakeDamage(damage);
        //         Debug.Log(other.gameObject.name);
        //     }
        // }
        //
        public void OnCollisionEnter2D(Collision2D collision)
        {
           
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
                Debug.Log(collision.gameObject.name);
            }
          
        }
    }

}

