using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deal_damage : MonoBehaviour
{
    private float damage = 0.25f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "PlayerCollider")
        {
            other.GetComponentInParent<Hp>().TakeDamage(damage);
            Debug.Log(other.gameObject.name);
        }
    }
}

