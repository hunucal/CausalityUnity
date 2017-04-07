using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LeafNodeMove : CompositeNode {

    //set before run
    private GameObject bossObjet;
    private GameObject playerObject;
    private float movementSpeed;
    private float aggroRange;
    private float bossRotationVelocity;
    //private variables
    private Transform goal;
    private Vector3 directionVector;
    private Vector3 lastPosition;
    private Vector3 currentPosition;
    private NavMeshAgent agent;
    //bools
    private bool chargePlayer;
    public void Init(float moveSpeed, float rotationSpeed)
    {
        bossRotationVelocity = rotationSpeed;
        movementSpeed = moveSpeed;

        //set gameobject to boss
        bossObjet = GameObject.FindGameObjectWithTag("Boss");

        //set Player object
        playerObject = GameObject.FindGameObjectWithTag("Player");

        //set current position
        currentPosition = bossObjet.transform.position;
        lastPosition = currentPosition;

        //set direction vector to face towards player
        directionVector = currentPosition - playerObject.transform.position;
        agent = bossObjet.GetComponent<NavMeshAgent>();

        //bools
        chargePlayer = false;
    }
    public override void DoAction()
    {
        // set nav mesh goal to be that of the player transform
        Vector3 targetPos = playerObject.transform.position;
        goal = playerObject.transform;

        if (Walktowards(targetPos))
            this.CompletedWithStatus(Status.Done);
        else
            this.CompletedWithStatus(Status.Success);
    }

    private bool Walktowards(Vector3 target)
    {
        agent.speed = movementSpeed;
        directionVector = currentPosition - lastPosition;

        //boss.change_animation == walking

        if (directionVector != Vector3.zero)
        {
            Vector3 targetDir = agent.transform.position - target;
            targetDir.y = 0f;
            
            Vector3 newDir = Vector3.RotateTowards(bossObjet.transform.forward, targetDir, bossRotationVelocity * Time.deltaTime, 0.0f);
            agent.transform.rotation = Quaternion.LookRotation(newDir);

            //agent.transform.LookAt(targetDir); // lookat direction == vector direction boss -> player

            agent.updateRotation = true;
        }
        if (!Mathf.Equals(currentPosition, target))
        {
            lastPosition = currentPosition;

            // nav mesh pathfinding goal set to player position
            agent.destination = goal.position;

            currentPosition = agent.transform.position;
            //if agents pathstatus is complete and player is within distance. return true for attack state 
            if (Vector3.Distance(agent.transform.position, goal.position) < 2f)
            {
                    return true;
            }
        }
        return false;
    }
    private bool ChargeTowards(Vector3 target)
    {
        agent.speed = movementSpeed * 2;
        if (!chargePlayer)
        {
            directionVector = currentPosition - lastPosition;
            if (directionVector != Vector3.zero)
            {
                //rotate boss object towards player rotation so that it faces the player at all times
                float angle = Vector3.Angle(currentPosition, target);

                Vector3 targetDir = agent.transform.position - target;
                targetDir.y = 0f;

                Vector3 newDir = Vector3.RotateTowards(agent.transform.forward, targetDir, bossRotationVelocity * Time.deltaTime, 0.0f);
                agent.transform.rotation = Quaternion.LookRotation(newDir);

                agent.updateRotation = true;

                //set charge position
                // nav mesh pathfinding goal set to player position
                agent.destination = goal.position;
                currentPosition = agent.transform.position;
                chargePlayer = true;
            }
        }
       if(chargePlayer)
        {
            //boss.change_animation == running
            agent.updateRotation = false;
            if (!Mathf.Equals(currentPosition, target))
            {
                lastPosition = currentPosition;
                currentPosition = bossObjet.transform.position;

                //hack if path is invalid, return false and choose another behaviour
                if (agent.path.status.Equals(NavMeshPathStatus.PathInvalid))
                    return false;

                //if agents pathstatus is complete and player is within distance. return true for attack state behaviour
                if (agent.pathStatus.Equals(NavMeshPathStatus.PathComplete) && Vector3.Distance(agent.transform.position, goal.position) < 1f)
                {
                    agent.updateRotation = true;
                    chargePlayer = false;
                    return true;
                }
            }
        }      
        return false;
    }
}
