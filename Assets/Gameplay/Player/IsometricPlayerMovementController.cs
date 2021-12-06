using Core.Actions;
using ScriptableObjects;
using UnityEngine;

public class IsometricPlayerMovementController : MonoBehaviour
{
    public static IsometricPlayerMovementController instance;
    public float movementSpeed = 1f;
    private IsometricCharacterRenderer isoRenderer;
    [SerializeField]
    private PositionState _posState;
    private ActionsManager _playerAction;
    private Rigidbody2D rbody;
    public Vector2 movement;

    private void Awake()
    {
        instance = this;
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

          Vector2 currentPos = rbody.position;

        float hInput = input.x;
        float vInput = input.y;

        Vector2 inputVector = new Vector2(hInput, vInput);
        inputVector = Vector2.ClampMagnitude(inputVector, 1);

        movement = inputVector * movementSpeed;
        Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;


        //Debug.Log(movement + " " + newPos);

        

        isoRenderer.SetDirection(movement);
        rbody.MovePosition(newPos);
        _posState.pos = newPos;

    } 

   

}