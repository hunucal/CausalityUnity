using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
/**
[TODO]
    1.create leafnode behaviours ex. movetoenemy, idle, attack etc etc
    2.create the behaviour tree
    3.extend decorator node functionality
    4.debugg cuz you suck at programming
    5.add more data to blackboard for storage
*/
public class Tree : MonoBehaviour {
    private Selector RootTask;
    private Blackboard blackboard;
    private ResetDecorator plannerReset;
    private RegulatorTask plannerRegulator;
    private Sequence plannerSequence;
    private LeafTaskMove moveTo;
    LeafTaskMove moveTask;
    // Use this for initialization
    void Start () {

	}
	void Awake()
    {
        RootTask = new Selector();
        blackboard = new Blackboard();
        plannerReset = new ResetDecorator();
        plannerRegulator = new RegulatorTask();
        plannerSequence = new Sequence();
        moveTo = new LeafTaskMove();

        blackboard.velocity = new Vector3(3f, 3f, 3f);
        blackboard.agent = GameObject.FindGameObjectWithTag("Boss").GetComponent<NavMeshAgent>();
        blackboard.closestEnemyCursor = GameObject.FindGameObjectWithTag("Player");
        blackboard.Boss = GameObject.FindGameObjectWithTag("Boss");

        RootTask.InitSelector(blackboard);

        //move towards player destination and check dist sequence
        Sequence firstSequence = new Sequence();
        firstSequence.InitSequence(blackboard);

        moveTask = new LeafTaskMove();
        moveTask.InitMove(blackboard);

        TaskDecoratorCheckDistance distCheck = new TaskDecoratorCheckDistance();
        distCheck.InitDist(blackboard, 2f);
        distCheck.InitLeafTask(blackboard);
        distCheck.InitTask(blackboard);

        firstSequence.GetController().AddTask(moveTask);
       // firstSequence.GetControler().AddTask(distCheck);

        // create attack sequence
        ResetDecorator resetTask = new ResetDecorator();
        resetTask.InitResetDecorator(blackboard, firstSequence);

        RootTask.GetController().AddTask(resetTask);
        //RootTask.SetCurrTask(firstSequence);
        resetTask.GetController().AddTask(firstSequence);

        RootTask.Start();
    }
	// Update is called once per frame
	void Update () {
        RootTask.DoAction();
        if (RootTask.GetCurrTask().GetController().Done())
            RootTask.DoAction();
    }
}
