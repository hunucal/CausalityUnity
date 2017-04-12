using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public virtual void Init()
    {

    }
    public virtual void RunState()
    {
        
    }
    public virtual Status ExitState()
    {
        return Status.Terminated;
    }
    public virtual Status GetCompletition()
    {
        return Status.Terminated;
    }
}
