using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Camera_Follow : MonoBehaviour
{
    private GameObject Player;
    public float distanceFromTarget;
    public float height;  
    public float lookSpeed;
    public float angularSpeed;
    public Vector3 initialOffset;
    public float minY;
    public float maxY;

    private float angle;
    private bool moveX, moveY;
    private Vector3 currentOffset;
    // Use this for initialization
    void Start()
    {
        angle = 0f;
        moveX = false;
        moveY = false;
        Player = GameObject.FindGameObjectWithTag("Player");
        if (Player == null)
        {
            Debug.LogError("Assign a target for the camera in Unity's inspector");
        }

        currentOffset = initialOffset;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void LateUpdate()
    {
        transform.position = Player.transform.position + currentOffset;

        float movementX = Input.GetAxis("HorizontalTurn") * angularSpeed * Time.deltaTime;
        float movementY = Input.GetAxis("VerticalTurn") * angularSpeed * Time.deltaTime;
        if (!moveY)
        {
            if (!Mathf.Approximately(movementX, 0f))
            {
                transform.RotateAround(Player.transform.position, Vector3.up, movementX);
                currentOffset = transform.position - Player.transform.position;
                moveX = true;
            }
        }
        if (Mathf.Approximately(movementX, 0f))
            moveX = false;
        if (Mathf.Approximately(movementY, 0f))
            moveY = false;
        if (!moveX)
        {
            if (!Mathf.Approximately(movementY, 0f))
            {
                transform.RotateAround(Player.transform.position, Vector3.right, movementY);
                currentOffset = transform.position - Player.transform.position;
                moveY = true;
            }
        }
        transform.LookAt(Player.transform);
    }
}
