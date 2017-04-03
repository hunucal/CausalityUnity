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
    

    // Use this for initialization
    void Start () {
        
        
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Inputs();

        
	}

    void Inputs()
    {
        if(Input.GetButtonDown("A Button"))
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
            //No Action yet.
        }
    }

    void FastAttack()
    {
        //Fast attack
        //  Animation.Instantiate<FastAttack>();


        //Damage(10);
    }

    void HeavyAttack()
    {
        //Heavy attack
        //Damage(20);
    }

    void Block()
    {
        //Block with weapon

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
