using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move {

    //Movement Values
    private Vector3 moveVector { set; get; }
    private Transform camTransform;
    private float moveSpeed;

    private bool isRunning;

    //Roll variables
    private bool isroll;

    private Vector3 targetpos;
    private Vector3 currentpos;
    private Vector3 updatepos;


    // Use this for initialization
    public void InitStart (PlayerBlackboard PBB) {
        //Activate Rigidbody
        PBB.Player.GetComponent<Rigidbody>().maxAngularVelocity = PBB.terminalRotationSpeed;
        
        //Activate animator
        isRunning = false;
        moveSpeed = PBB.walkSpeed;
    }
	
	// Update is called once per frame
	public void MoveUpdate (PlayerBlackboard PBB) {
        //Get Axis from Horizontal and Vertical from left stick
        PBB.horizontalForce = Input.GetAxisRaw("Horizontal");
        PBB.verticalForce = Input.GetAxisRaw("Vertical");

        if (isroll)
        {
            Roll(PBB);
            CheckRollStop(PBB);
        }
        if (!isroll)
        {
            //Check if Horizontal and vertical isn't zero.
            if (PBB.verticalForce != 0 || PBB.horizontalForce != 0)
            {
                if (PBB.Player.GetComponent<Animator>().GetBool("IsAttacking") == false)
                {
                    //Move
                    if (isRunning)
                        Run(PBB);
                    else
                        Walk(PBB);
                    //Get the original input
                    moveVector = PoolInput(PBB.horizontalForce, PBB.verticalForce);
                    //Rotate our moveVector
                    moveVector = RotateWithView();
                    //Send in rotated moveVector to rotate player
                    RotatePlayer(PBB, PBB.horizontalForce, PBB.verticalForce, moveVector);
                    //Move
                    Move(PBB);
                }
            }
            else
            {
                PBB.Player.GetComponent<Animator>().SetBool("Walk", false);
                PBB.Player.GetComponent<Animator>().SetBool("Run", false);
            }
        }
    }

    private void Move(PlayerBlackboard PBB)
    {
        if (PBB.Player.GetComponent<Rigidbody>().velocity.magnitude > moveSpeed)
        {
            PBB.Player.GetComponent<Rigidbody>().velocity = PBB.Player.GetComponent<Rigidbody>().velocity.normalized * moveSpeed;
        }
        else
        {
            PBB.Player.GetComponent<Rigidbody>().AddForce(moveVector * moveSpeed, ForceMode.VelocityChange);
        }
        
    }


    private Vector3 PoolInput(float hor, float ver)
    {
        Vector3 dir = Vector3.zero;

        dir.x = hor;
        dir.y = ver;

        if (dir.magnitude > 1)
            dir.Normalize();

        return dir;
    }

    private Vector3 RotateWithView()
    {
        if(camTransform != null)
        {
            Vector3 dir = camTransform.TransformDirection(moveVector);
            dir.Set(dir.x, 0.0f, dir.z);
            return dir.normalized * moveVector.magnitude;
        }
        else
        {
            camTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
            return moveVector;
        }
    }

    private void RotatePlayer(PlayerBlackboard PBB ,float hor, float ver, Vector3 dir)
    {
        Vector3 facingrotation = Vector3.Normalize(dir);

        // facingrotation = Vector3.Lerp(transform.eulerAngles, facingrotation, 0.5f);
        if (facingrotation != Vector3.zero)
        {
            PBB.Player.transform.forward = facingrotation;
        }
    }

    private void Roll(PlayerBlackboard PBB)
    {
        currentpos = PBB.Player.transform.position;
        updatepos = Vector3.MoveTowards(currentpos, targetpos, PBB.setRollSpeed * Time.fixedDeltaTime);
        PBB.Player.transform.position = updatepos;
    }

    private void CheckRollStop(PlayerBlackboard PBB)
    {
        if (PBB.Player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Roll"))
        {
            if (PBB.Player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 0.9)
            {
                PBB.Player.GetComponent<Animator>().SetBool("Roll", false);
                isroll = false;
            }
        }
        else if (PBB.Player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(1).IsName("Roll"))
        {
            if (PBB.Player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(1).normalizedTime > 0.9)
            {
                PBB.Player.GetComponent<Animator>().SetBool("Roll", false);
                isroll = false;
            }
        }
    }

    public void SetRun(bool b)
    {
        isRunning = b;
    }

    void Walk(PlayerBlackboard PBB)
    {
        moveSpeed = PBB.walkSpeed;
        PBB.Player.GetComponent<Animator>().SetBool("Run", false);
        PBB.Player.GetComponent<Animator>().SetBool("Walk", true);
    }

    void Run(PlayerBlackboard PBB)
    {
        //attri.CurrentValStamina -= 2.0f * Time.fixedDeltaTime;
        moveSpeed = PBB.runSpeed;
        PBB.Player.GetComponent<Animator>().SetBool("Run", true);

    }

    public void ActivateRoll(PlayerBlackboard PBB)
    {
        if (!isroll)
        {
            if (true) //Set Stamina
            {
                PBB.Player.GetComponent<Animator>().SetBool("Roll", true);
                isroll = true;
                targetpos = PBB.Player.transform.position + PBB.Player.transform.forward.normalized * PBB.rollDistance;
                //TODO:: Use stamina
            }
        }
    }
}
