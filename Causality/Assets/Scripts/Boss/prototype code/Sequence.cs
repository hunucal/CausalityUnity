using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : ParentTask {

	public void InitSequence(Blackboard bb)
    {
        InitParentTask(bb);
    }
    public override void ChildFailed()
    {
        GetController().FinishedWithFailiure();
    }
    public override void ChildSucceeded()
    {
        int curPos = GetSubTask().IndexOf(GetCurrTask());
        if (curPos == GetSubTask().Count - 1)
        {
            GetController().FinishedWithSucess();
        }
        else
        {
            SetCurrTask(GetSubTask()[curPos + 1]);
        }
        if (!GetCurrTask().CheckConditions())
        {
            GetController().FinishedWithFailiure();
        }
    }
}
