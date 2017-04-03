using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Respawn : MonoBehaviour {

    public float Health;
    public Text DeadText;

	// Use this for initialization
	void Start () {
        Health = 1;
        DeadText.text = "";
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.A))
        {
            Health -= Time.deltaTime;
        }

        if (Health <= 0)
        {
            transform.position = new Vector3(5.0f, 0.5799999f, 1.98f);
            DeadText.text = ("You are dead");
            Health = 1;
        }
		
	}
}
