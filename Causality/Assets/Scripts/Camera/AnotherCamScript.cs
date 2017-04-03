using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnotherCamScript : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private AnotherCamScript gamecam;

    private float horizontal = 0.0f;
    private float vertical = 0.0f;
    private float direction = 0.0f;
    private float speed = 0.0f;
    
    [SerializeField]
    private float directionDampTime = 0.25f;
    [SerializeField]
    private float distanceAway;
    [SerializeField]
    private float distanceAwayMultipler = 1.5f;
    [SerializeField]
    private float distanceUp;
    [SerializeField]
    private float distanceUpMultipler = 5f;
    [SerializeField]
    private float smooth;
    [SerializeField]
    private Transform followXform;
    [SerializeField]
    private float directionSpeed = 1.5f;
    [SerializeField]
    private float rotationDegreePerSecond = 120f;
    [SerializeField]
    private float freeThreshold = -0.1f;
    [SerializeField]
    private Vector2 camMinDiatFromChar = new Vector2(1f, -0.5f);
    [SerializeField]
    private float rightStickThreshold = 0.1f;
    [SerializeField]
    private const float freeRotationDegreePerSecond = -5f;

    private Vector3 lookDir;
    private Vector3 targetPosition;
    private Vector3 savedRigToGoal;
    private float distanceAwayFree;
    private float distanceUpFree;
    private Vector2 rightStickPrevFrame = Vector2.zero;

    // Smoothing and damping
    private Vector3 velocityCamSmooth = Vector3.zero;
    [SerializeField]
    private float camSmoothDampTime = 0.1f;

    private int m_locomotionId = 0;
    private AnimatorStateInfo stateInfo;


    void Start()
    {
        followXform = GameObject.FindWithTag("Player").transform;

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(animator)
        {
            stateInfo = animator.GetCurrentAnimatorStateInfo(0);

            horizontal = Input.GetAxis("HorizontalTurn");
            vertical = Input.GetAxis("VerticalTurn");

            Vector3 characterOffset = followXform.position + new Vector3(0f, distanceUp, 0f);
            Vector3 lookAt = characterOffset;
            Vector3 targetPosition = Vector3.zero;

            StickToWorldspace(this.transform, gamecam.transform, ref direction, ref speed);

            animator.SetFloat("Speed", speed);
            animator.SetFloat("Direction", direction, directionDampTime, Time.deltaTime);
        }
    }

    void FixedUpdate()
    {
        if (IsInLocomotion() && ((direction >= 0 && horizontal <= 0) || (direction < 0 && horizontal < 0)))
        {
            Vector3 rotationAmount = Vector3.Lerp(Vector3.zero, new Vector3(0f, rotationDegreePerSecond * (horizontal < 0f ? -1f : 1f), 0f), Mathf.Abs(horizontal));
            Quaternion deltaRotation = Quaternion.Euler(rotationAmount * Time.deltaTime);
            this.transform.rotation = (this.transform.rotation * deltaRotation);
        }
    }

    void LateUpdate()
    {
        Vector3 characterOffset = followXform.position + new Vector3(0f, distanceUp, 0f);;

        lookDir = characterOffset - this.transform.position;
        lookDir.y = 0;
        lookDir.Normalize();
        Debug.DrawRay(this.transform.position, lookDir, Color.green);


        
        //Debug.DrawRay(follow.position, Vector3.up * distanceUp, Color.red);
        //Debug.DrawRay(follow.position, -1f  * follow.forward * distanceAway, Color.red);
        Debug.DrawLine(followXform.position, targetPosition, Color.magenta);

        targetPosition = characterOffset + followXform.up * distanceUp - lookDir * distanceAway;

        CompensateForWalls(this.transform.position, ref targetPosition);

        smoothPosition(this.transform.position, targetPosition);

        transform.LookAt(followXform);
    }

    private void smoothPosition(Vector3 fromPos, Vector3 toPos)
    {
        this.transform.position = Vector3.SmoothDamp(fromPos, toPos, ref velocityCamSmooth, camSmoothDampTime);
    }

    private void CompensateForWalls(Vector3 fromObject, ref Vector3 toTarget)
    {
        Debug.DrawLine(fromObject, toTarget, Color.cyan);

        RaycastHit wallHit = new RaycastHit();
        if(Physics.Linecast(fromObject, toTarget, out wallHit))
        {
            Debug.DrawRay(wallHit.point, Vector3.left, Color.red);
            toTarget = new Vector3(wallHit.point.x, toTarget.y, wallHit.point.z);
        }
    }

    public void StickToWorldspace(Transform root, Transform camera, ref float directionOut, ref float speedOut)
    {
        Vector3 rootDirection = root.forward;

        Vector3 stickDirection = new Vector3(horizontal, 0, vertical);

        speedOut = stickDirection.sqrMagnitude;

        Vector3 CameraDirection = camera.forward;
        CameraDirection.y = 0.0f;
        Quaternion referentialShift = Quaternion.FromToRotation(Vector3.forward, CameraDirection);

        Vector3 moveDirection = referentialShift * stickDirection;
        Vector3 axisSign = Vector3.Cross(moveDirection, rootDirection);

        Debug.DrawRay(new Vector3(root.position.x, root.position.y + 2f, root.position.z), stickDirection, Color.blue);

        float angleRootToMove = Vector3.Angle(rootDirection, moveDirection) * (axisSign.y >= 0 ? -1f : 1f);

        angleRootToMove /= 180f;

        directionOut = angleRootToMove * directionSpeed;
    }

    public bool IsInLocomotion()
    {
        return stateInfo.nameHash == m_locomotionId;
    }


}
