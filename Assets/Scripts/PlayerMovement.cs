using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{

    [Header("Movement")]
    public float walkSpeed;
    public float sprintSpeed;
    public float dashSpeed;
    private float moveSpeed;


    public float groundDrag;

    [Header("Sprinting")]
    public KeyCode sprintKey = KeyCode.LeftShift;

    [Header("Ground Detection")]

    public float playerheight;
    public LayerMask groundMask;
    public bool isGrounded;

    [Header("Jumping")]

    public KeyCode jumpKey = KeyCode.Space;
    public float jumpForce;
    public float airmultiplier;
    public float jumpCooldown;
    bool canJump;

    public Transform orientation;

    float horizontalinput;
    float verticalinput;


    Vector3 moveDirection;

    Rigidbody rb;
    public GameObject spawnPoint;

    public enum MoveState
    {
        Walking,
        Sprinting,
        Dashing,
        Air
    }

    public bool Dashing;

    public MoveState state;


    private void StateHandler()
    {
        if(isGrounded && Input.GetKey(sprintKey))
        {
            state = MoveState.Sprinting;
            moveSpeed = sprintSpeed;
        }
        else if (Dashing)
        {
            state = MoveState.Dashing;
            moveSpeed = dashSpeed;
        }
        else if(isGrounded && !Input.GetKey(sprintKey))
        {
            state = MoveState.Walking;
            moveSpeed = walkSpeed;
        }
        else
        {
            state = MoveState.Air;
        }
    }
    private void handleinput()
    {
        horizontalinput = Input.GetAxisRaw("Horizontal");
        verticalinput = Input.GetAxisRaw("Vertical");

        if(Input.GetKey(jumpKey) && canJump && isGrounded)
        {
            Debug.Log("Jump");
            canJump = false;
            Jump();
            Invoke(nameof(Resetjump), jumpCooldown);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        canJump = true;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerheight *0.5f + 0.2f, groundMask);
        handleinput();
        SpeedControl();
        StateHandler();

        if (state == MoveState.Walking || state == MoveState.Sprinting)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0f;
        }

        // if the player falls off the map, respawn at spawn point
        if (transform.position.y < -10)
        {
            transform.position = spawnPoint.transform.position;
        }
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalinput + orientation.right * horizontalinput;

        if(isGrounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }
        else if (!isGrounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airmultiplier, ForceMode.Force);
        }
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);


        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitevel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitevel.x, rb.velocity.y, limitevel.z);
        }
    }

    private void Jump()
    {
        //Debug.Log("Jump");
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void Resetjump()
    {
        canJump = true;
    }
}
