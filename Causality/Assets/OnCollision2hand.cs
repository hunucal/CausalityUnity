using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision2hand : MonoBehaviour
{
    GameObject player;
    Animator anim;
    public bool bossHit = false;
    [SerializeField]
    private Stat health;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = player.GetComponent<Animator>();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Boss")
        {
            bossHit = true;
            if (anim.GetBool("Block"))
            {
                print("test");
                health.CurrentValHealth -= 0;
            }
            else
                health.CurrentValHealth -= 50;
        }
    }
}
