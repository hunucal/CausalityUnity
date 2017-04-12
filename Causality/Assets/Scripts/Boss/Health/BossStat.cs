using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BossStat
{
    private BossBar bar;
    private float maxBossValHealth;
    private float maxBossValTwoHealth;
    private float currentBossValHealth;
    private float currentBossValTwoHealth;

    public BossStat()
    {
        bar = new BossBar();
    }

    public void StatUpdate(Blackboard bb)
    {
        maxBossValHealth = bb.maxBossValHealth;
        maxBossValTwoHealth = bb.maxBossValTwoHealth;
        currentBossValHealth = bb.currentBossValHealth;
        currentBossValTwoHealth = bb.currentBossValHealth;
    }
  
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
