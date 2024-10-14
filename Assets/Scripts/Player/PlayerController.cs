using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerController : MonoBehaviour
{
    // PlayerInput playerInput;
    // InputAction moveAction;
    // private Rigidbody rb;

    // speed variables
    public float moveSpeed;
    public float sprintSpeed;
    public float walkSpeed;
    private bool isSprinting = false;

    // jump variables 
    public float jumpForce;
    public float gravityMultiplier;

    // movement variables
    private Vector3 moveDirection;
    public Vector2 moveInput;

    CharacterController controller;


 

    void Start()
    {
        // using rigid body
        // rb = GetComponent<Rigidbody>();

        // using CharacterController
        controller = GetComponent<CharacterController>();
        moveSpeed = walkSpeed;
    }

    // Moving function which reads the value of the direction moving in on button press
    void OnMove(InputValue value) {
        moveInput = value.Get<Vector2>();
    }

    // Jump function which reads when jump button is pressed, applies jump when player is grounded
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

    // Sprint function sets the sprinting state to true when button is pressed and false when released
    void OnSprint(InputValue value) {
            if(value.isPressed) {
                Debug.Log("pressed: " + value);
                // moveSpeed = sprintSpeed;
                isSprinting = true;
            }
            else {
                Debug.Log("released: " + value);
                // moveSpeed = walkSpeed;
                isSprinting = false;
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

        // // preventing infinite jumps
        // if (controller.isGrounded)
        // {
        //     //moveDirection.y = 0f;

        //     // if(Input.GetButtonDown("Jump")) {
        //     //if (Keyboard.current.spaceKey.wasPressedThisFrame)
        //     //{
        //     //    moveDirection.y = jumpForce;
        //     //}

        //     // sprint button
        //     // if(Input.GetButton("Fire3")) {
        //     if (Keyboard.current.leftShiftKey.isPressed)
        //     {
        //         moveSpeed = sprintSpeed;
        //     }
        //     else
        //     {
        //         moveSpeed = walkSpeed;
        //     }
        // }

        // if(isSprinting) {
        //     moveSpeed = sprintSpeed;
        //     Debug.Log("pressed: " + isSprinting);
        // }
        // else {
        //     moveSpeed = walkSpeed;
        //     Debug.Log("not pressed: " + isSprinting);
        // }

        if(controller.isGrounded) {
            if(isSprinting) {
                moveSpeed = sprintSpeed;
            }
            else {
                moveSpeed = walkSpeed;
            }
        }

        // adding gravity to player
        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityMultiplier * Time.deltaTime);

        // prevents movement from scaling off of frame rate
        controller.Move(moveDirection * Time.deltaTime);
    }


    void Update()
    {
        MovePlayer();
    }
}
