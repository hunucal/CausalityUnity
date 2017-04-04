using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMainScript : MonoBehaviour {
        [Header("Boss movement settings")]
    [SerializeField]private float bossMoveSpeed;
    [SerializeField]private float bossRotationSpeed;
    [SerializeField]private float bossAggroRange;
    //root node
    RepeatUntilFailNode rootNode;

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
        rootNode = new RepeatUntilFailNode();
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
        //nodes init and add children
        //leaf
        leafNodeIdle.Init(bossAggroRange);
        leafNodeMove.Init(bossMoveSpeed, bossRotationSpeed);
        leafNodeMoveAway.Init(bossMoveSpeed, bossRotationSpeed);
        repeatSetTimes1.Init(1);
        //nodes
        nodeChooseAttack.Init();

        //root child
        rootNode.AddChild(selector1);

        //sequence one children
        selector1.AddChild(leafNodeIdle);
        selector1.AddChild(leafNodeMove);
        selector1.AddChild(sequencer1);
        sequencer1.AddChild(nodeChooseAttack);
    }
	// Update is called once per frame
	void Update () {
        if(rootNode.Tick() != Status.Failure)
        {
            if (selector1.Tick() == Status.Failure)
                selector1.RemoveChild(leafNodeIdle);
        }      
	}
}
