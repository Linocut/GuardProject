using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //this script should be applied to a first person player with a camera and ground check as children 
    //It needs a rigid body and character controller component 
    //It uses input manager and the old unity input system 


    //these variables control jumping 
    [Header("Jumping")]
    public float jumpHeight;
    public float gravity = -9.81f;

    //these variables control the different types of speed
    [Header("Movement")]
    public float sprintSpeed;
    public float baseSpeed;
    public float fatigue;
    public float maxFatigue;
    public float minFatigue;
    //current speed is what we will swap the base, crouch and sprint into
    [SerializeField]
    private float currentSpeed;

    [Header("Crouching")]
    public float crouchYScale;
    public float crouchSpeed;
    private float startYScale;
    private float distanceUp;


    //ground check is a transformation, it needs to be dragged onto the script, the layermask ground mask can also be dragged onto the script
    [Header("Ground Check")]
    public Transform groundCheck;
    public LayerMask groundMask;
    public float groundDistance = 0.4f;
    //isGrounded bool will be later used to control enum for the player
    private bool isGrounded;


    //These are extra connections that end up getting made when the game starts 
    [Header("Extra, private")]
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private CharacterController cc;
    [SerializeField]
    MovementState state;


    //vector 3 for movement 
    private Vector3 velocity;
    private Vector3 move; 

    //variables for inputs 
    private float horizontalInput;
    private float verticalInput;
    private bool jumpInput;
    private bool sprintInput;
    private bool crouchInput;
    private bool crouchInputUp;
    private bool crouchInputDown;


    //public enum states 
    public enum MovementState
    {
        walking,
        sprinting,
        crouching,
        air,
    }

    //functions which are called to control enum states
    private void Jump()
    {
        state = MovementState.air;
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
    }
    private void Sprint()
    {
        
        currentSpeed = sprintSpeed;
        state = MovementState.sprinting;
        Move();
    }
    private void Walk()
    {
        if (fatigue < maxFatigue)
        {
            fatigue = fatigue + 0.25f;
        }
        currentSpeed = baseSpeed;
        state = MovementState.walking;
        Move();
    }
    private void Crouch()
    {
        
        currentSpeed = crouchSpeed;
        state = MovementState.crouching;

        Move();
    }
    private void Move()
    {
        Vector3 move = transform.right * horizontalInput + transform.forward * verticalInput;
        cc.Move(move * currentSpeed * Time.deltaTime);
    }



    //start gets rb and cc
    private void Start()
    {
        fatigue = maxFatigue;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        
        cc = GetComponent<CharacterController>();
        startYScale = transform.localScale.y;
    }
    
    //inputs from the input manager 
    private void GetInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        jumpInput = Input.GetButton("Jump");
        sprintInput = Input.GetButton("Sprint");
        crouchInput = Input.GetButton("Crouch");
        crouchInputUp = Input.GetButtonUp("Crouch");
        crouchInputDown = Input.GetButtonDown("Crouch");
    }

    public void StateHandler()
    { 
        if (isGrounded && sprintInput)
        {
            if (fatigue > 0)
            {
                fatigue--;
            }
            if (fatigue > minFatigue)
            {
                Sprint();
            }
            else
            {
                currentSpeed = baseSpeed; 
            }


        }
        else if (isGrounded && !sprintInput && !crouchInput)
        {

            Walk();
        }
        else
        {
            state = MovementState.air;
        }
    }

    //controlling which functions to call
    private void Update()
    {
        GetInput();
        StateHandler();
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (crouchInput)
        {
            Crouch();
            transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);

            rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
        }
        if (crouchInputUp)
        {
            transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);

        }

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }


        //transform is loca, while if it wasnt itd be new vector and thats gloabl 
        Vector3 move = transform.right * horizontalInput + transform.forward * verticalInput;
        cc.Move(move * currentSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
        
    }

    //gravity calcuation
    void FixedUpdate()
    {

        velocity.y += gravity * Time.deltaTime;
        cc.Move(velocity * Time.deltaTime);
    }
}






      