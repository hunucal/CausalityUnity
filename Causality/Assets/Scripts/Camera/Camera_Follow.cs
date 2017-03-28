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

    private Vector3 currentOffset;
    // Use this for initialization
    void Start()
    {
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

        float movementX = Input.GetAxis("Horizontal") * angularSpeed * Time.deltaTime;
        float movementY = Input.GetAxis("Vertical") * angularSpeed * Time.deltaTime;
        if (!Mathf.Approximately(movementX, 0f))
        {
            transform.RotateAround(Player.transform.position, Vector3.up, movementX);
            currentOffset = transform.position - Player.transform.position;
        }
        else if (!Mathf.Approximately(movementY, 0f))
        {
            transform.RotateAround(Player.transform.position, Vector3.right, movementY);
            currentOffset = transform.position - Player.transform.position;
        }

    }

}
