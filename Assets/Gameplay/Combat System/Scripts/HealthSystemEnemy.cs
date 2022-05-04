using System.Collections;
using System.Collections.Generic;
using Gameplay;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.UIElements;

public class HealthSystemEnemy : MonoBehaviour
{
    public static HealthSystemEnemy instance;
    public int hp;
    public GameObject particleEffect;
    public GameObject HitPointDamage;
    public GameObject pref;
    public bool start;
    public bool start2;
    public bool move;
    private Vector3 _position;

    void Start()
    {
        _position = transform.localPosition;
        //   _transform.position = gameObject.transform.position;
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
        if (hp <= 0)
        {
            hp = 0;

            if (!start)
            {
                start = true;

                Instantiate(particleEffect, transform.position, transform.rotation);
            }

            Destroy();
        }
    }

    private void Destroy()
    {
        if (gameObject)
        {
            Bank.AddCoins(this, 100);
            GameObject obh = PrefabUtility.InstantiatePrefab(pref) as GameObject;
            obh.transform.position = _position;
            Destroy(gameObject);
        }
    }

    private void ResetBool()
    {
        start2 = false;
        start = false;
    }
}