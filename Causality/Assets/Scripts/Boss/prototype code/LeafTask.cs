using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafTask : Task{

    protected TaskController control;

    public void InitLeafTask(Blackboard blackboard)
    {
        InitTask(blackboard);
        CreateController();
    }
    private void CreateController()
    {
        this.control = new TaskController();
        this.control.InitTask(this);
    }
    public override TaskController GetControler()
    {
        return this.control;
    }
}
