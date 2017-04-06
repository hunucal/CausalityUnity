using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision2hand : MonoBehaviour
{
    public bool bossHit = false;

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Boss")
        {
            bossHit = true;
        }
    }
    
}
