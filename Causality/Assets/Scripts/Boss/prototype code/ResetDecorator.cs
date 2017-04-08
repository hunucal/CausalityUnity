using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetDecorator : TaskDecorators {

    public void InitResetDecorator(Blackboard bb, Task task)
    {
        InitDecorator(bb, task);
    }

    
public override void DoAction()
    {
        this.task.DoAction();
        if (this.task.GetController().Done())
        {
            this.task.GetController().Reset();
        }
    }
}
