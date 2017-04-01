using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeChooseAttack : Node {
    private closeCombatAttackStates bossCCStates;
    private bool commenceAttack;

    private StateMachine internalStateMachine;
    public void Init()
    {
        //create states
        bossCCStates = new closeCombatAttackStates();

        //internal state machine
        internalStateMachine = new StateMachine();

        commenceAttack = false;
    }
    public override Status Running()
    {
        if (StartAttack(ChooseAttack()))
            return Status.Success;

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
