using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{

    [SerializeField]
    private int damage;
    bool inZone;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {

            collision.GetComponent<HealthSystemEnemy>().Damage(damage);
            Destroy(gameObject);
            
        }
        else
        {
           
        }
       
    }

    private void Update()
    {
        Destroy(gameObject, 0.2f);
    }
}
