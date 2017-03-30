using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{

    private GameObject bossObjet;
    private GameObject playerObject;

    private float bossAggroRange;

    public void setIdleDate(float aggroRange)
    {
        bossAggroRange = aggroRange;
    }
    public override void Init()
    {
        //set Boss object
        bossObjet = GameObject.FindGameObjectWithTag("Boss");

        //set Player object
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }
    public override bool RunState()
    {
        //Pseudo code
        /*bossObject.runAnimation("Idle")
        Wait for Player to get in range
        change state to aggroState
        */
        if (GetAggroRange())
            return true;
        else
            return false;
    }
    public override void ExitState()
    {
        base.ExitState();
    }
    private bool GetAggroRange()
    {
        float distanceToPlayer = Vector3.Distance(bossObjet.transform.position, playerObject.transform.position);
        if (distanceToPlayer < bossAggroRange)
        {
            return false;
        }
        return true;
    }
}
