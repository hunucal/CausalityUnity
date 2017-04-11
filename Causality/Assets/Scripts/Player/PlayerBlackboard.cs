using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlackboard
{
    public GameObject Player;

    public GameObject Boss;

    public GameObject TwoHandWeap;

    public float maxValHealth;
    public float maxValTwoHealth;
    public float currentValHealth;
    public float currentValTwoHealth;

    public float maxValStamina;
    public float currentValStamina;
    public float Dimension;

    public float fillAmountHealth;
    public float fillAmountTwoHealth;
    public float fillAmountStamina;

    public float maxValueHealth { get; set; }
    public float maxValueStamina { get; set; }

    //roll
    public float setRollSpeed; // 7
    public float rollDistance; // 7
    public bool isroll;

    //move
    public float terminalRotationSpeed; //25f
    public float runSpeed; //8f
    public float walkSpeed; //6f

    //Stick directions
    public float verticalForce;
    public float horizontalForce;

    //Animation
    public PlayerBlackboard()
    {
        this.Player = new GameObject();
        this.Boss = new GameObject();
        this.TwoHandWeap = new GameObject();
    }
}
