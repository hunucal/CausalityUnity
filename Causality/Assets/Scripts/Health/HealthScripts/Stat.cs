using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Stat
{
    private BarScript bar;
    public float maxValHealth;
    public float maxValTwoHealth;
    public float currentValHealth;
    public float currentValTwoHealth;
    
    private float maxValStamina;
    private float currentValStamina;
    public Stat()
    {
        bar = new BarScript();
    }

    public void StatUpdate(PlayerBlackboard PBB)
    {
        maxValHealth = PBB.maxValHealth;
        maxValTwoHealth = PBB.maxValTwoHealth;
        currentValHealth = PBB.currentValHealth;
        currentValTwoHealth = PBB.currentValHealth;
        maxValStamina = PBB.maxValStamina;
        currentValStamina = PBB.currentValStamina;
        checkIfRecovering(PBB);
    }

    public void checkIfRecovering(PlayerBlackboard PBB)
    {
        if(PBB.ifRecovering == true)
        {
            PBB.recoveringTimer += Time.deltaTime;
            if(PBB.recoveringTimer > 1)
            {
                PBB.currentValStamina += 10f * Time.deltaTime;
            }
        }

        if(PBB.currentValStamina >= 100)
        {
            PBB.currentValStamina = PBB.maxValStamina;
        }
    }

    public float CurrentValHealth
    {
        get
        {
            return currentValHealth;
        }

        set
        {
            this.currentValHealth = value;
            bar.valueHealth = currentValHealth;
        }
    }

    public float CurrentValTwoHealth
    {
        get
        {
            return currentValTwoHealth;
        }

        set
        {
            this.currentValTwoHealth = value;
            bar.valueTwoHealth = currentValTwoHealth;
        }
    }

    public float CurrentValStamina
    {
        get
        {
            return currentValStamina;
        }

        set
        {
            this.currentValStamina = value;
            bar.valueStamina = currentValStamina;
        }
    }

    public float MaxValHealth
    {
        get
        {
            return maxValHealth;
        }

        set
        {
            this.maxValHealth = value;
            bar.MaxValueHealth = maxValHealth;
        }
    }

    public float MaxValTwoHealth
    {
        get
        {
            return maxValTwoHealth;
        }

        set
        {
            this.maxValTwoHealth = value;
        }
    }

    public float MaxValStamina
    {
        get
        {
            return maxValStamina;
        }

        set
        {
            this.maxValStamina = value;
            bar.MaxValueStamina = maxValStamina;
        }
    }

    public void Initialize()
    {
        this.MaxValHealth = maxValHealth;
        this.MaxValTwoHealth = maxValTwoHealth;

        this.MaxValStamina = maxValStamina;

        this.CurrentValHealth = currentValHealth;
        this.CurrentValTwoHealth = currentValHealth;

        this.CurrentValStamina = currentValStamina;
    }
}
