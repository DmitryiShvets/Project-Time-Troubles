using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDirection : MonoBehaviour
{
    public static CheckDirection instance;
    public bool up;
    public bool down;

    public bool left;
    public  bool right;

    public bool upLeft;
    public bool upRight;

    public bool downLeft;
    public bool downRight;
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

        if (IsometricPlayerMovementController.instance.movement.x == 0 && IsometricPlayerMovementController.instance.movement.y > 0)
        {
            up = true;
            down = false;
            left = false;
            right = false;
            upLeft = false;
            upRight = false;
            downLeft = false;
            downRight = false;

            Debug.Log("Двигаешься вправо");
        }
        if (IsometricPlayerMovementController.instance.movement.x == 0 && IsometricPlayerMovementController.instance.movement.y < 0)
        {
            up = false;
            down = true;
            left = false;
            right = false;
            upLeft = false;
            upRight = false;
            downLeft = false;
            downRight = false;

            Debug.Log("Двигаешься вправо");
        }
        if (IsometricPlayerMovementController.instance.movement.x > 0 && IsometricPlayerMovementController.instance.movement.y == 0)
        {
            up = false;
            down = false;
            left = false;
            right = true;
            upLeft = false;
            upRight = false;
            downLeft = false;
            downRight = false;

            Debug.Log("Двигаешься вправо");
        }
        if (IsometricPlayerMovementController.instance.movement.x < 0 && IsometricPlayerMovementController.instance.movement.y == 0)
        {
            up = false;
            down = false;
            left = true;
            right = false;
            upLeft = false;
            upRight = false;
            downLeft = false;
            downRight = false;
            Debug.Log("Двигаешься влево");
        }
        if (IsometricPlayerMovementController.instance.movement.x > 0 && IsometricPlayerMovementController.instance.movement.y > 0)
        {
            up = false;
            down = false;
            left = false;
            right = false;
            upLeft = false;
            upRight = true;
            downLeft = false;
            downRight = false;
            Debug.Log("Двигаешься по диагонали вверх вправо");
        }
        if (IsometricPlayerMovementController.instance.movement.x < 0 && IsometricPlayerMovementController.instance.movement.y > 0)
        {
            up = false;
            down = false;
            left = false;
            right = false;
            upLeft = true;
            upRight = false;
            downLeft = false;
            downRight = false;
            Debug.Log("Двигаешься по диагонали вверх влево");
        }
        if (IsometricPlayerMovementController.instance.movement.x < 0 && IsometricPlayerMovementController.instance.movement.y < 0)
        {
            up = false;
            down = false;
            left = false;
            right = false;
            upLeft = false;
            upRight = false;
            downLeft = true;
            downRight = false;
            Debug.Log("Двигаешься по диагонали вниз влево");
        }
        if (IsometricPlayerMovementController.instance.movement.x > 0 && IsometricPlayerMovementController.instance.movement.y < 0)
        {
            up = false;
            down = false;
            left = false;
            right = false;
            upLeft = false;
            upRight = false;
            downLeft = false;
            downRight = true;
            Debug.Log("Двигаешься по диагонали вниз вправо");
        }
    }
}
