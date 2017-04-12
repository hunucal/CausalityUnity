using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Blackboard {
    /**
    *navmesh agent for boss
    */
    public NavMeshAgent agent;
    /**
	 * Reference to the game map
	 */
    public static NavMesh map;

    /**
	 * Closest enemy cursor
	 */
    public GameObject closestEnemyCursor;

    /**
	 * Direction vector to move in
	 */
    public Vector3 moveDirection;

    /**
	 * Destination point to arrive at
	 */
    public Vector3 destination;

    /**
	 * Path of positions to move to
	 */
    public NavMeshPath path;

    /**
	 * Reference to the owner player
	 */
    public GameObject Boss;

    /**
	 * Creates a new instance of the Blackboard class
	 */
    /**
    *movespeed for boss
   */
    public float movespeed;
    public float aggroRange;
    public float rotationSpeed;
    public Vector3 velocity;
    public float healthValue;
    public Blackboard()
    {
        this.moveDirection = new Vector3();
        this.destination = new Vector3();
        this.path = new NavMeshPath();
    }

}
