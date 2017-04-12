using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class NodeChooseAttack : CompositeNode {
    private PhaseOne bossCCStates;
    public void InitAttack(Blackboard bb, string name)
    {
        //create states
        bossCCStates = new PhaseOne();
        bossCCStates.Init();
        InitCompositeNode(bb, name);

    }
    public override void DoAction()
    {
        bossCCStates.RunState();
        CompletedWithStatus(bossCCStates.GetCompletition());
    }
}
