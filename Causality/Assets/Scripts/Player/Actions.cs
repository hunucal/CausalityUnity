using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions {
    

    //Get scripts from
    //Attribute Script attScript;
    //Animations
    public bool hAttack;
    public bool lAttack;
    private bool block;
    private bool ishAttack;
    private bool islAttack;
    private bool isBlock;
    // Use this for initialization
    void Start () {
        hAttack = false;
        lAttack = false;
        ishAttack = false;
        islAttack = false;
        isBlock = false;
}   
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        //Inputs();
	}

    public void Inputs(PlayerBlackboard PBB, move moveScript)
    {
        StopAttacking(PBB);
        if (Input.GetButton("A Button"))
        {
            //Select
            moveScript.SetRun(true);
        }
        else
        {
            moveScript.SetRun(false);
        }
        if (Input.GetButtonDown("X Button"))
        {
            //Sprint/Dash
        }
        if (Input.GetButtonDown("B Button"))
        {
            //Roll
            Roll(PBB, moveScript);
        }
        if (Input.GetButtonDown("Y Button"))
        {
            //No Action yet.
        }
        if (Input.GetButtonDown("RB Button"))
        {
            //Heavy Attack
            HeavyAttack(PBB);
        }
        if (Input.GetButtonDown("LB Button"))
        {
            //No Action yet.
        }
        if (Input.GetButtonDown("View Button"))
        {
            //No Action yet.
        }
        if (Input.GetButtonDown("Menu Button"))
        {
            //No Action yet.
        }
        if (Input.GetAxis("RT Button") != 0)
        {
            //Light Attack
            LightAttack(PBB);
        }
        if (Input.GetAxis("LT Button") != 0)
        {
            //Block
            Block(PBB, moveScript);
        }
        
    }

    void LightAttack(PlayerBlackboard PBB)
    {
        //Light attack
        islAttack = true;
        PBB.Player.GetComponent<Animator>().SetBool("LightAttack", true);
        PBB.Player.GetComponent<Animator>().SetBool("IsAttacking", true);
        //Damage(10);
    }

    void HeavyAttack(PlayerBlackboard PBB)
    {
        //Heavy attack
        if(!PBB.Player.GetComponent<Animator>().GetAnimatorTransitionInfo(0).IsName("HeavyAttack"))
        {
            ishAttack = true;
             PBB.Player.GetComponent<Animator>().SetBool("HeavyAttack", true);
            PBB.Player.GetComponent<Animator>().SetBool("IsAttacking", true);
        }
    }
    void StopAttacking(PlayerBlackboard PBB)
    {
        if (ishAttack)
        {
            if (PBB.Player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("HeavyAttack"))
            {
                if ( PBB.Player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
                {   
                     PBB.Player.GetComponent<Animator>().SetBool("HeavyAttack", false);
                    PBB.Player.GetComponent<Animator>().SetBool("IsAttacking", false);
                    ishAttack = false;
                }
            }
            else if (PBB.Player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(1).normalizedTime > 1)
            {
                 PBB.Player.GetComponent<Animator>().SetBool("HeavyAttack", false);
                PBB.Player.GetComponent<Animator>().SetBool("IsAttacking", false);
                ishAttack = false;
            }
        }
        else if (islAttack)
        {
            if (PBB.Player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("LightAttack"))
            {
                if (PBB.Player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
                {
                     PBB.Player.GetComponent<Animator>().SetBool("LightAttack", false);
                    PBB.Player.GetComponent<Animator>().SetBool("IsAttacking", false);
                    islAttack = false;
                }
            }
            else if (PBB.Player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(1).normalizedTime > 1)
            {
                 PBB.Player.GetComponent<Animator>().SetBool("LightAttack", false);
                PBB.Player.GetComponent<Animator>().SetBool("IsAttacking", false);
                islAttack = false;
            }
        }
        else if (isBlock)
        {
            if (PBB.Player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Block"))
            {
                if (PBB.Player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
                {
                     PBB.Player.GetComponent<Animator>().SetBool("Block", false);
                    PBB.Player.GetComponent<Animator>().SetBool("IsAttacking", false);
                    isBlock = false;
                }
            }
            else if (PBB.Player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(1).normalizedTime > 1)
            {
                 PBB.Player.GetComponent<Animator>().SetBool("Block", false);
                PBB.Player.GetComponent<Animator>().SetBool("IsAttacking", false);
                isBlock = false;
            }
        }
    }
    void Block(PlayerBlackboard PBB, move moveScript)
    {
        //Block with weapon
        moveScript.SetRun(false);
        PBB.Player.GetComponent<Animator>().SetBool("Block", true);
        PBB.Player.GetComponent<Animator>().SetBool("IsAttacking", true);
        isBlock = true;
    }

    void ShieldBlock()
    {
        //Block with shield
    }

    void Select()
    {
        //For Talent Tree
    }

    void Roll(PlayerBlackboard PBB,move moveScript)
    {
        //Code Roll in movement use here?
        moveScript.ActivateRoll(PBB); 
    }

    void Dash()
    {
        //Code Dash in movement use here?

    }
   
}
