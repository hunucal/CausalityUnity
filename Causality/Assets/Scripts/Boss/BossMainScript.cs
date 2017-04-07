using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class BossMainScript : MonoBehaviour {
        [Header("Boss movement settings")]
    [SerializeField]private float bossMoveSpeed;
    [SerializeField]private float bossRotationSpeed;
    [SerializeField]private float bossAggroRange;
    //root node
    SelectorNode rootNode;

    //nodes
    SequencerNode sequencer1, sequencer2, sequencer3, sequencer4;
    SelectorNode selector1, selector2, selector3, selector4;
    DecoratorNodeInvert decoratorInvert1, decoratorInvert2, decoratorInvert3, decoratorInvert4;
    SucceederNode succeeder1, succeeder2, succeeder3, succeeder4;
    RepeatSetTimesNode repeatSetTimes1, repeatSetTimes2, repeatSetTimes3, repeatSetTimes4;
    RepeatUntilFailNode repeatUntilFail1, repeatUntilFail2, repeatUntilFail3, repeatUntilFail4;

    //behaviour nodes leaf
    LeafNodeMove leafNodeMove;
    LeafNodeIdle leafNodeIdle;
    leafNodeMoveAway leafNodeMoveAway;
    //behaviour nodes
    NodeChooseAttack nodeChooseAttack;
    // Use this for initialization
    void Start () {
        //nodes
        rootNode = new SelectorNode();
        //sequensers
        sequencer1 = new SequencerNode();
        sequencer2 = new SequencerNode();
        //selectors
        selector1 = new SelectorNode();
        selector2 = new SelectorNode();
        //repeaters
        repeatUntilFail1 = new RepeatUntilFailNode();
        //behaviours leaf
        leafNodeIdle = new LeafNodeIdle();
        leafNodeMove = new LeafNodeMove();
        leafNodeMoveAway = new leafNodeMoveAway();
        //behaviours nodes
        nodeChooseAttack = new NodeChooseAttack();
        //repeater nodes
        repeatSetTimes1 = new RepeatSetTimesNode();

        Blackboard bb = new Blackboard();

        //node inits
        rootNode.InitSelector(bb, "Root");
        nodeChooseAttack.Init();
        leafNodeIdle.Init(bossAggroRange);
        leafNodeMove.Init(bossMoveSpeed, bossRotationSpeed);
        leafNodeMoveAway.Init(bossMoveSpeed, bossRotationSpeed);
        selector1.InitSelector(bb, "Selector");
        rootNode.GetController().AddChild(selector1);
        sequencer1.InitSequenser(bb, "Sequence");
        

        //sequence one children
        selector1.GetController().AddChild(leafNodeIdle);
        selector1.GetController().AddChild(leafNodeMove);
        selector1.GetController().AddChild(sequencer1);

        //test for debug
        rootNode.SetCurrentTask(rootNode.GetController().GetChildList().First());
        selector1.SetCurrentTask(selector1.GetController().GetChildList().First());
        sequencer1.SetCurrentTask(sequencer1.GetController().GetChildList().First());
    }
	// Update is called once per frame
	void Update () {
        if(rootNode.CheckCondition() != Status.Terminated)
        {
            rootNode.DoAction();
        }      
	}
}
