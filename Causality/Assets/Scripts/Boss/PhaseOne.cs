using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseOne : State {
    private closeCombatAttackStates bossCCStates;
    private bool commenceAttack;
    private State attackState;
    private StateMachine internalStateMachine;
    private Status status;
    private bool chooseAttack;
    public override Status GetCompletition()
    {
        return this.status;
    }
    public override void Init()
    {
        bossCCStates = new closeCombatAttackStates();
        bossCCStates.InitStates();
        //internal state machine
        internalStateMachine = new StateMachine();

        commenceAttack = true;
        chooseAttack = true;
    }
    public override void RunState()
    {
        if (chooseAttack)
        {
            ChooseAttack();
            chooseAttack = false;
        }
        internalStateMachine.RunState();
        this.status = internalStateMachine.GetCurrentState().GetCompletition();
        if(internalStateMachine.GetCurrentState().GetCompletition() == Status.Done || internalStateMachine.GetCurrentState().GetCompletition() == Status.Failure)
        {
            commenceAttack = true;
            chooseAttack = true;
        }
    }
    public override Status ExitState()
    {
        return Status.Terminated;
    }
    private void ChooseAttack()
    {
        if (commenceAttack)
        {
            
            int randomAttack = 0;
            int precent = Random.Range(0, 100);
            if (precent < 10)
            {
                randomAttack = 0;
                attackState = bossCCStates.GetAttackPool(ListType.CloseCombat)[randomAttack];
                //set attack state
                internalStateMachine.ChangeState(attackState);
                commenceAttack = false;
            }
            else if (precent > 10 && precent < 20)
            {
                randomAttack = 1;
                attackState = bossCCStates.GetAttackPool(ListType.CloseCombat)[randomAttack];
                //set attack state
                internalStateMachine.ChangeState(attackState);
                commenceAttack = false;
            }
            else if (precent > 20 && precent < 40)
            {
                randomAttack = 2;
                attackState = bossCCStates.GetAttackPool(ListType.CloseCombat)[randomAttack];
                //set attack state
                internalStateMachine.ChangeState(attackState);
                commenceAttack = false;
            }
            else if (precent > 40 && precent < 60)
            {
                randomAttack = 3;
                attackState = bossCCStates.GetAttackPool(ListType.CloseCombat)[randomAttack];
                //set attack state
                internalStateMachine.ChangeState(attackState);
                commenceAttack = false;
            }
            else if (precent > 60 && precent < 70)
            {
                randomAttack = 4;
                attackState = bossCCStates.GetAttackPool(ListType.CloseCombat)[randomAttack];
                //set attack state
                internalStateMachine.ChangeState(attackState);
                commenceAttack = false;
            }
            else if (precent > 70 && precent < 80)
            {
                randomAttack = 5;
                attackState = bossCCStates.GetAttackPool(ListType.CloseCombat)[randomAttack];
                //set attack state
                internalStateMachine.ChangeState(attackState);
                commenceAttack = false;
            }
            else if (precent > 80 && precent < 90)
            {
                randomAttack = 6;
                attackState = bossCCStates.GetAttackPool(ListType.CloseCombat)[randomAttack];
                //set attack state
                internalStateMachine.ChangeState(attackState);
                commenceAttack = false;
            }
            else if (precent > 90 && precent <= 100)
            {
                randomAttack = 7;
                attackState = bossCCStates.GetAttackPool(ListType.CloseCombat)[randomAttack];
                //set attack state
                internalStateMachine.ChangeState(attackState);
                commenceAttack = false;
            }
        }
        if (UnityEngine.UnassignedReferenceException.Equals(attackState, null))
            this.status = Status.Failure;
    }
}
