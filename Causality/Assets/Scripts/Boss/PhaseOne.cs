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
    public override bool RunState()
    {
        return base.RunState();
    }
    public override void ExitState()
    {
        base.ExitState();
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
    private bool StartAttack(State state)
    {
        if (!internalStateMachine.RunState())
        {
            commenceAttack = true;
            return false;
        }

        else
            return true;

    }
}
