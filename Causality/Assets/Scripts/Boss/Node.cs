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
    public virtual Status Running() { return Status.Terminated; }
}
public class CompositeNode : Node
{
    private List<Node> listChildren = new List<Node>();

    public override Status Running() { return Status.Failure; }
    public List<Node> GetChildren() { return listChildren; }
    public void AddChild(Node a) { listChildren.Add(a); }
}
public class SelectorNode : CompositeNode
{
    public override Status Running()
    {
        for(int i = 0; i < GetChildren().Count; i++)
        {
            if (GetChildren()[i].Running() == Status.Success)
                return Status.Success;
        }
        return Status.Terminated;
    }
}
public class SequencerNode : CompositeNode
{
    public override Status Running()
    {
        for (int i = 0; i < GetChildren().Count; i++)
        {
            if (GetChildren()[i].Running() == Status.Failure)
                return Status.Failure;
        }
        return Status.Terminated;
    }
}
public class DecoratorNodeInvert : Node
{
    private Node Child;
    public override Status Running()
    {
        if(Child.Running() == Status.Success)
            return Status.Failure;
        else if (Child.Running() == Status.Failure)
            return Status.Success;

        return Status.Terminated;
    }

    public void AddChild(Node A) { Child = A; } 
}
public class SucceederNode : Node
{
    public override Status Running()
    {
        return Status.Success;
    }
}
public class RepeatUntilFailNode : CompositeNode
{
    public override Status Running()
    {
        foreach(Node n in GetChildren())
        {
            while(n.Running() != Status.Failure)
            {
                n.Running();
            }
            return Status.Success;
        }
        return Status.Terminated;
    }
}
public class RepeatSetTimesNode : CompositeNode
{
    private int times;
    public void Init(int timesToRepeat)
    {
        times = timesToRepeat;
    }
    public override Status Running()
    {
        foreach(Node n in GetChildren())
        {
            for(int i = 0; i < times; i++)
            {
                n.Running();
                return Status.Running;
            }
            return Status.Success;
        }
        return Status.Terminated;
    }
}
