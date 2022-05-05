using System;
using UnityEngine;
using UnityEngine.Serialization;
using Core;
using Gameplay;
using UnityEditor;

public class Enemy : MonoBehaviour
{
    private float timer;

    public float changeTimer;

    private Rigidbody2D rBody;

    private int direction = 1;

    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        timer = changeTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            direction = -direction;
            timer = changeTimer;
        }

        var pos = rBody.position;
        pos.x = pos.x + (Time.deltaTime * direction * speed);
        rBody.MovePosition(pos);
    }
}