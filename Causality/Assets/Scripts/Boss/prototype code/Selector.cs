using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : ParentTask
{
    public void InitSelector(Blackboard bb)
    {
        InitParentTask(bb);
    }
    public Task ChooseNewTask()
    {
        Task task = null;
        bool found = false;
        int curPos = GetSubTask().IndexOf(GetCurrTask());
        while (!found)
        {
            if (curPos ==
            (GetSubTask().Count - 1))
            {
                found = true;
                task = null;
                break;
            }
            curPos++;
            task = GetSubTask()[curPos];
            if (task.CheckConditions())
            {
                found = true;
            }
        }
         return task;
    }

    public override void ChildFailed()
    {
        SetCurrTask(ChooseNewTask());
        if (GetCurrTask() == null)
        {
            GetController().FinishedWithFailiure();
        }
    }
    public override void ChildSucceeded()
    {
        GetController().FinishedWithSucess();
    }
}
