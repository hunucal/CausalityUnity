using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour {
    

    //Get scripts from
    //Attribute Script attScript; 
    private move moveScript;
    //Animations
    Animator setAnimation;
<<<<<<< HEAD
    public bool Blocking = false;

=======
    public bool hAttack;
    public bool lAttack;
    public bool block;
>>>>>>> 667650c188841f66796822740d23713eba2510a9
    // Use this for initialization
    void Start () {
        setAnimation = GetComponent<Animator>();
        moveScript = GetComponent<move>();
        hAttack = false;
        lAttack = false;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Inputs();
        print(Blocking);
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
        }
        if (Input.GetButtonDown("B Button"))
        {
            //Roll
            moveScript.GetComponent<move>().ActivateRoll(); 
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
            Blocking = true;
            Block();
            //else if (1h and shield)
            //ShieldBlock();
        }
    }

    void LightAttack()
    {
        //Light attack
        lAttack = true;
        setAnimation.SetBool("LightAttack", true);
        setAnimation.SetBool("IsAttacking", true);
        //Damage(10);
    }

    void HeavyAttack()
    {
        //Heavy attack
        if(!setAnimation.GetAnimatorTransitionInfo(0).IsName("HeavyAttack"))
        {
            hAttack = true;
            setAnimation.SetBool("HeavyAttack", true);
            setAnimation.SetBool("IsAttacking", true);
        }
    }
    void StopAttacking()
    {
        if (hAttack)
        {
            if (setAnimation.GetCurrentAnimatorStateInfo(0).IsName("HeavyAttack"))
            {
                if (setAnimation.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
                {
                    setAnimation.SetBool("HeavyAttack", false);
                    setAnimation.SetBool("IsAttacking", false);
                    hAttack = false;
                }
            }
            else if (setAnimation.GetCurrentAnimatorStateInfo(1).normalizedTime > 1)
            {
                setAnimation.SetBool("HeavyAttack", false);
                setAnimation.SetBool("IsAttacking", false);
                hAttack = false;
            }
        }
        else if (lAttack)
        {
            if (setAnimation.GetCurrentAnimatorStateInfo(0).IsName("LightAttack"))
            {
                if (setAnimation.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
                {
                    setAnimation.SetBool("LightAttack", false);
                    setAnimation.SetBool("IsAttacking", false);
                    lAttack = false;
                }
            }
            else if (setAnimation.GetCurrentAnimatorStateInfo(1).normalizedTime > 1)
            {
                setAnimation.SetBool("LightAttack", false);
                setAnimation.SetBool("IsAttacking", false);
                lAttack = false;
            }
        }
        else if (block)
        {
            if (setAnimation.GetCurrentAnimatorStateInfo(0).IsName("Block"))
            {
                if (setAnimation.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
                {
                    setAnimation.SetBool("Block", false);
                    setAnimation.SetBool("IsAttacking", false);
                    block = false;
                }
            }
            else if (setAnimation.GetCurrentAnimatorStateInfo(1).normalizedTime > 1)
            {
                setAnimation.SetBool("Block", false);
                setAnimation.SetBool("IsAttacking", false);
                block = false;
            }
        }
    }
    public void Block()
    {
        //Block with weapon
        moveScript.GetComponent<move>().SetRun(false);
        setAnimation.SetBool("Block", true);
        setAnimation.SetBool("IsAttacking", true);
        block = true;
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
        moveScript.GetComponent<Movement>().Roll();
    }

    void Dash()
    {
        //Code Dash in movement use here?

    }
   
}
