using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnotherCamScript : MonoBehaviour
{
    private float horizontal = 0.0f;
    private float vertical = 0.0f;

    [SerializeField]
    private float distanceAway;
    [SerializeField]
    private float distanceUp;
    [SerializeField]
    private float smooth;
    [SerializeField]
    private Transform follow;
    [SerializeField]
    private float directionSpeed = 1.5f;

    private Vector3 targetPosition;



    void Start()
    {
        follow = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        horizontal = Input.GetAxis("HorizontalTurn");
        vertical = Input.GetAxis("VerticalTurn");
    }

    void LateUpdate()
    {
        targetPosition = follow.position + Vector3.up * distanceUp - follow.forward * distanceAway;
        Debug.DrawRay(follow.position, Vector3.up * distanceUp, Color.red);
        Debug.DrawRay(follow.position, -1f  * follow.forward * distanceAway, Color.red);
        Debug.DrawRay(follow.position, Vector3.up * distanceUp, Color.red);

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smooth);

        transform.LookAt(follow);
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


}
