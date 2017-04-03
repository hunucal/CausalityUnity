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
    Vector3 origRotation;
    GameObject bossWeapon;
    public override void Init()
    {
        bossObject = GameObject.FindGameObjectWithTag("Boss");
        bossWeapon = GameObject.FindGameObjectWithTag("BossWeapon");
        origRotation = bossWeapon.transform.eulerAngles;
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
    Vector3 origRotation;
    GameObject bossWeapon;
    public override void Init()
    {
        bossObject = GameObject.FindGameObjectWithTag("Boss");
        bossWeapon = GameObject.FindGameObjectWithTag("BossWeapon");
        origRotation = bossWeapon.transform.eulerAngles;
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
    Vector3 origRotation;
    GameObject bossWeapon;
    public override void Init()
    {
        bossObject = GameObject.FindGameObjectWithTag("Boss");
        bossWeapon = GameObject.FindGameObjectWithTag("BossWeapon");
        origRotation = bossWeapon.transform.eulerAngles;
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
        //set animation light 3
        float h = 10000 * Time.deltaTime;
        Vector3 rotationVector = new Vector3(-h, 0f, 0f);
        bossWeapon.transform.Rotate(rotationVector);
        return true;
    }
}
public class HeavyAttackOne : State
{
    GameObject bossObject;
    Vector3 origRotation;
    GameObject bossWeapon;
    public override void Init()
    {
        bossObject = GameObject.FindGameObjectWithTag("Boss");
        bossWeapon = GameObject.FindGameObjectWithTag("BossWeapon");
        origRotation = bossWeapon.transform.eulerAngles;
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
        //set animation heavy 1
        float h = 10000 * Time.deltaTime;
        Vector3 rotationVector = new Vector3(-h, 0f, 0f);
        bossWeapon.transform.Rotate(rotationVector);
        return true;
    }
}
public class HeavyAttackTwo : State
{
    GameObject bossObject;
    Vector3 origRotation;
    GameObject bossWeapon;
    public override void Init()
    {
        bossObject = GameObject.FindGameObjectWithTag("Boss");
        bossWeapon = GameObject.FindGameObjectWithTag("BossWeapon");
        origRotation = bossWeapon.transform.eulerAngles;
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
        //set animation heavy 2
        float h = 10000 * Time.deltaTime;
        Vector3 rotationVector = new Vector3(-h, 0f, 0f);
        bossWeapon.transform.Rotate(rotationVector);
        return true;
    }
}
public class HeavyAttackThree : State
{
    GameObject bossObject;
    Vector3 origRotation;
    GameObject bossWeapon;
    public override void Init()
    {
        bossObject = GameObject.FindGameObjectWithTag("Boss");
        bossWeapon = GameObject.FindGameObjectWithTag("BossWeapon");
        origRotation = bossWeapon.transform.eulerAngles;
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
        //set animation heavy 3
        float h = 10000 * Time.deltaTime;
        Vector3 rotationVector = new Vector3(-h, 0f, 0f);
        bossWeapon.transform.Rotate(rotationVector);
        return true;
    }
}
public class GrabAttack : State
{
    GameObject bossObject;
    Vector3 origRotation;
    GameObject bossWeapon;
    public override void Init()
    {
        bossObject = GameObject.FindGameObjectWithTag("Boss");
        bossWeapon = GameObject.FindGameObjectWithTag("BossWeapon");
        origRotation = bossWeapon.transform.eulerAngles;
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
    public override void Init()
    {
        bossObject = GameObject.FindGameObjectWithTag("Boss");
        bossWeapon = GameObject.FindGameObjectWithTag("BossWeapon");
        origRotation = bossWeapon.transform.eulerAngles;
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
        //set animation jump phase 1
        float h = 10000 * Time.deltaTime;
        Vector3 rotationVector = new Vector3(-h, 0f, 0f);
        bossWeapon.transform.Rotate(rotationVector);
        return true;
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
public class closeCombatAttackStates : MonoBehaviour
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

        //init state after creation
        lightOne.Init();
        lightTwo.Init();
        lightThree.Init();

        heavyOne.Init();
        heavyTwo.Init();
        heavyThree.Init();

        jump.Init();

        grab.Init();

        AttackPool.Add(lightOne);
        AttackPool.Add(lightTwo);
        AttackPool.Add(lightThree);
        AttackPool.Add(heavyOne);
        AttackPool.Add(heavyTwo);
        AttackPool.Add(heavyThree);
        AttackPool.Add(jump);
        AttackPool.Add(grab);
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
