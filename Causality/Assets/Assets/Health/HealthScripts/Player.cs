using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Stat health;

    private IEnumerator coroutine;

	// Use this for initialization
	void Start ()
    {
		
	}

    private void Awake()
    {
        health.Initialize();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            health.CurrentValHealth -= 50;
        }

        if(health.CurrentValHealth > health.CurrentValTwoHealth)
        {
            health.CurrentValTwoHealth = health.CurrentValHealth;
        }

        if (health.CurrentValHealth < health.CurrentValTwoHealth)
        {
            coroutine = waitAndDecrease(0.8f);
            StartCoroutine(coroutine);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            health.CurrentValHealth += 10;
        }
    }

    private IEnumerator waitAndDecrease(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        health.CurrentValTwoHealth -= 40 * Time.deltaTime;
    }
}
