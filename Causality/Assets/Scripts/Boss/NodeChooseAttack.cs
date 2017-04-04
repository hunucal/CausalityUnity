using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class NodeChooseAttack : Node {
    private closeCombatAttackStates bossCCStates;
    private bool commenceAttack;

    private StateMachine internalStateMachine;
    public void Init()
    {
        //create states
        bossCCStates = new closeCombatAttackStates();
        bossCCStates.InitStates();
        //internal state machine
        internalStateMachine = new StateMachine();

        commenceAttack = true;
    }
    public override Status Tick()
    {
        Status status = StartAttack(ChooseAttack());

        switch (status)
        {
            case Status.Success:
                {
                    commenceAttack = true;
                    return Status.Success;
                }
            case Status.Failure:
                {
                    commenceAttack = true;
                    return Status.Failure;
                }
            case Status.Running:
                break;
            case Status.Terminated:
                break;
            default:               
                break;
        }
        return Status.Running;
    }
    private State ChooseAttack()
    {
        State attackState = null;

        if (commenceAttack)
        {
            //debug
            attackState = bossCCStates.GetAttackPool(ListType.CloseCombat).First();
            internalStateMachine.ChangeState(attackState);
            commenceAttack = false;
            //int randomAttack = 0;
            //int precent = Random.Range(0, 100);
            //if(precent < 10)
            //{
            //    randomAttack = 0;
            //    attackState = bossCCStates.GetAttackPool(ListType.CloseCombat)[randomAttack];
            //    //set attack state
            //    internalStateMachine.ChangeState(attackState);
            //    commenceAttack = false;
            //}
            //else if(precent > 10 && precent < 20)
            //{
            //    randomAttack = 1;
            //    attackState = bossCCStates.GetAttackPool(ListType.CloseCombat)[randomAttack];
            //    //set attack state
            //    internalStateMachine.ChangeState(attackState);
            //    commenceAttack = false;
            //}
            //else if(precent > 20  && precent < 40)
            //{
            //    randomAttack = 2;
            //    attackState = bossCCStates.GetAttackPool(ListType.CloseCombat)[randomAttack];
            //    //set attack state
            //    internalStateMachine.ChangeState(attackState);
            //    commenceAttack = false;
            //}
            //else if (precent > 40 && precent < 60)
            //{
            //    randomAttack = 3;
            //    attackState = bossCCStates.GetAttackPool(ListType.CloseCombat)[randomAttack];
            //    //set attack state
            //    internalStateMachine.ChangeState(attackState);
            //    commenceAttack = false;
            //}
            //else if (precent > 60 && precent < 70)
            //{
            //    randomAttack = 4;
            //    attackState = bossCCStates.GetAttackPool(ListType.CloseCombat)[randomAttack];
            //    //set attack state
            //    internalStateMachine.ChangeState(attackState);
            //    commenceAttack = false;
            //}
            //else if (precent > 70 && precent < 80)
            //{
            //    randomAttack = 5;
            //    attackState = bossCCStates.GetAttackPool(ListType.CloseCombat)[randomAttack];
            //    //set attack state
            //    internalStateMachine.ChangeState(attackState);
            //    commenceAttack = false;
            //}
            //else if (precent > 80 && precent < 90)
            //{
            //    randomAttack = 6;
            //    attackState = bossCCStates.GetAttackPool(ListType.CloseCombat)[randomAttack];
            //    //set attack state
            //    internalStateMachine.ChangeState(attackState);
            //    commenceAttack = false;
            //}
            //else if (precent > 90 && precent <= 100)
            //{
            //    randomAttack = 7;
            //    attackState = bossCCStates.GetAttackPool(ListType.CloseCombat)[randomAttack];
            //    //set attack state
            //    internalStateMachine.ChangeState(attackState);
            //    commenceAttack = false;
            //}
        }
        if (!UnityEngine.UnassignedReferenceException.Equals(attackState, null))
            return attackState;
        else
            return null;
    }
    private Status StartAttack(State state)
    {
        Status status = internalStateMachine.RunState();
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
