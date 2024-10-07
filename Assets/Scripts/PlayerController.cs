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
    public float jumpForce;
    public CharacterController controller;
    private Vector3 moveDirection;
    public float gravityMultiplier;

    void Start()
    {
        // using InputSystem
        // playerInput = GetComponent<PlayerInput>();
        // moveAction = playerInput.actions.FindAction("Move");

        // using rigid body
        // rb = GetComponent<Rigidbody>();

        // using CharacterController
        controller = GetComponent<CharacterController>();
    }

    void MovePlayer()
    {
        // Vector2 direction = moveAction.ReadValue<Vector2>();
        // transform.position += new Vector3(direction.x, 0, direction.y) * moveSpeed * Time.deltaTime;
        
        
        // using rigid body
        // rb.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y, Input.GetAxis("Vertical") * moveSpeed);

        // if(Input.GetButtonDown("Jump")) {
        //     rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        // }


        // using CharacterController for 3D movement 
        moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);

        // preventing infinite jumps
        if(controller.isGrounded) {

            if(Input.GetButtonDown("Jump")) {
                moveDirection.y = jumpForce; 
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
