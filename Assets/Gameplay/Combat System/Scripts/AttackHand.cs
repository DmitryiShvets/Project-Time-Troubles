using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackHand : MonoBehaviour
{
    [SerializeField] private Transform attackZonePrefab;
    [SerializeField] private Transform colliderAttackZoneObject;
    [SerializeField]
    private Transform up;
    [SerializeField]
    private Transform down;
    [SerializeField]
    private Transform left;
    [SerializeField]
    private Transform right;
    [SerializeField]
    private Transform upLeft;
    [SerializeField]
    private Transform upRight;
    [SerializeField]
    private Transform downLeft;
    [SerializeField]
    private Transform downRight;
  //  bool start;

    void Start()
    {
        colliderAttackZoneObject.position = up.position;
    }

   
    void Update()
    {
       

        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
          //  start = true;
            Instantiate(attackZonePrefab, colliderAttackZoneObject.position, colliderAttackZoneObject.rotation);
        }

        if (CheckDirection.instance.up)
        {
            colliderAttackZoneObject.position = up.position;
        }
        if (CheckDirection.instance.down)
        {
            colliderAttackZoneObject.position = down.position;
        }
        if (CheckDirection.instance.left)
        {
            colliderAttackZoneObject.position = left.position;
        }
        if (CheckDirection.instance.right)
        {
            colliderAttackZoneObject.position = right.position;
        }
        if (CheckDirection.instance.upLeft)
        {
            colliderAttackZoneObject.position = upLeft.position;
        }
        if (CheckDirection.instance.upRight)
        {
            colliderAttackZoneObject.position = upRight.position;
        }
        if (CheckDirection.instance.downLeft)
        {
            colliderAttackZoneObject.position = downLeft.position;
        }
        if (CheckDirection.instance.downRight)
        {
            colliderAttackZoneObject.position = downRight.position;
        }

        attackZonePrefab.position = colliderAttackZoneObject.position;
    }
}
