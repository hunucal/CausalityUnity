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

    //roll
    private Vector3 targetpos;
    private Vector3 currentpos;
    private Vector3 updatepos;
    // Use this for initialization
    void Start () {
        hAttack = false;
        lAttack = false;
        ishAttack = false;
        islAttack = false;
        isBlock = false;
}   

    public void Inputs(PlayerBlackboard PBB, move moveScript)
    {
        if (PBB.isroll)
        {
            Roll(PBB);
            CheckRollStop(PBB);
        }

        StopAttacking(PBB);
        {
            if (Input.GetButton("A Button"))
            {
                //Select
                moveScript.SetRun(true, PBB);
            }
            else
            {
                moveScript.SetRun(false, PBB);
            }
            if (Input.GetButtonDown("X Button"))
            {
                //Sprint/Dash
            }
            if (Input.GetButtonDown("B Button"))
            {
                //Roll
                ActivateRoll(PBB);
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
        }//Collapsable inputs
    }

    void LightAttack(PlayerBlackboard PBB)
    {
        //Light attack
        if (!PBB.Player.GetComponent<Animator>().GetAnimatorTransitionInfo(0).IsName("LightAttack"))
        {
            islAttack = true;
            PBB.Player.GetComponent<Animator>().SetBool("LightAttack", true);
            PBB.Player.GetComponent<Animator>().SetBool("IsAttacking", true);
        }
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
            //for (int i = 0; i < PBB.Player.GetComponent<Animator>(); i++)
            //{
                
            //}
            if (PBB.Player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("HeavyAttack"))
            {
                if ( PBB.Player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
                {   
                    PBB.Player.GetComponent<Animator>().SetBool("HeavyAttack", false);
                    PBB.Player.GetComponent<Animator>().SetBool("IsAttacking", false);
                    ishAttack = false;
                }
            }
            else if (PBB.Player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(1).IsName("HeavyAttack"))
            {
                if (PBB.Player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(1).normalizedTime > 1)
                {
                    PBB.Player.GetComponent<Animator>().SetBool("HeavyAttack", false);
                    PBB.Player.GetComponent<Animator>().SetBool("IsAttacking", false);
                    ishAttack = false;
                }
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
            else if (PBB.Player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(1).IsName("LightAttack"))
            {
                if (PBB.Player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(1).normalizedTime > 1)
                {
                    PBB.Player.GetComponent<Animator>().SetBool("LightAttack", false);
                    PBB.Player.GetComponent<Animator>().SetBool("IsAttacking", false);
                    islAttack = false;
                }
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
            else if (PBB.Player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(1).IsName("Block"))
            {
                if (PBB.Player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(1).normalizedTime > 1)
                {
                    PBB.Player.GetComponent<Animator>().SetBool("Block", false);
                    PBB.Player.GetComponent<Animator>().SetBool("IsAttacking", false);
                    isBlock = false;
                }
            }
        }
    }
    void Block(PlayerBlackboard PBB, move moveScript)
    {
        //Block with weapon
        moveScript.SetRun(false, PBB);
        PBB.Player.GetComponent<Animator>().SetBool("Block", true);
        PBB.Player.GetComponent<Animator>().SetBool("IsAttacking", true);
        isBlock = true;
    }
    
    private void Roll(PlayerBlackboard PBB)
    {
        currentpos = PBB.Player.transform.position;
        updatepos = Vector3.MoveTowards(currentpos, targetpos, PBB.setRollSpeed * Time.fixedDeltaTime);
        PBB.Player.transform.position = updatepos;
    }

    private void CheckRollStop(PlayerBlackboard PBB)
    {
        if (PBB.Player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Roll"))
        {
            if (PBB.Player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 0.9)
            {
                PBB.Player.GetComponent<Animator>().SetBool("Roll", false);
                PBB.isroll = false;
            }
        }
        else if (PBB.Player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(1).IsName("Roll"))
        {
            if (PBB.Player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(1).normalizedTime > 0.9)
            {
                PBB.Player.GetComponent<Animator>().SetBool("Roll", false);
                PBB.isroll = false;
            }
        }
    }

    public void ActivateRoll(PlayerBlackboard PBB)
    {
        if (!PBB.isroll && PBB.Player.GetComponent<Animator>().GetBool("IsAttacking") == false)
        {
            if (PBB.currentValStamina >= 20f)
            {
                PBB.Player.GetComponent<Animator>().SetBool("Roll", true);
                PBB.isroll = true;
                targetpos = PBB.Player.transform.position + PBB.Player.transform.forward.normalized * PBB.rollDistance;
                PBB.currentValStamina -= 20;
                PBB.ifRecovering = false;
            }
        }
    }

    void Select()
    {
        //For Talent Tree
    }

    void Dash()
    {
        //Code Dash 

    }
   
}
