using System;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.Serialization;
using Core;
using UnityEditor;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _item;
    public bool isAlive;

    public GameObject obj;

    private float timer;

    [FormerlySerializedAs("AliveState")] public AliveState aliveState;

    public float changeTimer;

    private Rigidbody2D rBody;

    private int direction = 1;

    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        _item.SetActive(false);
        rBody = GetComponent<Rigidbody2D>();
        timer = changeTimer ;
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
        pos.x = pos.x + (Time.deltaTime * direction * speed);
        rBody.MovePosition(pos);
    }

    private void OnDestroy()
    {
        _item.SetActive(true);
    }
}