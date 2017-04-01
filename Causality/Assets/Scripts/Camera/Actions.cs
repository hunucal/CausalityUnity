using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour {

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
        }
        if (Input.GetButtonDown("X Button"))
        {
        }
        if (Input.GetButtonDown("B Button"))
        {
        }
        if (Input.GetButtonDown("Y Button"))
        {
        }
        if (Input.GetButtonDown("RB Button"))
        {
        }
        if (Input.GetButtonDown("View Button"))
        {
        }
        if (Input.GetButtonDown("Menu Button"))
        {
        }
        //if (Input.GetAxis("RT Button"))
        //{
        //   FastAttack();
        //}
    }

    void FastAttack()
    {
        //Fast attack
    }

    void HardAttack()
    {
        //Hard attack
    }

    void Block()
    {
        //Block with weapon
    }

    void ShieldBlock()
    {
        //Block with shield
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
}
