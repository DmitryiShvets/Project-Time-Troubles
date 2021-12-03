using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthSystemEnemy : MonoBehaviour
{
    public static HealthSystemEnemy instance;
    public int hp;
    public GameObject particleEffect;
    public GameObject HitPointDamage;
    public bool start;
    public bool start2;
    public bool move;
    void Start()
    {
        instance = this;
    }

    public void Damage(int damage)
    {

        start2 = true;

        hp -= damage;

        GameObject go = Instantiate(HitPointDamage, transform.position, transform.rotation);
        go.transform.GetChild(0).GetComponent<TMP_Text>().text = damage.ToString();

        Invoke("ResetBool", 0.2f);




    }
    void Update()
    {
       


        if (hp<=0)
        {
            hp = 0;

            if(!start)
            {
                start = true;
                
                Instantiate(particleEffect, transform.position, transform.rotation);
            }

            Destroy(gameObject);
        }


    }

    


    private void ResetBool()
    {
        start2 = false;
        start = false;
    }
}
