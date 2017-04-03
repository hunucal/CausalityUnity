using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour {
    
    //Player Attributes
    private float defence;
    private float strenght;
    private float agility;
    private float damage;
    private float stamina;

    //Get Attributes from
    //Attribute Script attScript;

    //Animations
    Animator setAnimator;

    // Use this for initialization
    void Start () {
        setAnimator = GetComponent<Animator>();
        
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //stamina = attScript.GetCompnenet<attScript>().stamina;
        Inputs();
        //attScript.GetComponent<attScript>().stamina = stamina;
        
	}

    void Inputs()
    {
        StopAttacking();
        if (Input.GetButtonDown("A Button"))
        { 
            //Select
        }
        if (Input.GetButtonDown("X Button"))
        {
            //Sprint/Dash
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
        stamina -= 20; //TODO: Fix variable
        }
        //Damage(20);
    }
    void StopAttacking()
    {
        if(setAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
             setAnimator.SetBool("HeavyAttack", false);
             setAnimator.SetBool("IsAttacking", false);
             setAnimator.SetBool("FastAttack", false);
             setAnimator.SetBool("Block", false);
        }
      
    }
    void Block()
    {
        //Block with weapon
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

    }

    void Dash()
    {
        //Code Dash in movement use here?

    }
    void DamageGiven(float x, float edef)
    {
        //Calculate Damage
        damage = x + strenght * agility / edef;
    }
    void DamageTaken(float x, float estr, float eagi)
    {
        damage = x + estr * eagi / defence;
    }
}
