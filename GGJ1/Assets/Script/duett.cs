﻿using UnityEngine;
using System.Collections;

public class duett : MonoBehaviour {
    Animator anim;
    public Transform pari;
    public float etaisyys;
    private bool alustus = false;
    public Transform hepo;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        transform.parent.SendMessage("stop");

        endgame();

    }


    void endgame()
    {
        anim.SetBool("pum", true);
        if (!alustus)
        {
            //this.transform.position = Vector3.MoveTowards(transform.position, pari.position, etaisyys);
            alustus = true;
        }

        //float step = speed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        
        //Destroy(gameObject);


    }
}
