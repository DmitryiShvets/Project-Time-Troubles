using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public GameObject parent;

    // Update is called once per frame
    void Update()
    {

           transform.position = Vector3.MoveTowards(transform.position, new Vector2(transform.position.x, 0.7f), Time.deltaTime);
        Destroy(parent, 2);

    }

}
