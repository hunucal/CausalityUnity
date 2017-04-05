using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Status
{
    Success,
    Failure,
    Running,
    Terminated
}
public class Node {
    public virtual Status Tick() { return Status.Terminated; }
}
public class CompositeNode : Node
{
    private List<Node> listChildren = new List<Node>();

    public override Status Tick() { return Status.Failure; }
    public List<Node> GetChildren() { return listChildren; }
    public void AddChild(Node a) { listChildren.Add(a); }
    public void RemoveChild(Node a) { if (listChildren.Contains(a)) { listChildren.Remove(a); } }
}
public class SelectorNode : CompositeNode
{
    public override Status Tick()
    {
        for(int i = 0; i < GetChildren().Count; i++)
        {
            if (GetChildren()[i].Tick() != Status.Failure)
                return GetChildren()[i].Tick();
        }
        return Status.Failure;
    }
}
public class SequencerNode : CompositeNode
{
    public override Status Tick()
    {
        for (int i = 0; i < GetChildren().Count; i++)
        {
            if (GetChildren()[i].Tick() != Status.Success)
                return GetChildren()[i].Tick();
        }
        return Status.Success;
    }
}
public class DecoratorNodeInvert : Node
{
    private Node Child;
    public override Status Tick()
    {
        if(Child.Tick() == Status.Success)
            return Status.Failure;
        else if (Child.Tick() == Status.Failure)
            return Status.Success;

        return Status.Failure;
    }

    public void AddChild(Node A) { Child = A; } 
}
public class SucceederNode : Node
{
    public override Status Tick()
    {
        return Status.Success;
    }
}
public class RepeatUntilFailNode : CompositeNode
{
    public override Status Tick()
    {
        foreach(Node n in GetChildren())
        {
            if(n.Tick() != Status.Failure)
            {
                return n.Tick();
            } 
            else
                return Status.Failure;
        }
        return Status.Failure;
    }
}
public class RepeatSetTimesNode : CompositeNode
{
    private int times;
    public void Init(int timesToRepeat)
    {
        times = timesToRepeat;
    }
    public override Status Tick()
    {
        foreach(Node n in GetChildren())
        {
            for(int i = 0; i < times; i++)
            {
                if(n.Tick() != Status.Terminated)
                return n.Tick();
            }
        }
        return Status.Terminated;
    }
}
