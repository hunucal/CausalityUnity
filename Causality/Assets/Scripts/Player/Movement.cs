using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float Movement_Speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    private Vector3 moveDirection = Vector3.zero;

    [SerializeField]
    private Camera_Follow gamecam;
    [SerializeField]
    private float directionSpeed = 1.5f;
    [SerializeField]
    private float rotationDegreePerSecond = 120f;

    private float direction = 0f;
    private float speed = 0.0f;

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
    private Vector3 playerAim;
    private Vector3 rotationDifVec;
    private float newAngle;

    // Use this for initialization
    void Start () {
        
    }

    void FixedUpdate()
    {
        if ((direction >= 0 && horizontalForce >= 0) || (direction < 0 && horizontalForce < 0))
        {
            Vector3 rotationAmount = Vector3.Lerp(Vector3.zero, new Vector3(0f, rotationDegreePerSecond * (horizontalForce < 0f ? -1f : 1f), 0f), Mathf.Abs(horizontalForce));
            Quaternion deltaRotation = Quaternion.Euler(rotationAmount * Time.deltaTime);
            this.transform.rotation = (this.transform.rotation * deltaRotation);
        }
    }

    // Update is called once per frame
    void LateUpdate () {

        controller = GetComponent<CharacterController>();
        CurrentSpeed = Movement_Speed;
        if (controller.isGrounded)
        {
            MovementAnalog();
        }
        roll();

        moveDirection.y -= gravity * Time.fixedDeltaTime;
        controller.Move(moveDirection * Time.fixedDeltaTime);
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
        horizontalForce = Input.GetAxis("Horizontal");
        verticalForce = Input.GetAxis("Vertical");

        //Move
        if (verticalForce != 0 || horizontalForce != 0)
        {
            Move(horizontalForce, -verticalForce);
        }
        else
        {
            moveDirection = Vector3.zero;
        }

        StickToWorldspace(this.transform, gamecam.transform, ref direction, ref speed);
    }

    void Move(float x, float z)
    {

        //Rotate towards stick direction
        Rotate(x, z);
        {
            //Move in new direction
            moveDirection = new Vector3(x, 0, z);
            moveDirection *= CurrentSpeed;
        }
     
    }

    private void Rotate(float x, float z)
    {
       
        newAngle = Vector3.Angle(Vector3.forward, new Vector3(x, 0, z)); //Gets global angle
        if (x < 0) { newAngle = -newAngle; } //flip angle if left side
        Vector3 newAngles = new Vector3(0f, newAngle, 0f);

        transform.localEulerAngles = newAngles;

        //Debug.Log("newAngles");
        //Debug.Log(newAngles);
        //Debug.Log("Euler");
        //Debug.Log(transform.localEulerAngles);

        //if (Mathf.Equals(transform.localEulerAngles, newAngles))
        //    return true;
        //else
        // return false;
        //TODO normalize and smooth
    }

    public void StickToWorldspace(Transform root, Transform camera, ref float directionOut, ref float speedOut)
    {
        Vector3 rootDirection = root.forward;

        Vector3 stickDirection = new Vector3(horizontalForce, 0, verticalForce);

        speedOut = stickDirection.sqrMagnitude;

        // Get camera rotation
        Vector3 CameraDirection = camera.forward;
        CameraDirection.y = 0.0f; // kill Y
        Quaternion referentialShift = Quaternion.FromToRotation(Vector3.forward, CameraDirection);

        // Convert joystick input in worldspace coordinates
        Vector3 moveDirection = referentialShift * stickDirection;
        Vector3 axisSign = Vector3.Cross(moveDirection, rootDirection);

        Debug.DrawRay(new Vector3(root.position.x, root.position.y + 2f, root.position.z), moveDirection, Color.green);
        Debug.DrawRay(new Vector3(root.position.x, root.position.y + 2f, root.position.z), axisSign, Color.red);
        Debug.DrawRay(new Vector3(root.position.x, root.position.y + 2f, root.position.z), rootDirection, Color.magenta);
        //Debug.DrawRay(new Vector3(root.position.x, root.position.y + 2f, root.position.z), stickDirection, Color.blue);

        float angleRootToMove = Vector3.Angle(rootDirection, moveDirection) * (axisSign.y >= 0 ? -1f : 1f);

        angleRootToMove /= 180f;

        directionOut = angleRootToMove * directionSpeed;
    }
}
