using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecoratorNodeCheckDist : CompositeNode {

    public void initDistCheck(Blackboard bb, string name)
    {
        InitCompositeNode(bb, name);
    }
    public override void DoAction()
    {
        if (Vector3.Distance(this.blackboard.agent.transform.position, this.blackboard.closestEnemyCursor.transform.position) < 2f)
            CompletedWithStatus(Status.Done);
        else if(Vector3.Distance(this.blackboard.agent.transform.position, this.blackboard.closestEnemyCursor.transform.position) > 2f)
            CompletedWithStatus(Status.Running);
        if (UnityEngine.UnassignedReferenceException.Equals(this.blackboard.agent, null))
            CompletedWithStatus(Status.Failure);
    }
}
