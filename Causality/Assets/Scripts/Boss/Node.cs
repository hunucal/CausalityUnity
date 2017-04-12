using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public enum Status
{
    Success,
    Failure,
    Running,
    Done,
    Terminated
}
public class Node {
    public bool started, ended;
    public Blackboard blackboard;
    public string name;
    public Status taskStatus;
    public virtual void InitNode(Blackboard bb, string name) { this.blackboard = bb; this.name = name; }
    public virtual void DoAction() {  }
    public virtual bool CheckStatus() { return true; }
    public virtual void CompletedWithStatus(Status status) { this.taskStatus = status; }
    public virtual Status CheckCondition() { return this.taskStatus; }
    public string GetName() { return this.name; }
}
public class CompositeNode : Node
{
    public Node CurrTask;
    private NodeController controller;
    public void InitCompositeNode(Blackboard bb, string name)
    {
        started = false;
        ended = false;
        InitNode(bb, name);
        this.CurrTask = null;
        this.controller = new NodeController();
        this.controller.InitTask(this);
    }
    public NodeController GetController() { return this.controller; }
    public override void DoAction()
    {
        this.controller.currentTask.DoAction();
    }
    public void Start() { this.started = true; this.ended = false; }
    public void Ended() { this.started = false; this.ended = true; }
    public void SetCurrentTask(CompositeNode node) { this.controller.SetTask(node); }
    public CompositeNode GetCurrentTask() { return this.controller.currentTask; }
    public override Status CheckCondition(){return taskStatus;}
    public override void CompletedWithStatus(Status status) { taskStatus = status; }
}
public class SelectorNode : CompositeNode
{
    public void InitSelector(Blackboard bb, string name)
    {
        InitCompositeNode(bb, name);
    }
    public CompositeNode ChooseNewTask()
    {
        CompositeNode currNode = null;
        bool found = false;
        int curPos = GetController().GetChildList().IndexOf(GetCurrentTask());
        while (!found)
        {
            if (curPos == (GetController().GetChildList().Count - 1))
            {
                found = true;
                currNode = null;
                break;
            }
            curPos++;
            currNode = GetController().GetChildList()[curPos];
            if (currNode.CheckCondition() == Status.Success)
            {
                found = true;
            }
        }
        return currNode;
    }
    public override void DoAction()
    {
        //for (int i = 0; i < GetController().GetChildList().Count; i++)
        //{
        //    if (GetController().GetChildList()[i].CheckCondition() != Status.Failure)
        //        GetController().GetChildList()[i].DoAction();
        //    GetController().FinishedWithSucess();
        //}
        int curPos = GetController().GetChildList().IndexOf(GetCurrentTask());
        bool running = false;
        if (!running)
        {
            if (curPos > GetController().GetChildList().Count)
            {
                SetCurrentTask(GetController().GetChildList().First());
            }
            if (GetController().GetChildList()[curPos].CheckCondition() == Status.Failure)
            {
                curPos++;
                SetCurrentTask(GetController().GetChildList()[curPos]);
                running = true;
            }
            else if (GetCurrentTask().CheckCondition() == Status.Done)
            {
                curPos++;
                SetCurrentTask(GetController().GetChildList()[curPos]);
                running = true;
            }
            else if (GetCurrentTask().Equals(GetController().GetChildList().Last()) && GetController().GetChildList().Last().CheckCondition() == Status.Done)
            {
                SetCurrentTask(GetController().GetChildList().First());
                running = true;
            }
            else
                running = true;
        }
        if(running)
            GetController().GetChildList()[curPos].DoAction();
    }
}
public class SequencerNode : CompositeNode
{
    public void InitSequenser(Blackboard bb, string name)
    {
        InitCompositeNode(bb, name);
    }
    public override void DoAction()
    {
        //for (int i = 0; i < GetController().GetChildList().Count; i++)
        //{
        //    if (GetController().GetChildList()[i].CheckCondition() != Status.Success)
        //        GetController().GetChildList()[i].DoAction();
        //    GetController().FinishedWithFailiure();
        //}
        int curPos = GetController().GetChildList().IndexOf(GetCurrentTask());
        bool running = false;
        if (!running)
        {
            if (curPos > GetController().GetChildList().Count)
            {
                SetCurrentTask(GetController().GetChildList().First());
            }
            if (GetController().GetChildList()[curPos].CheckCondition() == Status.Failure)
            {
                return;
            }
            else if (GetCurrentTask().CheckCondition() == Status.Done)
            {
                curPos++;
                SetCurrentTask(GetController().GetChildList()[curPos]);
                running = true;
            }
            else if (GetCurrentTask().CheckCondition() == Status.Done && GetCurrentTask().Equals(GetController().GetChildList().Last()))
            {
                SetCurrentTask(GetController().GetChildList().First());
                running = true;
            }
            else
                running = true;
        }
        GetController().GetChildList()[curPos].DoAction();
    }
}
public class DecoratorNodeInvert : CompositeNode
{
    private Node Child;
    public override void DoAction()
    {
        if(Child.CheckCondition() == Status.Success)
            Child.CompletedWithStatus(Status.Failure);
        else if (Child.CheckCondition() == Status.Failure)
            Child.CompletedWithStatus(Status.Success);
    }

    public void AddChild(Node A) { Child = A; } 
}
public class SucceederNode : Node
{
    public override void DoAction()
    {
      
    }
}
public class RepeatUntilFailNode : CompositeNode
{
    public void initRepeatNode(Blackboard bb, string name)
    {
        InitCompositeNode(bb, name);
    }
    public override void DoAction()
    {
        foreach(CompositeNode n in GetController().GetChildList())
        {
            if(n.CheckCondition() != Status.Failure)
            {
                n.DoAction();
                return;
            } 
        }
    }
}
public class RepeatSetTimesNode : CompositeNode
{
    private int times;
    public void Init(int timesToRepeat)
    {
        times = timesToRepeat;
    }
    public override void DoAction()
    {
        foreach(Node n in GetController().GetChildList())
        {
            for(int i = 0; i < times; i++)
            {
                if (n.CheckCondition() != Status.Terminated)
                    return;
            }
        }
    }
}
