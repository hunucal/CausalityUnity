using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LeafTaskMove : LeafTask {
    private Vector3 target;
    private bool shouldMove;
    private GameObject player;
    NavMeshAgent agent;
    public void InitMove(Blackboard bb)
    {
        InitLeafTask(bb);
        this.shouldMove = false;        
    }
    public override void DoAction()
    {
        if(!shouldMove)
        {
            GetControler().Started();
            //set player data for blackboard
            this.player = GameObject.FindGameObjectWithTag("Player");
            bb.closestEnemyCursor = this.player;
            this.target = bb.closestEnemyCursor.transform.position;

            //set navmesh agent data for blackboard
            agent = GameObject.FindGameObjectWithTag("Player").GetComponent<NavMeshAgent>();
            this.agent = bb.agent;

            //set goal destination and initiate move towards goal
            this.agent.SetDestination(this.target);
            if(this.agent.pathStatus.Equals(NavMeshPathStatus.PathInvalid))
            {
                this.agent.ResetPath();
                this.agent.autoRepath = true;
            }
            else if(this.agent.pathStatus.Equals(NavMeshPathStatus.PathComplete))
            {
                this.shouldMove = true;
            }
        }
        else if(shouldMove)
        {
            if(this.agent.transform.position.Equals(this.target))
            {
                bb.agent = this.agent;
                GetControler().FinishedWithSucess();
            }
        }
    }
    public override bool CheckConditions()
    {
        return UnityEngine.UnassignedReferenceException.Equals(agent, null);
    }
    public override void End()
    {
        GetControler().Done();
    }
    public override void Start()
    {
        GetControler().Started();
    }
}
