using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Camera_Follow : MonoBehaviour
{
    [SerializeField]
    private float distanceAway;
    [SerializeField]
    private float distanceUp;
    [SerializeField]
    private float smooth;
    [SerializeField]
    private Transform follow;

    private Vector3 targetPosition;

    void start()
    {
        follow = GameObject.FindWithTag("Player").transform;
    }


    void update()
    {

    }

    void OnDrawGizmos()
    {

    }

    void LateUpdate()
    {
        // Setting the target to be the correct offset from the hovercraft
        targetPosition = follow.position + follow.up * distanceUp - follow.forward * distanceAway;
        Debug.DrawRay(follow.position, Vector3.up * distanceUp, Color.red);
        Debug.DrawRay(follow.position, -1f * follow.forward * distanceAway, Color.blue);
        Debug.DrawLine(follow.position, targetPosition, Color.magenta);

        // Making a smooth transistion between it´s current position and the position it wants to be in
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smooth);

        // make sure the camera is looking the right way
        transform.LookAt(follow);
    }
}
