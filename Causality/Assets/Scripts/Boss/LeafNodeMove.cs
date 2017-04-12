using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LeafNodeMove : CompositeNode {

    //private variables
    private Transform goal;
    //bools
    public void InitMove(Blackboard bb, string name)
    {
        InitCompositeNode(bb, name);      

    }
    public override void DoAction()
    {
        // set nav mesh goal to be that of the player transform
        Vector3 targetPos = this.blackboard.closestEnemyCursor.transform.position;
        goal = this.blackboard.closestEnemyCursor.transform;
        Walktowards(targetPos);
    }

    private void Walktowards(Vector3 target)
    {
        this.blackboard.agent.speed = this.blackboard.movespeed;
        Vector3 directionVector = this.blackboard.agent.transform.position - this.blackboard.closestEnemyCursor.transform.position;
         
        //boss.change_animation == walking

        if (directionVector != Vector3.zero)
        {
            Vector3 targetDir = this.blackboard.agent.transform.position - target;
            targetDir.y = 0f;
            
            Vector3 newDir = Vector3.RotateTowards(this.blackboard.Boss.transform.forward, targetDir, this.blackboard.rotationSpeed * Time.deltaTime, 0.0f);
            this.blackboard.agent.transform.rotation = Quaternion.LookRotation(newDir);

            //agent.transform.LookAt(targetDir); // lookat direction == vector direction boss -> player

            this.blackboard.agent.updateRotation = true;
        }
        if (!Mathf.Equals(this.blackboard.agent.transform.position, target))
        {
            // nav mesh pathfinding goal set to player position
            this.blackboard.agent.destination = goal.position;
            CompletedWithStatus(Status.Running);
        }
        //if agents pathstatus is complete and player is within distance. return true for attack state 
        if (Vector3.Distance(this.blackboard.agent.transform.position, this.blackboard.closestEnemyCursor.transform.position) < 2.5f)
        {
            CompletedWithStatus(Status.Done);
        }

        if (this.blackboard.agent.pathStatus.Equals(NavMeshPathStatus.PathInvalid))
            CompletedWithStatus(Status.Failure);
    }
}
