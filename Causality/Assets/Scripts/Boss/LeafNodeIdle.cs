using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafNodeIdle : CompositeNode {
    private GameObject bossObjet;
    private GameObject playerObject;

    private float bossAggroRange;
    public void InitIdle(Blackboard bb, string name)
    {
        InitCompositeNode(bb, name);
        //boss aggro range
        bossAggroRange = bb.aggroRange;

        //set Boss object
        bossObjet = GameObject.FindGameObjectWithTag("Boss");

        //set Player object
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }
    public override void DoAction()
    {
        GetAggroRange();
    }
    private void GetAggroRange()
    {

        if (Vector3.Distance(this.blackboard.agent.transform.position, this.blackboard.closestEnemyCursor.transform.position) > this.blackboard.aggroRange)
        {
            CompletedWithStatus(Status.Running);
        }
        else if (Vector3.Distance(this.blackboard.agent.transform.position, this.blackboard.closestEnemyCursor.transform.position) < this.blackboard.aggroRange)
        {
            CompletedWithStatus(Status.Done);
        }
        else if (UnityEngine.UnassignedReferenceException.Equals(this.blackboard.agent, null))
        {
            CompletedWithStatus(Status.Failure);
        }
        else
            CompletedWithStatus(Status.Success);
    }
}
