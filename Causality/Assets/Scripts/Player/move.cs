using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {

    //Movement Values
    public float moveSpeed;
    public float drag = 0.5f;
    public float terminalRotationSpeed = 25.0f;
    public Vector3 moveVector { set; get; }
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
    public float rollSpeed = 15f;
    Vector3 rollVector { set; get; }
    private bool setspeedzero;

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
        verticalForce = Input.GetAxisRaw("Vertical");
        if (isroll)
        {
            setAnimation.SetBool("Walk", false);
            setAnimation.SetBool("Run", false);
            Roll();
        }
        else if (!isroll)
        {
            //Check if Horizontal and vertical isn't zero.
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
                    moveVector = PoolInput(horizontalForce, verticalForce);
                    //Rotate our moveVector
                    moveVector = RotateWithView();
                    //Send in rotated moveVector to rotate player
                    RotatePlayer(horizontalForce, verticalForce, moveVector);
                    //Move
                    Move();
                }
            }
            else
            {
                setAnimation.SetBool("Walk", false);
                setAnimation.SetBool("Run", false);
            }
        }
    }

    private void Move()
    {
        if (thisRigidbody.velocity.magnitude > moveSpeed)
        {
            thisRigidbody.velocity = thisRigidbody.velocity.normalized * moveSpeed;
        }
        else
        {
            thisRigidbody.AddForce(moveVector * moveSpeed, ForceMode.VelocityChange);
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
        
            
        if (thisRigidbody.velocity.magnitude > rollSpeed)
        {
            thisRigidbody.velocity = thisRigidbody.velocity.normalized * rollSpeed;
        }
        else
        {
            thisRigidbody.AddForce(transform.forward.normalized * rollSpeed, ForceMode.Impulse);
        }

        if (setAnimation.GetCurrentAnimatorStateInfo(0).IsName("Roll"))
        {
            if (setAnimation.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.6 && setAnimation.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
            {
                rollSpeed = 0;
            }
            else if (setAnimation.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
            {
                setAnimation.SetBool("Roll", false);
                isroll = false;
            }
        }
        if (setspeedzero)
        {
            thisRigidbody.velocity = thisRigidbody.velocity / 10;
            setspeedzero = false;
        }
        else if (setAnimation.GetCurrentAnimatorStateInfo(1).IsName("Roll"))
        {
            if (setAnimation.GetCurrentAnimatorStateInfo(1).normalizedTime > 0.6 && setAnimation.GetCurrentAnimatorStateInfo(1).normalizedTime < 1)
            {
                rollSpeed = 0;
            }
            else if (setAnimation.GetCurrentAnimatorStateInfo(1).normalizedTime > 1)
            {
                setAnimation.SetBool("Roll", false);
                isroll = false;
            }
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
        if (!isroll)
        {
            if (true) //Set Stamina
            {
                setAnimation.SetBool("Roll", true);
                isroll = true;
                rollSpeed = 182.5f;
                setspeedzero = true;
                //TODO:: Use stamina
            }
        }
    }
}
