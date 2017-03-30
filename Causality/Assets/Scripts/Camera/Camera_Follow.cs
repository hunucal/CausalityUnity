﻿using System.Collections;
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
    private Transform followXform;
    [SerializeField]
    private Vector3 offset = new Vector3(0f, 1.5f, 0f);

    // Private global only
    private Vector3 lookDir;
    private Vector3 targetPosition;

    // Smoothing and damping
    private Vector3 velocityCamSmooth = Vector3.zero;
    [SerializeField]
    private float canSmoothDampTime = 0.1f;

    void start()
    {
        followXform = GameObject.FindWithTag("Player").transform;
    }


    void update()
    {

    }

    void OnDrawGizmos()
    {

    }

    void LateUpdate()
    {
        Vector3 characterOffset = followXform.position + offset;

        // Calculate diraction from camera to player, kill Y, and normalize to give a valid direction with unit magnitude
        lookDir = characterOffset - this.transform.position;
        lookDir.y = 0;
        lookDir.Normalize();
        Debug.DrawRay(this.transform.position, lookDir, Color.green);



        // Setting the target to be the correct offset from the hovercraft
        targetPosition = followXform.position + followXform.up * distanceUp - followXform.forward * distanceAway;
       // Debug.DrawRay(follow.position, Vector3.up * distanceUp, Color.red);
       // Debug.DrawRay(follow.position, -1f * follow.forward * distanceAway, Color.blue);
        Debug.DrawLine(followXform.position, targetPosition, Color.magenta);

        // Making a smooth transistion between its current position and the position it wants to be in
        smoothPosition(this.transform.position, targetPosition);

        // make sure the camera is looking the right way
        transform.LookAt(followXform);
    }

    private void smoothPosition(Vector3 fromPos, Vector3 toPos)
    {
        // Makng a smooth transition between cameras current position to the position it wants to be in
        this.transform.position = Vector3.SmoothDamp(fromPos, toPos, ref velocityCamSmooth, canSmoothDampTime);
    }
}
