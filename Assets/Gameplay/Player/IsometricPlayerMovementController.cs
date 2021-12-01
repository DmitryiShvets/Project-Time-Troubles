﻿using Core.Actions;
using ScriptableObjects;
using UnityEngine;

public class IsometricPlayerMovementController : MonoBehaviour
{
    public float movementSpeed = 1f;
    private IsometricCharacterRenderer isoRenderer;
    [SerializeField]
    private PositionState _posState;
    private ActionsManager _playerAction;
    private Rigidbody2D rbody;

    private void Awake()
    {
        _playerAction = new ActionsManager();
        rbody = GetComponent<Rigidbody2D>();
        isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();
    }

    private void OnEnable()
    {
        _playerAction.Enable();
    }

    private void OnDisable()
    {
        _playerAction.Disable();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        var input = _playerAction.Player.Movement.ReadValue<Vector2>();

        //  Vector2 currentPos = rbody.position;

        float hInput = input.x;
        float vInput = input.y;

        Vector2 inputVector = new Vector2(hInput, vInput);
        inputVector = Vector2.ClampMagnitude(inputVector, 1);

        Vector2 movement = inputVector * movementSpeed;
        Vector2 newPos = _posState.pos + movement * Time.fixedDeltaTime;

        isoRenderer.SetDirection(movement);
        rbody.MovePosition(newPos);
        _posState.pos = newPos;
    }

}