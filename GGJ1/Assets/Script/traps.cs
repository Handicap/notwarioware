using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class traps : MonoBehaviour {

	// Use this for initialization
	void Start () {
        

        

	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void stop()
    {
        Debug.Log("Voi vittu");
        foreach (Transform child in transform)
        {


            child.SendMessage("stop");
            //child.SendMessage("stop");
            //child is your child transform
        }

    }

    void OnCollisionEnter2D(Collision2D coll)
    {


    }
}
