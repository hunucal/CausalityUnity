using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float Movement_Speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    private Vector3 moveDirection = Vector3.zero;


    private bool Roll;
    private bool Charge;
    private float RollTimer;
    private float RollTime = 1f;
    private float Rollspeed = 15f;
    private float CurrentSpeed = 0;
    private float RollCD;


    CharacterController controller;

    //Stick directions
    private float verticalForce;
    private float horizontalForce;

    //Rotation variables
    private Vector3 tmpDirection = Vector3.zero;
    private Vector3 playerAim;
    private Vector3 rotationDifVec;
    private float newAngle;
    private Vector3 velocity;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        tmpDirection = Vector3.zero;
        controller = GetComponent<CharacterController>();
        CurrentSpeed = Movement_Speed;
        if (controller.isGrounded)
        {
            MovementAnalog();
        }
        else
        {
            moveDirection.y -= gravity * Time.fixedDeltaTime;
            controller.Move(moveDirection * Time.fixedDeltaTime);
        }
        //roll();



    }
    void roll()
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
        horizontalForce = Input.GetAxisRaw("Horizontal");
        verticalForce = Input.GetAxisRaw("Vertical");

        //Move
        if (verticalForce != 0 || horizontalForce != 0)
        {
            Move(horizontalForce, -verticalForce);
        }
        else
        {
            moveDirection = Vector3.zero;
        }
    }

    void Move(float hor, float ver)
    {

        moveDirection = new Vector3(hor, 0.0f, ver);
        if (moveDirection.sqrMagnitude > 1.0f)
            moveDirection = moveDirection.normalized;

        velocity = moveDirection * CurrentSpeed;

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