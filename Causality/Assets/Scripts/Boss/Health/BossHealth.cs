using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth
{
    private BossStat bossHealth;

    public GameObject BossObject;
    public GameObject PlayerObject;
    public GameObject BossBar;

    public float timer = 0.8f;

    public void Init()
    {
        bossHealth = new BossStat();
        bossHealth.Initialize();
    }

    void Start()
    {
        BossObject = GameObject.FindWithTag("Boss");
        PlayerObject = GameObject.FindWithTag("Player");

        if (BossBar == null)
            Debug.Log("BossBar is missing a gameobject.");

    }

    public void BossUpdate(Blackboard bb)
    {
        bossHealth.StatUpdate(bb);
        if (Vector3.Distance(PlayerObject.transform.position, BossObject.transform.position) < 5)
        {
            BossBar.SetActive(true);
        }

        if (Vector3.Distance(PlayerObject.transform.position, BossObject.transform.position) > 5)
        {
            BossBar.SetActive(false);
        }

        if (PlayerObject.GetComponentInChildren<OnCollision2Handed>().bossHit == true && PlayerObject.GetComponentInChildren<OnCollision2Handed>().HeavyAttack == true)
        {
            bossHealth.CurrentBossValHealth -= 10;
            PlayerObject.GetComponentInChildren<OnCollision2Handed>().bossHit = false;
            PlayerObject.GetComponentInChildren<OnCollision2Handed>().HeavyAttack = false;
            PlayerObject.GetComponentInChildren<AudioSource>().Play();
        }

        if (PlayerObject.GetComponentInChildren<OnCollision2Handed>().bossHit == true && PlayerObject.GetComponentInChildren<OnCollision2Handed>().LightAttack == true)
        {
            bossHealth.CurrentBossValHealth -= 5;
            PlayerObject.GetComponentInChildren<OnCollision2Handed>().bossHit = false;
            PlayerObject.GetComponentInChildren<OnCollision2Handed>().LightAttack = false;
        }

        //if (bb.currentBossValHealth > bb.currentBossValTwoHealth)
        //{
        //    bb.currentBossValTwoHealth = bb.currentBossValHealth;
        //}

        //if (bb.currentBossValHealth < bb.currentBossValTwoHealth)
        //{
        //    waitAndDecrease(bb);
        //}

        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    bb.currentBossValHealth += 10;
        //}
    }

    private void waitAndDecrease(Blackboard bb)
    {
        //timer -= Time.deltaTime;
        //if(timer < 0f)
        //{
        //bb.currentBossValTwoHealth -= 40 * Time.deltaTime;
        //}
    }

}
