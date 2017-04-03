using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Respawn : MonoBehaviour {

    //public float Health;
    public Text DeadText;

    [SerializeField]
    private Stat Health;

    public float Timer = 0;

	// Use this for initialization
	void Start () {
        DeadText.text = "";
		
	}

    private void Awake()
    {
        Health.Initialize();
    }
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKey(KeyCode.A))
        {
           Timer += Time.deltaTime;
            if (Timer < 5)
            {
                Health.CurrentValHealth += 5 * Time.deltaTime;
            }
            if(Timer >= 20)
            {
                Timer = 0;
            }
            
        }

            transform.position = new Vector3(5.0f, 0.5799999f, 1.98f);
            DeadText.text = ("You are dead");
		
	}
}
