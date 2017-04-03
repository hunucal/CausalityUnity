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
    private float maxVal;
    [SerializeField]
    private float maxValTwo;
    [SerializeField]
    private float currentVal;
    [SerializeField]
    private float currentValTwo;

    public float CurrentVal
    {
        get
        {
            return currentVal;
        }

        set
        {
            this.currentVal = value;
            bar.value = currentVal;
        }
    }

    public float CurrentValTwo
    {
        get
        {
            return currentValTwo;
        }

        set
        {
            this.currentValTwo = value;
            bar.valueTwo = currentValTwo;
        }
    }

    public float MaxVal
    {
        get
        {
            return maxVal;
        }

        set
        {
            this.maxVal = value;
            bar.MaxValue = maxVal;
        }
    }

    public float MaxValTwo
    {
        get
        {
            return maxValTwo;
        }

        set
        {
            this.maxValTwo = value;
            bar.MaxValueTwo = maxValTwo;
        }
    }

    public void Initialize()
    {
        this.MaxVal = maxVal;
        this.MaxValTwo = maxValTwo;
        this.CurrentVal = currentVal;
        this.CurrentValTwo = currentVal;
    }
}
