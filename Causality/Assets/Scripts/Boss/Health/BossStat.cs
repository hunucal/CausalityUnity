using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class BossStat
{
    [SerializeField]
    private BossBar bar;
    [SerializeField]
    private float maxBossValHealth;
    [SerializeField]
    private float maxBossValTwoHealth;
    [SerializeField]
    private float currentBossValHealth;
    [SerializeField]
    private float currentBossValTwoHealth;
  
    public float CurrentBossValHealth
    {
        get
        {
            return currentBossValHealth;
        }

        set
        {
            this.currentBossValHealth = value;
            bar.valueBossHealth = currentBossValHealth;
        }
    }

    public float CurrentBossValTwoHealth
    {
        get
        {
            return currentBossValTwoHealth;
        }

        set
        {
            this.currentBossValTwoHealth = value;
            bar.valueBossTwoHealth = currentBossValTwoHealth;
        }
    }

    public float MaxBossValHealth
    {
        get
        {
            return maxBossValHealth;
        }

        set
        {
            this.maxBossValHealth = value;
            bar.MaxBossValueHealth = maxBossValHealth;
        }
    }

    public float MaxBossValTwoHealth
    {
        get
        {
            return maxBossValTwoHealth;
        }

        set
        {
            this.maxBossValTwoHealth = value;
        }
    }

    public void Initialize()
    {
        this.MaxBossValHealth = maxBossValHealth;
        this.MaxBossValTwoHealth = maxBossValTwoHealth;
        this.CurrentBossValHealth = currentBossValHealth;
        this.CurrentBossValTwoHealth = currentBossValHealth;
    }
}
