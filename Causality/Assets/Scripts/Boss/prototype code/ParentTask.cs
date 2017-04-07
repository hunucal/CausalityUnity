using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class ParentTask : Task {

    private ParentTaskController control;
    public void InitParentTask(Blackboard bb)
    {
        InitTask(bb);
        CreateController();
    }
    private void CreateController()
    {
        this.control = new ParentTaskController();
        this.control.InitParentTask(this);
       // this.control.InitTask(this);
    }
    public override ParentTaskController GetController()
    {
        return this.control;
    }
    public List<Task> GetSubTask()
    {
        return this.control.subTasks;
    }
    public override bool CheckConditions()
    {
        return this.control.subTasks.Count > 0;
    }
    public Task GetCurrTask()
    {
        return this.control.currTask;
    }
    public void SetCurrTask(Task task)
    {
        this.control.currTask = task;
    }
    public virtual void ChildSucceeded()
    {
    }
    public virtual void ChildFailed()
    {
    }
    public override void DoAction()
    {
        if(this.control.Done())
        {
            return;
        }
        if(this.control.currTask == null)
        {
            return;
        }
        if(!this.control.currTask.GetController().Started())
        {
            this.control.currTask.GetController().SafeStart();
        }
        else if(this.control.currTask.GetController().Done())
        {
            this.control.currTask.GetController().SafeEnd();

            if (this.control.currTask.GetController().Succeeded())
            {
                this.ChildSucceeded();
            }
            else if (this.control.currTask.GetController().Failed())
            {
                this.ChildFailed();
            }
        }
        else
        {
            this.control.currTask.DoAction();
        }
    }
    public override void End()
    {
        
    }
    public override void Start()
    {
        this.control.currTask = this.control.subTasks.First();
        if(this.control.currTask == null)
        {
            //state has null actions
            Debug.Log("Current task has null actions");
        }
    }
}
