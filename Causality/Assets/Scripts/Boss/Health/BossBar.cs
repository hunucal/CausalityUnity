using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBar : MonoBehaviour
{
    private float fillAmountBossHealth;
    private float fillAmountBossTwoHealth;

    [SerializeField]
    private Image contentBossHealth;
    [SerializeField]
    private Image contentBossTwoHealth;

    public float MaxBossValueHealth { get; set; }

    public void BarUpdate(BossMainScript BMS)
    {
        //fillAmountBossHealth = BMS.GetBossHealthVal();
        //fillAmountBossTwoHealth = BMS.GetBossTwoHealthVal();
        //MaxBossValueHealth = BMS.GetMaxBossValueHealth();
        
    }

    public float valueBossHealth
    {
        set
        {
            fillAmountBossHealth = Map(value, 0, MaxBossValueHealth, 0, 1);
        }
    }

    public float valueBossTwoHealth
    {
        set
        {
            fillAmountBossTwoHealth = Map(value, 0, MaxBossValueHealth, 0, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        BarUpdate(GameObject.FindGameObjectWithTag("Boss").GetComponent<BossMainScript>());
        HandleBar();
    }

    private void HandleBar()
    {
        if (fillAmountBossHealth != contentBossHealth.fillAmount)
        {
            contentBossHealth.fillAmount = fillAmountBossHealth;
        }

        if (fillAmountBossTwoHealth != contentBossTwoHealth.fillAmount)
        {
            contentBossTwoHealth.fillAmount = fillAmountBossTwoHealth;
        }
    }

    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}
