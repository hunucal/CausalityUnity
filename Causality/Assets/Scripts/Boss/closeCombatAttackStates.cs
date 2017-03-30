using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class LightAttack : State
{
    public override void Init()
    {
        base.Init();
    }
    public override bool RunState()
    {
        if (Attack())
            return true;
        else
            return false;
    }
    public override void ExitState()
    {
        base.ExitState();
    }
    private bool Attack()
    {
        return true;
    }
}

public enum ListType
{
    CloseCombat, 
    Ranged
};
public class closeCombatAttackStates : MonoBehaviour
{
    private List<State> AttackPool;
    private LightAttack attackOne;
    // Use this for initialization
    void Start () {
		AttackPool = new List<State>();

        //create states
        attackOne = new LightAttack();
    }
	public void InitStates()
    {
        //init state after creation
        attackOne.Init();
        AttackPool.Add(attackOne);
    }

    public List<State> GetAttackPool(ListType type)
    {
        if (type == ListType.CloseCombat)
            return AttackPool;
        else
            return null;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
