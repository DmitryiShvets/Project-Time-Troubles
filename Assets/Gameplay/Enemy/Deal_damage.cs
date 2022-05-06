using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Gameplay
{
    public class Deal_damage : MonoBehaviour
    {
        private int damage = 1;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.name == "PlayerCollider")
            {
                other.GetComponentInParent<PlayerController>().TakeDamage(damage);
                Debug.Log(other.gameObject.name);
            }
        }
    }

}

