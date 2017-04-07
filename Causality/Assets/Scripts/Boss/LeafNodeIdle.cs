using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafNodeIdle : CompositeNode {
    private GameObject bossObjet;
    private GameObject playerObject;

    private float bossAggroRange;
    public void Init(float aggroRange)
    {
        //boss aggro range
        bossAggroRange = aggroRange;

        //set Boss object
        bossObjet = GameObject.FindGameObjectWithTag("Boss");

        //set Player object
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }
    public override void DoAction()
    {
        if (GetAggroRange())
            this.CompletedWithStatus(Status.Done);
        else
            this.CompletedWithStatus(Status.Success);
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
