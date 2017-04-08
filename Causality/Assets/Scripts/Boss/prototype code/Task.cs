using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task {
    public Blackboard bb;
    private Status status;
    public void InitTask(Blackboard blackboard)
    {
        this.bb = blackboard;
    }
    //overrides 
    public virtual void Start()
    {
        //starting logic
    }
    public virtual void End()
    {
        //ending logic
    }
    public virtual bool CheckConditions()
    {
        //check conditions for if the task can be run
        //return true for yes
        //return false for no
        return false;
    }
    public virtual void DoAction()
    {

    }
    public virtual ParentTaskController GetController()
    {
        // Override to specify the controller the
        // task has
        // @return The specific task controller.
        return null;
    }
    public virtual void LogTask(Status task)
    {
        this.status = task;
    }
    public virtual Status GetTaskLog()
    {
        return this.status;
    }
}

