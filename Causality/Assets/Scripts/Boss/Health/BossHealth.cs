using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    [SerializeField]
    private BossStat bossHealth;

    private IEnumerator coroutine;

    private void Awake()
    {
    }

    public void update()
    {
        if (GameObject.Find("Player").GetComponent<OnCollision2Handed>().bossHit == true)
        {
            bossHealth.CurrentBossValHealth -= 50;
            GameObject.Find("Player").GetComponent<OnCollision2Handed>().bossHit = false;
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
    }

    private IEnumerator waitAndDecrease(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        bossHealth.CurrentBossValTwoHealth -= 40 * Time.deltaTime;
    }

}
