using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {

    //Movement Values
    public float moveSpeed;
    public float drag = 0.5f;
    public float terminalRotationSpeed = 25.0f;
    public Vector3 MoveVector { set; get; }
    private Rigidbody thisRigidbody;
    private Transform camTransform;
    [SerializeField]
    private float runspeed = 10.0f;
    [SerializeField]
    private float walkspeed = 6.0f;

    //Stick directions
    private float verticalForce;
    private float horizontalForce;

    //Animation
    Animator setAnimation;
    private bool run;

    //Roll variables
    [SerializeField]
    private bool isroll;
    [Header("Roll Speed")]
    public float rollspeed = 15f;
    [Header("Roll Distance")]
    public float rolldis;


    // Use this for initialization
    void Start () {
        //Activate Rigidbody
        thisRigidbody = gameObject.GetComponent<Rigidbody>();
        thisRigidbody.maxAngularVelocity = terminalRotationSpeed;
        thisRigidbody.drag = drag;

        //Activate animator
        setAnimation = GetComponent<Animator>();
        run = false;
        moveSpeed = walkspeed;
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //Get Axis from Horizontal and Vertical from left stick
        horizontalForce = Input.GetAxisRaw("Horizontal");
        verticalForce = -Input.GetAxisRaw("Vertical");
        //Check if Horizontal and vertical isn't zero.
        if (isroll)
        {
         Roll();
        }
        else
        {

            if (verticalForce != 0 || horizontalForce != 0)
            {
                if (setAnimation.GetBool("IsAttacking") == false)
                {
                    //Move
                    if (run)
                        Run();
                    else
                        Walk();
                    //Get the original input
                    MoveVector = PoolInput(horizontalForce, verticalForce);
                    //Rotate our moveVector
                    MoveVector = RotateWithView();

                    RotatePlayer(horizontalForce, verticalForce, MoveVector);
                    //Move
                    Move();
                
                }
            }
            else
            {
                setAnimation.SetBool("Walk", false);
            }
        }
    }

    private void Move()
    {
        thisRigidbody.AddForce(MoveVector * moveSpeed);
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
            Vector3 dir = camTransform.TransformDirection(MoveVector);
            dir.Set(dir.x, 0.0f, dir.z);
            return dir.normalized * MoveVector.magnitude;
        }
        else
        {
            camTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
            return MoveVector;
        }
    }

    private void RotatePlayer(float hor, float ver, Vector3 dir)
    {
        Vector3 facingrotation = Vector3.Normalize(dir);

        // facingrotation = Vector3.Lerp(transform.eulerAngles, facingrotation, 0.5f);
        if (facingrotation != Vector3.zero)
        {
            transform.forward = facingrotation;
        }
    }

    private void Roll()
    {
        moveSpeed = rollspeed;
        if (verticalForce != 0 || horizontalForce != 0)
        {
            thisRigidbody.AddForce(MoveVector * rolldis * moveSpeed);
        }
        else
        {
            thisRigidbody.AddForce(transform.forward * rolldis * moveSpeed);
        }

        if (setAnimation.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            setAnimation.SetBool("Roll", false);
            isroll = false;
        }
    }

    public void SetRun(bool b)
    {
        run = b;
    }

    void Walk()
    {
        moveSpeed = walkspeed;
        setAnimation.SetBool("Run", false);
        setAnimation.SetBool("Walk", true);
    }

    void Run()
    {
        //attri.CurrentValStamina -= 2.0f * Time.fixedDeltaTime;
        moveSpeed = runspeed;
        setAnimation.SetBool("Run", true);
    }

    public void ActivateRoll()
    {
        if (true) //Set Stamina
        {
            setAnimation.SetBool("Roll", true);
            isroll = true;
            MoveVector = PoolInput(horizontalForce, verticalForce);
            MoveVector = RotateWithView();
            //TODO:: Use stamina
        }
    }
}
