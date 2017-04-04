using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Roll variables
    [SerializeField]
    private bool roll;
    private bool charge;
    public float rollspeed = 15f;
    private float rollCD;
    public float rolldis;
    Vector3 getrolldis;

    CharacterController controller;

    //Stick directions
    private float verticalForce;
    private float horizontalForce;

    //Rotation and Movement variables
    [SerializeField]
    private float runspeed = 10.0f;
    [SerializeField]
    private float walkspeed = 6.0f;

    private float movementSpeed;
    private Vector3 tmpDirection = Vector3.zero;
    private Vector3 playerAim;
    private Vector3 rotationDifVec;
    private float newAngle;
    private Vector3 velocity;
    private float currentSpeed = 0;
    private float gravity = 20.0f;
    private Vector3 moveDirection = Vector3.zero;
    private Animator Anim;
    private bool run;
    [SerializeField]
    private Camera PlayerCamera;
    //Get Attributes

    // Use this for initialization
    void Start()
    {
        Anim = GetComponent<Animator>();
        run = false;
        movementSpeed = walkspeed;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Set a tempory Direction to use for movement
        tmpDirection = Vector3.zero;
        //Update the controller to current so we can move and check if grounded. aswell as collision with walls
        controller = GetComponent<CharacterController>();
        //Set Current Speed
        currentSpeed = movementSpeed;
        //Check if player is grounded
        if (controller.isGrounded)
        {
            //Move char with left stick
            MovementAnalog();
        }
        else
        {
            //Set gravity if player isn't Grounded
            moveDirection.y -= gravity * Time.fixedDeltaTime;
            controller.Move(moveDirection * Time.fixedDeltaTime);
        }

        Roll();


    }

    public void Roll()
    {
        if (rollCD != 0)
        { 
            rollCD -= Time.fixedDeltaTime;
        }
    
        if (roll)
        {
            currentSpeed = rollspeed;
            controller.Move(getrolldis * rollspeed * Time.fixedDeltaTime);


            if (rollCD  <= 1)
            {
                roll = false;
            }
        }
    }

    public void ActivateRoll()
    {
        if(rollCD <= 0)
        {
            horizontalForce = Input.GetAxisRaw("Horizontal");
            verticalForce = Input.GetAxisRaw("Vertical");
            roll = true;
            getrolldis = new Vector3(horizontalForce * rolldis, 0.0f, -verticalForce * rolldis);
            rollCD = 2; //TODO:: Use stamina
        }
    }

    void Run()
    {
        //attri.CurrentValStamina -= 2.0f * Time.fixedDeltaTime;
        movementSpeed = 10.0f;
        Anim.SetBool("Run", true);
    }

    void Walk()
    {
        movementSpeed = 6.0f;
        Anim.SetBool("Run", false);
        Anim.SetBool("Walk", true);
    }
    
    public void SetRun(bool b)
    {
        run = b;
    }
    
    void MovementAnalog()
    {
        //Get Axis From Horizontal and Vertical from left stick
        horizontalForce = Input.GetAxisRaw("Horizontal");
        verticalForce = Input.GetAxisRaw("Vertical");

        //If Horizontal and vertical isn't 0
        if (verticalForce != 0 || horizontalForce != 0)
        {
            if(Anim.GetBool("IsAttacking") == false)
            {
                //Move
                if (run)
                    Run();
                else
                    Walk();

                Move(horizontalForce, -verticalForce);
                
            }
        }
        else
        {
            //Make Character stop FIX::Reduce velocity
            moveDirection = Vector3.zero;
            Anim.SetBool("Walk", false);
        }
    }

    void Move(float hor, float ver)
    {
        Vector3 CameraPosition = PlayerCamera.transform.position;
        //Get new Vector for movement by taking in hori in x and vert  in z
        moveDirection = new Vector3(CameraPosition.x + hor, 0.0f, CameraPosition.y + ver);
        if (moveDirection.sqrMagnitude > 1.0f)
            moveDirection = moveDirection.normalized;
        
        velocity = moveDirection * currentSpeed;

        controller.Move(velocity * Time.fixedDeltaTime);
        //rotate play to movement
        Vector3 facingrotation = Vector3.Normalize(new Vector3(hor, 0f, ver));

        // facingrotation = Vector3.Lerp(transform.eulerAngles, facingrotation, 0.5f);
        if (facingrotation != Vector3.zero)
        {
            transform.forward = facingrotation;
        }

    }
}