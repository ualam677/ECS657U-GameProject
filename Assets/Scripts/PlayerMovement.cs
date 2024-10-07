using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScript : MonoBehaviour
{
    //public Vector2 moveValue;

    //[SerializeField]
    //private float moveSpeed;

    //[SerializeField]
    //private float maxSpeed;

    //[SerializeField]
    //private float jumpSpeed;

    //private Vector3 forceDirection;

    //private Rigidbody rb;


    //void Awake()
    //{
    //    rb = GetComponent<Rigidbody>();
    //    inputActions = new InputSystem();
    //}

    //void OnEnable()
    //{
    //    inputActions.Land.Jump.performed += OnJump;
    //    move = inputActions.Land.Movement;
    //    inputActions.Enable();
    //}

    //void OnDisable()
    //{
    //    inputActions.Land.Jump.performed -= OnJump;
    //    inputActions.Disable();
    //}

    //void OnJump(InputAction.CallbackContext ctx)
    //{

    //}

    //void FixedUpdate()
    //{
    //    forceDirection += moveSpeed.ReadValue<Vector2>().x * transform.right * moveSpeed;
    //    forceDirection += moveSpeed.ReadValue<Vector2>().y * transform.forward * moveSpeed;
    //    rb.AddForce(forceDirection, ForceMode.Impulse);
    //    forceDirection += Vector3.zero;


    //}

    PlayerInput playerInput;
    InputAction moveAction;
    public float moveSpeed;
    private Rigidbody rb;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");

    }


    void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector2 direction = moveAction.ReadValue<Vector2>();
        transform.position += new Vector3(direction.x, 0, direction.y) * moveSpeed * Time.deltaTime;
    }



}
