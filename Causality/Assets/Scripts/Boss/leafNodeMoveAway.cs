using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class leafNodeMoveAway : Node {
    //set before run
    private GameObject bossObjet;
    private GameObject playerObject;
    private float movementSpeed;
    private float aggroRange;
    private float bossRotationVelocity;
    //private variables
    private Vector3 goal;
    private Vector3 directionVector;
    private Vector3 lastPosition;
    private Vector3 currentPosition;
    private NavMeshAgent agent;
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
    }
    public override Status Running()
    {
        // set nav mesh goal to be that of the player transform
        Vector3 targetPos = playerObject.transform.position;
        Vector3 randomGoal = new Vector3(Random.Range(0, 10), 0, Random.Range(0, 10));
        goal = randomGoal;

        if (Walktowards(targetPos))
            return Status.Success;
        else if (!Walktowards(targetPos))
            return Status.Failure;
        else
            return Status.Running;
    }

    private bool Walktowards(Vector3 target)
    {
        directionVector = currentPosition - lastPosition;
        if (directionVector != Vector3.zero)
        {
            //rotate boss object towards player rotation so that it faces the player at all times
            float angle = Vector3.Angle(currentPosition, target);
            Vector3 targetDir = bossObjet.transform.position - target;
            targetDir.y = 0f;
            Vector3 newDir = Vector3.RotateTowards(bossObjet.transform.forward, targetDir, bossRotationVelocity * Time.deltaTime, 0.0f);
            bossObjet.transform.rotation = Quaternion.LookRotation(newDir);
        }
        if (!Mathf.Equals(currentPosition, target))
        {
            lastPosition = currentPosition;

            // nav mesh pathfinding goal set to player position
            agent.destination = goal;

            currentPosition = bossObjet.transform.position;
            //if agents pathstatus is complete and player is within distance. return true for attack state 
            if (agent.pathStatus.Equals(NavMeshPathStatus.PathComplete))
            {
                if (Vector3.Distance(agent.transform.position, goal) < 1f)
                    return true;
            }
        }
            return false;
    }
}
