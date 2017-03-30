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

    public float RotationYaxis = 0;
    public float RotationXaxis = 0;
    [SerializeField]
    private float distanceUp;
    [SerializeField]
    private Transform followXform;
    private Vector3 targetPosition;

    private float Distance = 10.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private float sensitivityX = 10.0f;
    private float sensitivityY = 10.0f;

    // Use this for initialization
    void Start ()
    {
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
        Vector3 characterOffset = followXform.position + new Vector3(0f, distanceUp, 0f);


        Vector3 dir = new Vector3(0, 0, -Distance);
        Quaternion rotation = Quaternion.Euler(RotationYaxis, RotationXaxis, 0);
        camTransform.position = LookAt.position + rotation * dir;
        camTransform.LookAt(LookAt.position);

        CompensateForWalls(characterOffset, ref targetPosition);

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
