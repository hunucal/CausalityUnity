using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BarScript : MonoBehaviour
{
    private float fillAmountHealth;
    private float fillAmountTwoHealth;
    [SerializeField]
    private Image contentHealth;
    [SerializeField]
    private Image contentTwoHealth;
    
    private float fillAmountStamina;
    [SerializeField]
    private Image contentStamina;

    public float MaxValueHealth { get; set; }
    public float MaxValueStamina { get; set; }

    public void BarUpdate(ScriptManager PBB)
    {
        fillAmountHealth = PBB.GetHealthVal();
        fillAmountTwoHealth = PBB.GetTwoHealthVal();
        fillAmountStamina = PBB.GetStaminaVal();
    }

    public float valueHealth
    {
        set
        {
            fillAmountHealth = Map(value, 0, MaxValueHealth, 0, 1);
        }
    }

    public float valueTwoHealth
    {
        set
        {
            fillAmountTwoHealth = Map(value, 0, MaxValueHealth, 0, 1);
        }
    }

    public float valueStamina
    {
        set
        {
            fillAmountStamina = Map(value, 0, MaxValueStamina, 0, 1);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        BarUpdate(GameObject.FindGameObjectWithTag("Player").GetComponent<ScriptManager>());
        HandleBar();
	}

    private void HandleBar()
    {
        if (fillAmountHealth != contentHealth.fillAmount)
        {
            contentHealth.fillAmount = fillAmountHealth;
        }

        if (fillAmountTwoHealth != contentTwoHealth.fillAmount)
        {
            contentTwoHealth.fillAmount = fillAmountTwoHealth;
        }

        if (fillAmountStamina != contentStamina.fillAmount)
        {
            contentStamina.fillAmount = fillAmountStamina;
        }
    }

    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}
