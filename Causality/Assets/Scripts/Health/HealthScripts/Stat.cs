using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Stat
{
    [SerializeField]
    private BarScript bar;
    [SerializeField]
    private float maxValHealth;
    [SerializeField]
    private float maxValTwoHealth;
    [SerializeField]
    private float currentValHealth;
    [SerializeField]
    private float currentValTwoHealth;

    [SerializeField]
    private float maxValStamina;
    [SerializeField]
    private float currentValStamina;

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
