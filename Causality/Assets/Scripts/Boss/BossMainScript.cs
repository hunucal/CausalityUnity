using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.AI;

public class BossMainScript : MonoBehaviour
{
        [Header("Boss movement settings")]
    [SerializeField]private float bossMoveSpeed;
    [SerializeField]private float bossRotationSpeed;
    [SerializeField]private float bossAggroRange;
    //root node
    SelectorNode rootNode;
    //blackboard
    Blackboard bb;
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
    //decorators
    DecoratorNodeCheckDist checkdst;
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
        //check distance decorator
        checkdst = new DecoratorNodeCheckDist(); 

        bb = new Blackboard();
        bb.Boss = GameObject.FindGameObjectWithTag("Boss");
        bb.agent = bb.Boss.GetComponent<NavMeshAgent>();
        bb.closestEnemyCursor = GameObject.FindGameObjectWithTag("Player");
        bb.movespeed = bossMoveSpeed;
        bb.aggroRange = bossAggroRange;
        bb.rotationSpeed = bossRotationSpeed;
        bb.maxValHealth = 100f;
        bb.maxValTwoHealth = 100f;
        bb.currentValHealth = 100f;
        bb.currentValTwoHealth = 100f;
        bb.fillAmountHealth = 1f;
        bb.fillAmountTwoHealth = 1f;

        //node inits
        rootNode.InitSelector(bb, "Root");
        nodeChooseAttack.InitAttack(bb,"Attack");
        leafNodeIdle.InitIdle(bb, "Idle");
        leafNodeMove.InitMove(bb, "Move");
        leafNodeMoveAway.Init(bossMoveSpeed, bossRotationSpeed);
        selector1.InitSelector(bb, "Selector");
        sequencer1.InitSequenser(bb, "Sequence");

        checkdst.initDistCheck(bb, "distanceCheck");

        //sequence one children
        rootNode.GetController().AddChild(selector1);
        selector1.GetController().AddChild(leafNodeIdle);
        selector1.GetController().AddChild(leafNodeMove);
        //sequencer1.GetController().AddChild(leafNodeMove);
       //sequencer1.GetController().AddChild(checkdst);
       // sequencer1.GetController().AddChild(nodeChooseAttack);

        //test for debug
        rootNode.SetCurrentTask(rootNode.GetController().GetChildList().First());
        selector1.SetCurrentTask(selector1.GetController().GetChildList().First());
        sequencer1.SetCurrentTask(sequencer1.GetController().GetChildList().First());
    }
	// Update is called once per frame
	void Update ()
    {
        if(rootNode.CheckCondition() != Status.Failure)
        {
            rootNode.CurrTask.DoAction();
        }      
	}

    public float GetHealthVal()
    {
        return bb.currentValHealth / 100f;
    }

    public float GetTwoHealthVal()
    {
        return bb.currentValTwoHealth / 100f;
    }

    public float GetMaxValueHealth()
    {
        return bb.maxValHealth;
    }
}
