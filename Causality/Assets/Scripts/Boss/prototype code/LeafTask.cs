using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafTask : Task{

    protected ParentTaskController control;

    public void InitLeafTask(Blackboard blackboard)
    {
        InitTask(blackboard);
        CreateController();
    }
    private void CreateController()
    {
        this.control = new ParentTaskController();
        this.control.InitTask(this);
    }
    public override ParentTaskController GetController()
    {
        return this.control;
    }
}
