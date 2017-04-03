using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dimension : MonoBehaviour
{

    public Camera Cam1;
    public Camera Cam2;
    int i;
    public float Cooldown = 5;
    public float CooldownTimer = 5;
    float Running;
    float Wait;

    // Use this for initialization
    void Start()
    {
        Cam1.enabled = true;
        Cam2.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {

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


        if (Input.GetKeyDown(KeyCode.Space))
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
        if (Input.GetKeyDown(KeyCode.Space) && i == 2)
        {
            Cam1.enabled = true;
            Cam2.enabled = false;
            Running = 0;
            i = 0;
        }
    }
}
