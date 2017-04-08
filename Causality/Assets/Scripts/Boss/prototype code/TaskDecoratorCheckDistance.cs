using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TaskDecoratorCheckDistance : LeafTask {

    private NavMeshAgent agent;
    private GameObject target;
    private float targetDist;
    public void InitDist(Blackboard bb, float aggroRange)
    {
        this.agent = bb.agent;
        this.target = bb.closestEnemyCursor;
        this.targetDist = aggroRange;
    }
    public override bool CheckConditions()
    {
        return UnityEngine.UnassignedReferenceException.Equals(agent, null);
    }
    public override void DoAction()
    {
        if (Vector3.Distance(agent.transform.position, target.transform.position) < this.targetDist)
            GetController().FinishedWithSucess();
    }
    public override void End()
    {
        GetController().Done();
    }
}
