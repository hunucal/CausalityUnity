using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bravo : MonoBehaviour
{
    [SerializeField]
    private BossStat bossHealth;

    public GameObject BossObject;

    public Text BossDead;
    public Text GoToMenu;

    private IEnumerator coroutine;

    private void Awake()
    {
        bossHealth.Initialize();
    }

    void Start()
    {
        BossDead.text = ("You have slain the boss");
        GoToMenu.text = ("Go back to Menu");

        BossDead.enabled = false;
        GoToMenu.enabled = false;

        BossObject = GameObject.Find("Boss");
    }

    public void Update()
    {
        if (GameObject.Find("Player").GetComponentInChildren<OnCollision2Handed>().bossHit == true && GameObject.Find("Player").GetComponentInChildren<OnCollision2Handed>().HeavyAttack == true)
        {
            bossHealth.CurrentBossValHealth -= 10;
            GameObject.Find("Player").GetComponentInChildren<OnCollision2Handed>().bossHit = false;
            GameObject.Find("Player").GetComponentInChildren<OnCollision2Handed>().HeavyAttack = false;
        }

        if (GameObject.Find("Player").GetComponentInChildren<OnCollision2Handed>().bossHit == true && GameObject.Find("Player").GetComponentInChildren<OnCollision2Handed>().LightAttack == true)
        {
            bossHealth.CurrentBossValHealth -= 5;
            GameObject.Find("Player").GetComponentInChildren<OnCollision2Handed>().bossHit = false;
            GameObject.Find("Player").GetComponentInChildren<OnCollision2Handed>().LightAttack = false;
        }

        if (bossHealth.CurrentBossValHealth > bossHealth.CurrentBossValTwoHealth)
        {
            bossHealth.CurrentBossValTwoHealth = bossHealth.CurrentBossValHealth;
        }

        if (bossHealth.CurrentBossValHealth < bossHealth.CurrentBossValTwoHealth)
        {
            coroutine = waitAndDecrease(0.8f);
            StartCoroutine(coroutine);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            bossHealth.CurrentBossValHealth += 10;
        }

        if(bossHealth.CurrentBossValHealth <= 0)
        {
            bossDead();
            Destroy(BossObject);
        }
    }

    private IEnumerator waitAndDecrease(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        bossHealth.CurrentBossValTwoHealth -= 30 * Time.deltaTime;
    }

    public void bossDead()
    {
        BossDead.enabled = true;
        GoToMenu.enabled = true;
    }

}
