using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

   
    
   
    //Roll variables
    private bool roll;
    private bool charge;
    private float rollTimer;
    private float rollTime = 1f;
    private float rollspeed = 15f;
   
    private float RollCD;


    CharacterController controller;

    //Stick directions
    private float verticalForce;
    private float horizontalForce;

    //Rotation and Movement variables
    public float movementSpeed = 6.0f;
    private Vector3 tmpDirection = Vector3.zero;
    private Vector3 playerAim;
    private Vector3 rotationDifVec;
    private float newAngle;
    private Vector3 velocity;
    private float currentSpeed = 0;
    private float gravity = 20.0f;
    private Vector3 moveDirection = Vector3.zero;
    private Animator Anim;
    // Use this for initialization
    void Start()
    {
        Anim = GetComponent<Animator>();
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
        //Roll();



    }
    void Roll()
    {
        //    if (RollCD <= 0)
        //    {
        //        if (Input.GetButton("A Button"))
        //        {
        //            Roll = true;
        //            RollCD = 5;
        //        }
        //    }
        //    else
        //    {
        //        RollCD -= Time.fixedDeltaTime;
        //    }
        //}

        //if (Roll)
        //{
        //    moveDirection = transform.forward / 5f * Rollspeed;
        //    CurrentSpeed = Rollspeed;
        //    RollTimer += Time.fixedDeltaTime;
        //    if (RollTime < RollTimer)
        //    {
        //        Roll = false;
        //        RollTimer = 0;
        //    }
        //}
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
                Move(horizontalForce, -verticalForce);
                Anim.SetBool("Walk", true);
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
        //Get new Vector for movement by taking in hori in x and vert  in z
        moveDirection = new Vector3(hor, 0.0f, ver);
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