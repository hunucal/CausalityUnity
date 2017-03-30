using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class BossMainScript : MonoBehaviour {
    private StateMachine finiteStateMachine;

    private moveState bossMovingState;
    private IdleState bossIdleState;

    private State lastState;

    private bool initState;
    private bool stateChange;
    private bool runState;

    [SerializeField]private float bossMoveSpeed;
    [SerializeField]private float bossRotationSpeed;


	// Use this for initialization
	void Start () {
        //state machine
        finiteStateMachine = new StateMachine();

        //states
        bossMovingState = new moveState();
        bossIdleState = new IdleState();


        //bools
        initState = true;
        stateChange = false;
        runState = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(initState)
        {
            //move state data
            bossMovingState.setMovementDate(bossMoveSpeed, bossRotationSpeed);
            bossMovingState.Init();

            //idle state data
            bossIdleState.setIdleDate(6f);
            bossIdleState.Init();

            //logic variables
            stateChange = true;
            initState = false;
        }
        if (stateChange)
        {
            // check if last state does not equal null
            if (!UnityEngine.UnassignedReferenceException.ReferenceEquals(lastState, null)) 
            {
                if (lastState == bossIdleState)
                    finiteStateMachine.ChangeState(bossMovingState);
                else if (lastState == bossMovingState)
                    finiteStateMachine.ChangeState(bossIdleState);
            }
            // if laststate is null set state to idle

            else if (UnityEngine.UnassignedReferenceException.ReferenceEquals(lastState, null)) 
            {
                finiteStateMachine.ChangeState(bossIdleState);
            }
            runState = true;
            stateChange = false;
        }
        if(runState)
        {
            if(!finiteStateMachine.RunState())
            {
                lastState = finiteStateMachine.GetCurrentState();
                runState = false;
                initState = true;
                stateChange = false;
            }
        }

	}
}
