using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player
{
    private Stat health;
    
    public float Timer = 0.8f;
    public bool checkIfDead = false;

    private Camera Cam1;
    private Camera Cam2;
    int i;
    public float Cooldown = 5;
    public float CooldownTimer = 5;
    float Running;
    float Wait;

    // Use this for initialization
    public void Init ()
    {
        health = new Stat();
        health.Initialize();
        Cam1 = Camera.main;
        Cam2 = GameObject.FindGameObjectWithTag("SecondCamera").GetComponentInChildren<Camera>();
        Cam1.enabled = true;
        Cam2.enabled = false;
    }
	
	// Update is called once per frame
	public void PlayerUpdate (PlayerBlackboard PBB)
    {
        health.StatUpdate(PBB);
        if (PBB.currentValHealth <= 0)
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
            PBB.currentValHealth -= 10f;
        }

        if(PBB.currentValHealth > PBB.currentValTwoHealth)
        {
            PBB.currentValTwoHealth = PBB.currentValHealth;
        }

        if (PBB.currentValHealth < PBB.currentValTwoHealth)
        {
            waitAndDecreaseHealth(PBB);
        }

        if (PBB.currentValHealth == PBB.currentValTwoHealth)
        {
            Timer = 0.8f;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            PBB.currentValHealth += 10;
        }

        if (checkIfDead == true)
        {
            Respawn();
        }
    }

    private void waitAndDecreaseHealth(PlayerBlackboard PBB)
    {
        Timer -= Time.deltaTime;
        if(Timer < 0f)
        {
            PBB.currentValTwoHealth -= 40 * Time.deltaTime;
        }

    }

    public void Respawn()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            health.CurrentValHealth = 100;
            checkIfDead = false;
        }
    }

    public void Dead()
    {
        checkIfDead = true;
    }

    public void IncreaseHealth(float healthAmount, PlayerBlackboard PBB)
    {
        PBB.currentValHealth += healthAmount;
    }
}
