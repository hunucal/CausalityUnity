using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskDecorators : Task {

    public Task task;

    public void InitDecorator(Blackboard bb, Task task)
    {
        InitTask(bb);
        InitDecoratorTask(task);
    }
    private void InitDecoratorTask(Task task)
    {
        this.task = task;
        this.task.GetController().SetTask(this);
    }
    public override bool CheckConditions()
    {
        return this.task.CheckConditions();
    }
    public override void End()
    {
        this.task.End();
    }
    public override ParentTaskController GetController()
    {
        return this.task.GetController();
    }
    public override void Start()
    {
        this.task.Start();
    }
}
