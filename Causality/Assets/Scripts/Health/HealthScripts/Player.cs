using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Stat health;

    public Text DeadText;
    public Text RespawnText;

    private IEnumerator playerCoroutine;
    
    public float Timer = 0;
    public bool checkIfDead = false;

    public Camera Cam1;
    public Camera Cam2;
    int i;
    public float Cooldown = 5;
    public float CooldownTimer = 5;
    float Running;
    float Wait;

    // Use this for initialization
    void Start ()
    {
        DeadText.text = ("You are Dead");
        RespawnText.text = ("Press space to respawn");

        DeadText.enabled = false;
        RespawnText.enabled = false;

        Cam1.enabled = true;
        Cam2.enabled = false;
    }

    private void Awake()
    {
        health.Initialize();
    }
	
	// Update is called once per frame
	public void Update ()
    {
        if (health.CurrentValHealth <= 0)
        {
            Dead();
        }

        //Kollar om 1:a kameran körs och om cooldown är mindre än 5.Stämmer båda så väntar den i 5 sec innan den börjar rechargea.
        if (Running == 0 && Cooldown < CooldownTimer)
        {
            //StartCoroutine("Test");

            Wait += Time.deltaTime;
            if (Wait > 5)
            {
                Cooldown += Time.deltaTime;
            }
        }


        if (Input.GetKeyDown(KeyCode.D))
        {
            Running = 1;
            i++;
        }

        //startar den andra kameran.
        if (Running == 1 && i == 1)
        {
            Wait = 0;
            Cam1.enabled = false;
            Cam2.enabled = true;
            Cooldown -= Time.deltaTime;

            //kollar om Cooldown är på 0 och byter kamera och startar Wait delen i koden.
            if (Cooldown < 0)
            {
                Cooldown = 0;
                Running = 0;
                i = 0;
                Cam1.enabled = true;
                Cam2.enabled = false;
            }
        }

        // byter till kamera 1 om space blir nedtryckt två gånger efter varandra.
        if (Input.GetKeyDown(KeyCode.D) && i == 2)
        {
            Cam1.enabled = true;
            Cam2.enabled = false;
            Running = 0;
            i = 0;
        }


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
            playerCoroutine = waitAndDecrease(0.8f);
            StartCoroutine(playerCoroutine);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            health.CurrentValHealth += 10;
        }

        if (checkIfDead == true)
        {
            RespawnText.enabled = true;
            Respawn();
        }
    }

    private IEnumerator waitAndDecrease(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        health.CurrentValTwoHealth -= 40 * Time.deltaTime;
    }

    public void Respawn()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            DeadText.enabled = false;
            RespawnText.enabled = false;
            health.CurrentValHealth = 100;
            checkIfDead = false;
        }
    }

    public void Dead()
    {
        DeadText.enabled = true;
        checkIfDead = true;
    }

    public void IncreaseHealth(float healthAmount)
    {
        health.CurrentValHealth += healthAmount;
    }
}
