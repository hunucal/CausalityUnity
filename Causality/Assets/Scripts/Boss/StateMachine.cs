using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour {
    private State currentState;
    private State lastState;
    // Use this for initialization
    void Start () {
        currentState = new State();
        lastState = new State();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeState(State stateToChange)
    {
        if (currentState != null)
            currentState.ExitState();
        lastState = currentState;
        currentState = stateToChange;
    }
    public void RunningState()
    {
        if (currentState != null)
            currentState.RunState();
    }
}
