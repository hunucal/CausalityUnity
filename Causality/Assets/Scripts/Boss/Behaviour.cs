using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behaviour : MonoBehaviour {
    private StateMachine finiteStateMachine;
	// Use this for initialization
	void Start () {
        finiteStateMachine = new StateMachine();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
