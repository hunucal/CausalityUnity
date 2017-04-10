using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptManager : MonoBehaviour
{
    private PlayerBlackboard PBB;

    private Actions Actions;

    private Player Player;

    private Bravo PlayerHealth;

    private move Move;


	// Use this for initialization
	void Start ()
    {
        PBB = new PlayerBlackboard();
        Actions = new Actions();
        Player = new Player();
        PlayerHealth = new Bravo();
        Move = new move();

        PBB.Player = GameObject.FindGameObjectWithTag("Player");
        PBB.Boss = GameObject.FindGameObjectWithTag("Boss");
        PBB.TwoHandWeap = GameObject.FindGameObjectWithTag("TwoHand");
        PBB.Health = 100f;
        PBB.Stamina = 100f;
        PBB.Dimension = 100f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Player.Update();
        
	}
    void FixedUpdate()
    {
        Actions.Inputs();
    }
}
