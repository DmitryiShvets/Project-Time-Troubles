using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using Core.GameData.Storage;
using Gameplay;
using UnityEngine;
using TMPro;
using UnityEditor;
using ScriptableObjects;
using UnityEngine.UIElements;

public class HealthSystemEnemy : MonoBehaviour
{
//    public static HealthSystemEnemy instance;
    public int hp;
    public GameObject particleEffect;
    public GameObject HitPointDamage;
    public GameObject pref;
    private GameModel model = Schedule.GetModel<GameModel>();
    public bool start;

    // public bool start2;
    // public bool move;
    private Vector3 _position;

    //  public AliveState aliveState;
    private SaveableGameObject state;

    private void Awake()
    {
        state = GetComponent<SaveableGameObject>();
    }

    void Start()
    {
        _position = transform.localPosition;
        //   _transform.position = gameObject.transform.position;
        //    instance = this;
        // if (!aliveState.isAlive) Destroy(gameObject);
    }

    public void Damage(int damage)
    {
        //  start2 = true;
        if (model.HasItem("Sword") || Game.GetActualScene() == "home")
        {
            hp -= damage;

            GameObject go = Instantiate(HitPointDamage, transform.position, transform.rotation);
            go.transform.GetChild(0).GetComponent<TMP_Text>().text = damage.ToString();

            Invoke("ResetBool", 0.2f);
        }
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

            //  Destroy();
            gameObject.SetActive(false);
            state.isActive = false;
            Bank.AddCoins(this, 100);
            GameObject o = Instantiate(pref);
            //GameObject obh = PrefabUtility.InstantiatePrefab(pref) as GameObject;
            o.transform.position = _position;
        }
    }

   

    private void ResetBool()
    {
        //    start2 = false;
        start = false;
    }
}