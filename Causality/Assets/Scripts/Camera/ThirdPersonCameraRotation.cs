using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraRotation : MonoBehaviour
{
    private const float Y_ANGLE_MIN = 0.0f;
    private const float Y_ANGLE_MAX = 50.0f;

    public Transform LookAt;
    public Transform camTransform;

    private Camera cam;

    private float RotationYaxis = 0;
    private float RotationXaxis = 0;
    [SerializeField]
    private Transform followXform;
    private Vector3 targetPosition;
    private float Distance = 10.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private float sensitivityX = 120.0f;
    private float sensitivityY = 70.0f;

    // Smoothing and damping
    private Vector3 velocityCamSmooth = Vector3.zero;
    [SerializeField]
    private float canSmoothDampTime = 0.1f;

    // Use this for initialization
    void Start ()
    {
        followXform = GameObject.FindWithTag("Player").transform;

        camTransform = transform;
        cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update ()
    {
        currentX = Input.GetAxis("HorizontalTurn");
        currentY = Input.GetAxis("VerticalTurn");

        RotationXaxis -= currentX * sensitivityX * Time.deltaTime;
        RotationYaxis -= currentY * sensitivityY * Time.deltaTime;
        RotationYaxis = Mathf.Clamp(RotationYaxis,  Y_ANGLE_MIN, Y_ANGLE_MAX);
    }

    private void LateUpdate()
    {
        Vector3 characterOffset = followXform.position + new Vector3(0f, 5.0f, 0f);


        Vector3 dir = new Vector3(0, 0, -Distance);
        Quaternion rotation = Quaternion.Euler(RotationYaxis, RotationXaxis, 0);
        camTransform.position = LookAt.position + rotation * dir;
        camTransform.LookAt(LookAt.position);

        targetPosition = followXform.position + followXform.up * 5.0f - followXform.forward * 5.0f;

        Debug.DrawLine(followXform.position, targetPosition, Color.magenta);

        CompensateForWalls(characterOffset, ref targetPosition);

        // Making a smooth transistion between its current position and the position it wants to be in
        smoothPosition(this.transform.position, targetPosition);
    }

    private void smoothPosition(Vector3 fromPos, Vector3 toPos)
    {
        // Makng a smooth transition between cameras current position to the position it wants to be in
        this.transform.position = Vector3.SmoothDamp(fromPos, toPos, ref velocityCamSmooth, canSmoothDampTime);
    }

    private void CompensateForWalls(Vector3 fromObject, ref Vector3 toTarget)
    {
        Debug.DrawLine(fromObject, toTarget, Color.cyan);

        // Compensate for walls between camera
        RaycastHit wallHit = new RaycastHit();

        if (Physics.Linecast(fromObject, toTarget, out wallHit))
        {
            Debug.DrawRay(wallHit.point, Vector3.left, Color.red);
            toTarget = new Vector3(wallHit.point.x, toTarget.y, wallHit.point.z);
        }
    }
}
