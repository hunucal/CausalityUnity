using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour {
    

    //Get scripts from
    //Attribute Script attScript; 
    private Movement moveScript;
    //Animations
    Animator setAnimator;

    // Use this for initialization
    void Start () {
        setAnimator = GetComponent<Animator>();
        moveScript = GetComponent<Movement>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Inputs();
	}

    void Inputs()
    {
        StopAttacking();
        if (Input.GetButton("A Button"))
        {
            //Select
            moveScript.GetComponent<Movement>().SetRun(true);
        }
        else
        {
            moveScript.GetComponent<Movement>().SetRun(false);
        }
        if (Input.GetButtonDown("X Button"))
        {
            //Sprint/Dash
            moveScript.GetComponent<Movement>().ActivateRoll();
        }
        if (Input.GetButtonDown("B Button"))
        {
            //Roll
        }
        if (Input.GetButtonDown("Y Button"))
        {
            //No Action yet.
        }
        if (Input.GetButtonDown("RB Button"))
        {
            //Heavy Attack
            HeavyAttack();
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
            //Fast Attack
            FastAttack();
        }
        if (Input.GetAxis("LT Button") != 0)
        {
            //Block
            //if(2h)
            Block();
            //else if (1h and shield)
            //ShieldBlock();
        }
        
    }

    void FastAttack()
    {
        //Fast attack
        setAnimator.SetBool("FastAttack", true);
        setAnimator.SetBool("IsAttacking", true);
        //Damage(10);
    }

    void HeavyAttack()
    {
        //Heavy attack
        if(!setAnimator.GetAnimatorTransitionInfo(0).IsName("HeavyAttack"))
        {
        setAnimator.SetBool("HeavyAttack", true);
        setAnimator.SetBool("IsAttacking", true);
        }
    }
    void StopAttacking()
    {
        if(setAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
             setAnimator.SetBool("HeavyAttack", false);
             setAnimator.SetBool("IsAttacking", false);
             setAnimator.SetBool("FastAttack", false);
             
        }
        setAnimator.SetBool("Block", false);

    }
    void Block()
    {
        //Block with weapon
        moveScript.GetComponent<Movement>().SetRun(false);
        setAnimator.SetBool("Block", true);

    }

    void ShieldBlock()
    {
        //Block with shield with bash
    }

    void Select()
    {
        //For Talent Tree
    }

    void Roll()
    {
        //Code Roll in movement use here?
        moveScript.GetComponent<Movement>().Roll();
    }

    void Dash()
    {
        //Code Dash in movement use here?

    }
   
}
