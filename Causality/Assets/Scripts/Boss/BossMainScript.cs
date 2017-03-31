using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class BossMainScript : MonoBehaviour {

    [SerializeField]private float bossMoveSpeed;
    [SerializeField]private float bossRotationSpeed;
    [SerializeField]private float bossAggroRange;
    //root node
    SequencerNode rootNode;

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
    //behaviour nodes
    NodeChooseAttack nodeChooseAttack;
    // Use this for initialization
    void Start () {
     
        //nodes
        rootNode = new SequencerNode();
        //sequensers
        sequencer1 = new SequencerNode();
        //behaviours
        leafNodeIdle = new LeafNodeIdle();
        leafNodeMove = new LeafNodeMove();
        nodeChooseAttack = new NodeChooseAttack();

        //nodes init and add children
        leafNodeIdle.Init(bossAggroRange);
        leafNodeMove.Init(bossMoveSpeed, bossRotationSpeed);
        nodeChooseAttack.Init();

        rootNode.AddChild(sequencer1);
        sequencer1.AddChild(leafNodeIdle);
        sequencer1.AddChild(leafNodeMove);
    }
	
	// Update is called once per frame
	void Update () {
        if(rootNode.Running() != Status.Terminated)
        {

        }      
	}
}
