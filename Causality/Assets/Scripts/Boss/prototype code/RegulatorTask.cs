using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegulatorTask : TaskDecorators {
    private float updateTime;
    public void InitRegulator(float seconds, Blackboard bb, Task task)
    {
        InitDecorator(bb, task);
        this.updateTime = seconds;
    }
    public override void Start()
    {
        task.Start();
    }
    private float Timer()
    {
       return updateTime -= Time.deltaTime;
    }
    public override void DoAction()
    {
        if(updateTime <= 0f)
        {
            if(Timer() < 0f)
                task.DoAction();
        }
    }
    public void ResetTimer(float time)
    {
        this.updateTime = time;
    }
}
