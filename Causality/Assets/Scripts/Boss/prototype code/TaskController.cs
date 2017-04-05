using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskController {
    private bool done;
    private bool sucess;
    private bool started;
    private Task task;

    public void InitTask(Task task)
    {
        SetTask(task);
        Initialize();
    }
    private void Initialize()
    {
        this.done = false;
        this.sucess = true;
        this.started = false;
    }
    public void SetTask(Task task)
    {
        this.task = task;
    }
    public void SafeStart()
    {
        this.started = true;
        this.task.Start();
    }
    public void SafeEnd()
    {
        this.done = false;
        this.started = false;
        this.task.End();
    }
    public void FinishedWithSucess()
    {
        this.sucess = true;
        this.done = true;
        this.task.LogTask(Status.Success);
    }
    public void FinishedWithFailiure()
    {
        this.sucess = false;
        this.done = true;
        this.task.LogTask(Status.Failure);
    }
    public bool Succeeded()
    {
        return this.sucess;
    }
    public bool Failed()
    {
        return !this.sucess;
    }
    public bool Done()
    {
        return this.done;
    }
    public bool Started()
    {
        return this.started;
    }
    public void Reset()
    {
        this.started = false;
    }

}

