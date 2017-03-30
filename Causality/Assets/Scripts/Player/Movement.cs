using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

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

    //private Rigidbody rb;
    //CharacterController controller;

    //Stick directions
    private float verticalForce;
    private float horizontalForce;

    //Rotation variables
    private Vector3 playerAim;
    private Vector3 rotationDifVec;
    private float newAngle;

    // Use this for initialization
    void Start () {
        //rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void LateUpdate () {

        CharacterController controller = GetComponent<CharacterController>();
        
        CurrentSpeed = Movement_Speed;
        if (controller.isGrounded)
        {
            MovementAnalog();
        }
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

        moveDirection.y -= gravity * Time.fixedDeltaTime;
        controller.Move(moveDirection * Time.fixedDeltaTime);
    }

    void MovementAnalog()
    {
        horizontalForce = Input.GetAxis("Horizontal");
        verticalForce = Input.GetAxis("Vertical");

        //Move
        if (verticalForce != 0 || horizontalForce != 0)
        {
            Move(horizontalForce, verticalForce);
        }
    }

    void Move(float x, float z)
    {
        //Rotate towards stick direction
        Rotate(x, -z);
        //Move in new direction
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, -Input.GetAxis("Vertical"));
        moveDirection *= CurrentSpeed;
    }

    void Rotate(float x, float z)
    {
        newAngle = Vector3.Angle(Vector3.forward, new Vector3(x, 0, z)); //Gets global angle
        if (x < 0) { newAngle = -newAngle; } //flip angle if left side
        transform.localEulerAngles = new Vector3(0f, newAngle, 0f);
        //TODO normalize and smooth
    }
}
