using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision2Handed : MonoBehaviour
{

    public bool bossHit = false;

    public bool HeavyAttack = false;
    public bool LightAttack = false;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Boss")
        {
            bossHit = true;
        }
    }

    void Update()
    {
        //if()
        //{
        //    HeavyAttack = true;
        //}

        //if ()
        //{
        //    LightAttack = true;
        //}
    }

}
