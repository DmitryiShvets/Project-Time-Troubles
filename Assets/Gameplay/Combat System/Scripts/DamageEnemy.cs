using System;
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
     
        if (collision.CompareTag("Loot"))
        {

            collision.GetComponent<BreakObject>().Damage(damage);
            Destroy(gameObject);

        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {

            collision.gameObject.GetComponent<HealthSystemEnemy>().Damage(damage);
            Destroy(gameObject);
            
        }
     
        if (collision.gameObject.CompareTag("Loot"))
        {

            collision.gameObject.GetComponent<BreakObject>().Damage(damage);
            Destroy(gameObject);

        }
    }

    
    

    private void Update()
    {
        Destroy(gameObject, 0.2f);
    }
}
