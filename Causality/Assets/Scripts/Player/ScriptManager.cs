using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptManager : MonoBehaviour
{
    private PlayerBlackboard PBB;

    private Actions Actions;

    private Player Player;

    private move Move;


	// Use this for initialization
	void Start ()
    {
        PBB = new PlayerBlackboard();
        Actions = new Actions();
        Player = new Player();
        Move = new move();

        PBB.Player = GameObject.FindGameObjectWithTag("Player");
        PBB.Boss = GameObject.FindGameObjectWithTag("Boss");
        PBB.TwoHandWeap = GameObject.FindGameObjectWithTag("TwoHand");
        PBB.maxValHealth = 100f;
        PBB.maxValTwoHealth = 100f;
        PBB.currentValHealth = 100f;
        PBB.currentValTwoHealth = 100f;
        PBB.maxValStamina = 100f;
        PBB.currentValStamina = 100f;
        PBB.Dimension = 100f;
        PBB.setRollSpeed = 7f;
        PBB.rollDistance = 7f;
        PBB.terminalRotationSpeed = 25f;
        PBB.runSpeed = 6f;
        PBB.walkSpeed = 3f;
        PBB.fillAmountHealth = 1f;
        PBB.fillAmountTwoHealth = 1f;
        PBB.fillAmountStamina = 1f;
        PBB.ifRecovering = false;

        Move.InitStart(PBB);
        Player.Init();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Player.PlayerUpdate(PBB);
        
	}
    void FixedUpdate()
    {
        Actions.Inputs(PBB, Move);
        Move.MoveUpdate(PBB);
    }

    public float GetHealthVal()
    {
        return PBB.currentValHealth / 100f;
    }

    public float GetTwoHealthVal()
    {
        return PBB.currentValTwoHealth / 100f;
    }

    public float GetStaminaVal()
    {
        return PBB.currentValStamina / 100f;
    }

    public float GetMaxValueHealth()
    {
        return PBB.maxValueHealth;
    }

    public float GetMaxValueStamina()
    {
        return PBB.maxValueStamina;
    }
}
