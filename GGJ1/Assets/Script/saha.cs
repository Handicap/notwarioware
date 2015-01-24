﻿using UnityEngine;
using System.Collections;

public class saha : MonoBehaviour {

	public Vector3 direct1;
	public Vector3 direct2;
    public Vector3 victory = new Vector3(0.87037f, -0.288572f, -2f);
    public float speed;

    public GameObject lauta;

    public int vasenoikea;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (transform.position.y < victory.y) win();

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (vasenoikea == 0)
            {
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, direct1, step);

                speed = speed + (speed * 0.01f);

                if (transform.position.Equals(direct1))
                {
                    vasenoikea = 1;
                    direct2.y = direct2.y - 0.1f;
                }
            }
        }



        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (vasenoikea == 1)
            {
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, direct2, step);

                speed = speed + (speed * 0.01f);

                if (transform.position.Equals(direct2))
                {
                    vasenoikea = 0;
                    direct1.y = direct1.y - 0.1f;
                }
            }


        }
	}

    public void win()
    {
        Debug.Log("u won");
        lauta.SendMessage("win");
        speed = 0;

    }
}
