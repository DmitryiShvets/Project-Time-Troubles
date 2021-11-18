using System;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour
{
    // public bool isAlive;

    private float timer;

    [FormerlySerializedAs("AliveState")] public AliveState aliveState;

    public float changeTimer;

    private Rigidbody2D rBody;

    private int direction = 1;

    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        timer = changeTimer / 2;
        aliveState.ResetState();

        if (!aliveState.isAlive) Destroy(gameObject);
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
        pos.x = pos.x + Time.deltaTime * direction * speed;
        rBody.MovePosition(pos);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        aliveState.isAlive = false;
        Destroy(gameObject);
    }

    public void OnMouseDown()
    {
        Debug.Log("Mouse Clicked!");
    }
}