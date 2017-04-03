using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BarScript : MonoBehaviour {

    [SerializeField]
    private float fillAmount;
    [SerializeField]
    private float fillAmountTwo;
    [SerializeField]
    private Image content;
    [SerializeField]
    private Image contentTwo;

    public float MaxValue { get; set; }
    public float MaxValueTwo { get; set; }


    public float value
    {
        set
        {
            fillAmount = Map(value, 0, MaxValue, 0, 1);
        }
    }

    public float valueTwo
    {
        set
        {
            fillAmountTwo = Map(value, 0, MaxValueTwo, 0, 1);
        }
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        HandleBar();
	}

    private void HandleBar()
    {
        if(fillAmount != content.fillAmount)
        {
            content.fillAmount = fillAmount;
        }

        if (fillAmountTwo != contentTwo.fillAmount)
        {
            contentTwo.fillAmount = fillAmountTwo;
        }
    }

    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}
