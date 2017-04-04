using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class ParentTaskController : TaskController
{

    public List<Task> subTasks;

    public Task currTask;

    public void InitParentTask(Task task)
    {
        InitTask(task);
        this.subTasks = new List<Task>();
        this.currTask = null;
    }
    public void AddTask(Task task)
    {
        subTasks.Add(task);
    }
    public void ParentReset()
    {
        Reset();
        this.currTask = subTasks.First();
    }
}
