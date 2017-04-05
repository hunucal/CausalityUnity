using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseOne : State {
    private closeCombatAttackStates bossCCStates;
    private bool commenceAttack;

    private StateMachine internalStateMachine;
    public override void Init()
    {
        bossCCStates = new closeCombatAttackStates();

        //internal state machine
        internalStateMachine = new StateMachine();

        commenceAttack = false;
    }
    public override Status RunState()
    {
        return StartAttack(ChooseAttack());
    }
    public override Status ExitState()
    {
        return Status.Terminated;
    }
    private State ChooseAttack()
    {
        State attackState = null;

        if (commenceAttack)
        {
            attackState = bossCCStates.GetAttackPool(ListType.CloseCombat)[Random.Range(0, bossCCStates.GetAttackPool(ListType.CloseCombat).Count)];
            //set attack state
            internalStateMachine.ChangeState(attackState);
            commenceAttack = false;
        }
        if (!UnityEngine.UnassignedReferenceException.Equals(attackState, null))
            return attackState;
        else
            return null;
    }
    private Status StartAttack(State state)
    {
        if (internalStateMachine.RunState() == Status.Failure)
        {
            commenceAttack = true;
            return Status.Failure;
        }
        else if (internalStateMachine.RunState() == Status.Running)
            return Status.Running;
        else
            return Status.Success;

    }
}
