using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // PlayerInput playerInput;
    // InputAction moveAction;
    // private Rigidbody rb;
    public float moveSpeed;
    public float sprintSpeed;
    public float walkSpeed;

    public float jumpForce;
    public float gravityMultiplier;

    CharacterController controller;
    private Vector3 moveDirection;
    public Vector2 moveInput;

    

 

    void Start()
    {
        // using rigid body
        // rb = GetComponent<Rigidbody>();

        // using CharacterController
        controller = GetComponent<CharacterController>();
        moveSpeed = walkSpeed;
    }


    void OnMove(InputValue value) {
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if (controller.isGrounded)
        {
            if(value.isPressed)
            {
                moveDirection.y = jumpForce;
            }
            else
            {
                 moveDirection.y = 0f;
            }
        }
    }

    //void OnSprint(InputValue value)
    //{
    //    //if(controller.isGrounded)
    //    {
    //        if(value != null)
    //        {
    //            moveSpeed = sprintSpeed;
    //        }
    //        else
    //        {
    //            moveSpeed = walkSpeed;
    //        }
    //    }
    //}


    void baseSpeed()
    {
        if (moveSpeed == sprintSpeed)
        {
            moveSpeed = walkSpeed;
        }
    }

    void MovePlayer()
    {       
        // using rigid body
        // rb.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y, Input.GetAxis("Vertical") * moveSpeed);

        // if(Input.GetButtonDown("Jump")) {
        //     rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        // }


        // using CharacterController for 3D movement 

        // moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);

        // stores the y position of the player before calculating the movement of player with mouse in order allow jumps
        float yStore = moveDirection.y;

        // using the mouse to move the player in chosen directions
        // moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
        moveDirection = (transform.forward * moveInput.y) + (transform.right * moveInput.x);
        moveDirection = moveDirection.normalized * moveSpeed;
        moveDirection.y = yStore;

        // preventing infinite jumps
        if (controller.isGrounded)
        {
            //moveDirection.y = 0f;

            // if(Input.GetButtonDown("Jump")) {
            //if (Keyboard.current.spaceKey.wasPressedThisFrame)
            //{
            //    moveDirection.y = jumpForce;
            //}

            // sprint button
            // if(Input.GetButton("Fire3")) {
            if (Keyboard.current.leftShiftKey.isPressed)
            {
                moveSpeed = sprintSpeed;
            }
            else
            {
                moveSpeed = walkSpeed;
            }
        }

        // adding gravity to player
        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityMultiplier * Time.deltaTime);

        // prevents movement from scaling off of frame rate
        controller.Move(moveDirection * Time.deltaTime);
    }


    // void OnJump


    void Update()
    {
        MovePlayer();
    }
}
