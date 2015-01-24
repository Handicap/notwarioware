using UnityEngine;
using System.Collections;

public class munasolu : MonoBehaviour {
    Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void rajahda()
    {
        Debug.Log("Pum!");
        anim.SetBool("pum", true);
    }
}
