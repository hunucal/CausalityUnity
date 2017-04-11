using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision2Handed : MonoBehaviour
{
    public GameObject Player;

    public bool bossHit = false;

    public bool HeavyAttack = false;
    public bool LightAttack = false;

    private IEnumerator coroutine;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Boss")
        {
            GetComponent<Collider>().enabled = false;
            bossHit = true;
            coroutine = waitToEnableCollider(2.0f);
            StartCoroutine(coroutine);
        }
    }
    


    void Start()
    {
        Player = GameObject.Find("Player");
    }

    public void OnCollisionUpdate(PlayerBlackboard PBB, Actions actions)
    {
        if (actions.hAttack == true)
        {
            HeavyAttack = true;
        }

        if (actions.hAttack == false)
        {
            HeavyAttack = false;
        }

        if (actions.lAttack == true)
        {
            LightAttack = true;
        }

        if (actions.lAttack == false)
        {
            LightAttack = false;
        }
    }

    private IEnumerator waitToEnableCollider(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        GetComponent<Collider>().enabled = true;
    }
}
