using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackHand : MonoBehaviour
{
    [SerializeField] private Transform attackZonePrefab;
    [SerializeField] private Transform colliderAttackZoneObject;
    private Transform slashTransform;
    [SerializeField]
    private Transform up;
    private Vector3 vector_up = new Vector3 (0f, 1f, 0f);
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

    private string name_anim;
    //  bool start;

    Animator animator;

    void Start()
    {
        colliderAttackZoneObject.position = up.position;

    }

    private void Awake()
    {
        //cache the animator component
        animator = GetComponentInChildren<Animator>();
    }


    void Update()
    {


        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            //  start = true;
            Instantiate(attackZonePrefab, colliderAttackZoneObject.position, colliderAttackZoneObject.rotation);
            animator.Play(name_anim);
        }

        if (CheckDirection.instance.up)
        {
            
            colliderAttackZoneObject.position = up.position;
            name_anim = "SlashEffect";
            var pos = up.position;
            pos.y = up.position.y + 0.3f;
            animator.transform.position = pos;
        }
        if (CheckDirection.instance.down)
        {
            colliderAttackZoneObject.position = down.position;
            name_anim = "SlashEffectLeft";
            var pos = down.position;
            pos.y = down.position.y + 0.1f;
            animator.transform.position = pos;
        }
        if (CheckDirection.instance.left)
        {
            colliderAttackZoneObject.position = left.position;
            name_anim = "SlashEffectLeft";
            var pos = left.position;
            pos.y = left.position.y + 0.5f;
            animator.transform.position = pos;
        }
        if (CheckDirection.instance.right)
        {
            colliderAttackZoneObject.position = right.position;
            name_anim = "SlashEffect";
            var pos = right.position;
            pos.y = right.position.y + 0.5f;
            animator.transform.position = pos;
        }
        if (CheckDirection.instance.upLeft)
        {
            colliderAttackZoneObject.position = upLeft.position;
            name_anim = "SlashEffectLeft";
            var pos = upLeft.position;
            pos.y = upLeft.position.y + 0.3f;
            animator.transform.position = pos;
        }
        if (CheckDirection.instance.upRight)
        {
            colliderAttackZoneObject.position = upRight.position;
            name_anim = "SlashEffect";
            var pos = upRight.position;
            pos.y = upRight.position.y + 0.3f;
            animator.transform.position = pos;
        }
        if (CheckDirection.instance.downLeft)
        {
            colliderAttackZoneObject.position = downLeft.position;
            name_anim = "SlashEffectLeft";
            var pos = downLeft.position;
            pos.y = downLeft.position.y + 0.8f;
            animator.transform.position = pos;
        }
        if (CheckDirection.instance.downRight)
        {
            colliderAttackZoneObject.position = downRight.position;
            name_anim = "SlashEffect";
            var pos = downRight.position;
            pos.y = downRight.position.y + 0.8f;
            animator.transform.position = pos;
        }

        attackZonePrefab.position = colliderAttackZoneObject.position;
    }
}
