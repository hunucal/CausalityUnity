using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class NodeController {

    public CompositeNode currentTask;
    private List<CompositeNode> ChildList;
    public void InitTask(CompositeNode task)
    {
        SetTask(task);
        Initialize();
        ChildList = new List<CompositeNode>();
    }
    private void Initialize()
    {

    }
    public void SetTask(CompositeNode task)
    {
        this.currentTask = task;
    }
    public void FinishedWithSucess()
    {
        this.currentTask.CompletedWithStatus(Status.Success);
    }
    public void FinishedWithFailiure()
    {
        this.currentTask.CompletedWithStatus(Status.Failure);
    }
    public void AddChild(CompositeNode node) { this.ChildList.Add(node); }
    public List<CompositeNode> GetChildList() { return this.ChildList; }
    public void Reset() { this.currentTask = ChildList.First(); }
}
