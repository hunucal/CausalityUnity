using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour {
    private GameObject Player;
    public Vector3 directionVector;
    public Vector3 velocityVector;
    public float distanceFromTarget;

    private float heightDampening;
    private float rotationDampening;
    private float rotationCurrent;
    private float rotationWanted;
    private float heightWanted;
    private float heightCurrent;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void LateUpdate()
    {
        if (!gameObject)
            return;

        rotationWanted = Player.transform.eulerAngles.y;
        heightWanted = Player.transform.position.y + heightCurrent;
        rotationCurrent = Player.transform.eulerAngles.y;
        heightCurrent = transform.position.y;
    }
}
