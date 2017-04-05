using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour {
    

    //Get scripts from
    //Attribute Script attScript; 
    private move moveScript;
    //Animations
    Animator setAnimation;

    // Use this for initialization
    void Start () {
        setAnimation = GetComponent<Animator>();
        moveScript = GetComponent<move>();
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
            moveScript.GetComponent<move>().SetRun(true);
        }
        else
        {
            moveScript.GetComponent<move>().SetRun(false);
        }
        if (Input.GetButtonDown("X Button"))
        {
            //Sprint/Dash
            moveScript.GetComponent<move>().ActivateRoll();
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
            //Light Attack
            LightAttack();
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

    void LightAttack()
    {
        //Fast attack
        setAnimation.SetBool("LightAttack", true);
        setAnimation.SetBool("IsAttacking", true);
        //Damage(10);
    }

    void HeavyAttack()
    {
        //Heavy attack
        if(!setAnimation.GetAnimatorTransitionInfo(0).IsName("HeavyAttack"))
        {
        setAnimation.SetBool("HeavyAttack", true);
        setAnimation.SetBool("IsAttacking", true);
        }
    }
    void StopAttacking()
    {
        if(setAnimation.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
             setAnimation.SetBool("HeavyAttack", false);
             setAnimation.SetBool("IsAttacking", false);
             setAnimation.SetBool("LightAttack", false);
             
        }
        setAnimation.SetBool("Block", false);
    }
    void Block()
    {
        //Block with weapon
        moveScript.GetComponent<move>().SetRun(false);
        setAnimation.SetBool("Block", true);
        setAnimation.SetBool("IsAttacking", true);

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
