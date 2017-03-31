using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafNodeIdle : Node {
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
    public override Status Running()
    {
        if (GetAggroRange())
            return Status.Success;

        return Status.Terminated;
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
