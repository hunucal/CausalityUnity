using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float speed = 6.0f;
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
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        CharacterController controller = GetComponent<CharacterController>();
        CurrentSpeed = speed;
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= CurrentSpeed;

            if (RollCD <= 0)
            {
                if (Input.GetButton("A Button"))
                {
                    Roll = true;
                    RollCD = 5;
                }
            }
            else
            {
                RollCD -= Time.fixedDeltaTime;
            }
        }

        if (Roll)
        {
            moveDirection = transform.forward / 5f * Rollspeed;
            CurrentSpeed = Rollspeed;
            RollTimer += Time.fixedDeltaTime;
            if (RollTime < RollTimer)
            {
                Roll = false;
                RollTimer = 0;
            }
        }

        moveDirection.y -= gravity * Time.fixedDeltaTime;
        controller.Move(moveDirection * Time.fixedDeltaTime);
    }
}
