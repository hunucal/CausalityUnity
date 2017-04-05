using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine {
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
    public Status RunState()
    {
        if (UnityEngine.UnassignedReferenceException.Equals(currentState, null))
        {
            return Status.Failure;
        }
        else
        {
            Status status = currentState.RunState();
            switch (status)
            {
                case Status.Success:
                    return Status.Success;
                case Status.Failure:
                    return Status.Failure;
                case Status.Running:
                    return Status.Running;
                case Status.Terminated:
                    return Status.Terminated;
                default:
                    break;
            }
            return Status.Failure;
        }
    }
    public State GetCurrentState()
    {
        return currentState;
    }
}
