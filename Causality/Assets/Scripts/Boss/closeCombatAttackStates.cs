using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*States for attacks in close combat:
throwing phase 1, light attack phase 1, light attack combo phase 1, grab attack, heavy attack phase 1, heavy attack combo phase 1, jump phase 1
switch phase stomp,
ranged swipe phase 2, normal swipe phase 2, phase 2 combo light, phase 2 light attack, phase 2 heavy attack, phase 2 heavy combo, jump phase 2*/
public class LightAttackOne : State
{
    GameObject bossObject;
    GameObject bossWeapon;
    public override void Init()
    {
        bossObject = GameObject.FindGameObjectWithTag("Boss");
        bossWeapon = GameObject.FindGameObjectWithTag("BossWeapon");
    }
    public override Status RunState()
    {
        if (Attack())
            return Status.Success;
        else
            return Status.Failure;
    }
    public override Status ExitState()
    {
        return Status.Terminated;
    }
    private bool Attack()
    {
        //set animation light 1
        Vector3 euler90 = new Vector3(90, 0, 0);
        if (bossWeapon.transform.eulerAngles.Equals(euler90))
        {
            bossWeapon.transform.eulerAngles = Vector3.Lerp(bossWeapon.transform.eulerAngles, euler90, 5f * Time.deltaTime);
        }else
            bossWeapon.transform.eulerAngles = Vector3.Lerp(bossWeapon.transform.eulerAngles, -euler90, 5f * Time.deltaTime);
        //if boss animation not done return false
        return true;
    }
}
public class LightAttackTwo : State
{
    GameObject bossObject;
    GameObject bossWeapon;
    public override void Init()
    {
        bossObject = GameObject.FindGameObjectWithTag("Boss");
        bossWeapon = GameObject.FindGameObjectWithTag("BossWeapon");
    }
    public override Status RunState()
    {
        if (Attack())
            return Status.Success;
        else
            return Status.Failure;
    }
    public override Status ExitState()
    {
        return Status.Terminated;
    }
    private bool Attack()
    {
        //set animation light 2
        float h = 10000 * Time.deltaTime;
        Vector3 rotationVector = new Vector3(-h, 0f, 0f);
        bossWeapon.transform.Rotate(rotationVector);
        return true;
    }
}
public class LightAttackThree : State
{
    GameObject bossObject;
    GameObject bossWeapon;
    public override void Init()
    {
        bossObject = GameObject.FindGameObjectWithTag("Boss");
        bossWeapon = GameObject.FindGameObjectWithTag("BossWeapon");
    }
    public override Status RunState()
    {
        if (Attack())
            return Status.Success;
        else
            return Status.Failure;
    }
    public override Status ExitState()
    {
        return Status.Terminated;
    }
    private bool Attack()
    {
        //set animation light 3
        float h = 10 * Time.deltaTime;
        Vector3 rotationVector = new Vector3(-h, 0f, 0f);
        bossWeapon.transform.Rotate(rotationVector);
        return true;
    }
}
public class HeavyAttackOne : State
{
    GameObject bossObject;
    GameObject bossWeapon;
    public override void Init()
    {
        bossObject = GameObject.FindGameObjectWithTag("Boss");
        bossWeapon = GameObject.FindGameObjectWithTag("BossWeapon");
    }
    public override Status RunState()
    {
        if (Attack())
            return Status.Success;
        else
            return Status.Failure;
    }
    public override Status ExitState()
    {
        return Status.Terminated;
    }
    private bool Attack()
    {
        //set animation heavy 1
        float h = 100 * Time.deltaTime;
        Vector3 rotationVector =  Vector3.Slerp(bossWeapon.transform.eulerAngles, new Vector3(bossWeapon.transform.eulerAngles.x + h, bossWeapon.transform.eulerAngles.y, bossWeapon.transform.eulerAngles.z), 10f * Time.deltaTime);
      
        bossWeapon.transform.Rotate(rotationVector);
        return true;
    }
}
public class HeavyAttackTwo : State
{
    GameObject bossObject;
    GameObject bossWeapon;
    public override void Init()
    {
        bossObject = GameObject.FindGameObjectWithTag("Boss");
        bossWeapon = GameObject.FindGameObjectWithTag("BossWeapon");
    }
    public override Status RunState()
    {
        if (Attack())
            return Status.Success;
        else
            return Status.Failure;
    }
    public override Status ExitState()
    {
        return Status.Terminated;
    }
    private bool Attack()
    {
        //set animation heavy 2
        float h = 10 * Time.deltaTime;
        Vector3 rotationVector = Vector3.Slerp(bossWeapon.transform.eulerAngles, new Vector3(bossWeapon.transform.eulerAngles.x + h, bossWeapon.transform.eulerAngles.y, bossWeapon.transform.eulerAngles.z), 10f * Time.deltaTime);

        bossWeapon.transform.Rotate(rotationVector);
        return true;
    }
}
public class HeavyAttackThree : State
{
    GameObject bossObject;
    GameObject bossWeapon;
    public override void Init()
    {
        bossObject = GameObject.FindGameObjectWithTag("Boss");
        bossWeapon = GameObject.FindGameObjectWithTag("BossWeapon");
    }
    public override Status RunState()
    {
        if (Attack())
            return Status.Success;
        else
            return Status.Failure;
    }
    public override Status ExitState()
    {
        return Status.Terminated;
    }
    private bool Attack()
    {
        //set animation heavy 3
        float h = 5 * Time.deltaTime;
        Vector3 rotationVector = Vector3.Slerp(bossWeapon.transform.eulerAngles, new Vector3(bossWeapon.transform.eulerAngles.x + h, bossWeapon.transform.eulerAngles.y, bossWeapon.transform.eulerAngles.z), 10f * Time.deltaTime);

        bossWeapon.transform.Rotate(rotationVector);
        return true;
    }
}
public class GrabAttack : State
{
    GameObject bossObject;
    GameObject bossWeapon;
    bool getPlayerPos;
    bool initGrab;
    public override void Init()
    {
        bossObject = GameObject.FindGameObjectWithTag("Boss");
        bossWeapon = GameObject.FindGameObjectWithTag("BossWeapon");
    }
    public override Status RunState()
    {
        if (Attack())
            return Status.Success;
        else
            return Status.Failure;
    }
    public override Status ExitState()
    {
        return Status.Terminated;
    }
    private bool Attack()
    {
        //set animation grab phase 1
        float h = 10000 * Time.deltaTime;
        Vector3 rotationVector = new Vector3(-h, 0f, 0f);
        bossWeapon.transform.Rotate(rotationVector);
        return true;
    }
}
public class JumpAttack : State
{
    GameObject bossObject;
    Vector3 origRotation;
    GameObject bossWeapon;
    private bool getPos;
    private bool setJumpBack;
    private Vector3 target;
    private NavMeshAgent agent;
    private float jumpHeight;
    Vector3 jumpBackTarget;
    public override void Init()
    {
        setJumpBack = true;
        getPos = true;
        bossObject = GameObject.FindGameObjectWithTag("Boss");
        bossWeapon = GameObject.FindGameObjectWithTag("BossWeapon");
        origRotation = bossWeapon.transform.eulerAngles;
        agent = bossObject.GetComponent<NavMeshAgent>();
    }
    public override Status RunState()
    {
        if (Attack() == Status.Success)
            return Status.Success;
        else
            return Status.Running;
    }
    public override Status ExitState()
    {
        return Status.Terminated;
    }
    private Status Attack()
    {
        if(getPos)
        {

            if (setJumpBack)
            {
                jumpBackTarget = bossObject.transform.position - new Vector3(0f, 0f, 5f);
                setJumpBack = false;
            }
            jumpHeight = 15f;
            
            agent.speed = agent.speed * 3;
            if (!agent.transform.position.y.Equals(jumpHeight))
            {
                agent.transform.position = Vector3.Slerp(agent.transform.position,
                                                    new Vector3(agent.transform.position.x, agent.transform.position.y + jumpHeight, agent.transform.position.z),
                                                    3f * Time.deltaTime);
            }
            if (agent.transform.position.y.Equals(jumpHeight))
            {
                agent.transform.position = Vector3.Slerp(agent.transform.position,
                                                                 new Vector3(agent.transform.position.x, agent.transform.position.y * 0f, agent.transform.position.z),
                                                                 3f * Time.deltaTime);
            }
            bossObject.transform.position = Vector3.MoveTowards(bossObject.transform.position, jumpBackTarget, 6f * Time.deltaTime);
            if(bossObject.transform.position.Equals(jumpBackTarget))
            {
                target = GameObject.FindGameObjectWithTag("Player").transform.position;
                getPos = false;
                setJumpBack = true;
            }
        }
        if(!getPos)
        {
            if (!agent.transform.position.y.Equals(jumpHeight))
            {
                agent.transform.position = Vector3.Slerp(agent.transform.position,
                                                    new Vector3(agent.transform.position.x, agent.transform.position.y + jumpHeight, agent.transform.position.z),
                                                    3f * Time.deltaTime);
            }
            if(agent.transform.position.y.Equals(jumpHeight))
            {
                agent.transform.position = Vector3.Slerp(agent.transform.position,
                                                                 new Vector3(agent.transform.position.x, agent.transform.position.y * 0f, agent.transform.position.z),
                                                                 3f * Time.deltaTime);
            }
            bossObject.transform.position = Vector3.MoveTowards(bossObject.transform.position, target, 6f * Time.deltaTime);
            if (agent.transform.position.Equals(target))
            {
                getPos = true;
                return Status.Success;
            }
        }
        return Status.Running;
    }
}
public enum ListType
{
    CloseCombat, 
    Ranged,
    Jump,
    LightOne,
    LightTwo,
    LightThree,
    HeavyOne,
    HeavyTwo,
    HeavyThree,
    Grab
};
public class closeCombatAttackStates
{
    private List<State> AttackPool;
    private LightAttackOne lightOne;
    private LightAttackTwo lightTwo;
    private LightAttackThree lightThree;
    private HeavyAttackOne heavyOne;
    private HeavyAttackTwo heavyTwo;
    private HeavyAttackThree heavyThree;
    private JumpAttack jump;
    private GrabAttack grab;

    // Use this for initialization
    void Start () {
    }
	public void InitStates()
    {
        //create states
        AttackPool = new List<State>();
        lightOne = new LightAttackOne();
        lightTwo = new LightAttackTwo();
        lightThree = new LightAttackThree();
        heavyOne = new HeavyAttackOne();
        heavyTwo = new HeavyAttackTwo();
        heavyThree = new HeavyAttackThree();
        jump = new JumpAttack();
        grab = new GrabAttack();

        //light attack inits
        lightOne.Init();
        lightTwo.Init();
        lightThree.Init();
        //heavy attack inits
        heavyOne.Init();
        heavyTwo.Init();
        heavyThree.Init();
        //jump attack inits
        jump.Init();
        //grab attack inits
        grab.Init();
        //fill attack pool with states
        //AttackPool.Add(lightOne);
        //AttackPool.Add(lightTwo);
        //AttackPool.Add(lightThree);
        //AttackPool.Add(heavyOne);
        //AttackPool.Add(heavyTwo);
        //AttackPool.Add(heavyThree);
        //AttackPool.Add(grab);
        AttackPool.Add(jump);
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
