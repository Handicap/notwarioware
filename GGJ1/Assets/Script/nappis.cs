﻿using UnityEngine;
using System.Collections;

public class nappis : MonoBehaviour {


    public Transform space;
    public Transform up;
    public Transform down;
    public Transform left;
    public Transform right;
    public Transform target;
    public Transform voittotassu;
    public Transform haviotassu1;
    public Transform haviotassu2;

    public float kasvunopeus;
    public bool kasvu;

	// Use this for initialization
	void Start () {

        int rand = UnityEngine.Random.Range(1, 6);


        switch (rand)
        {
            case 1:
                target = space;
                break;
            case 2:
                target = right;
                break;
            case 3:
                target = up;
                break;
            case 4:
                target = down;
                break;
            case 5:
                target = left;
                break;
            default:
                target = right;
                break;
        }


        target.position = new Vector3 (target.position.x, target.position.y, -1f);


	}
	
	// Update is called once per frame
	void Update () {

        if (kasvu)
        {
            transform.localScale += new Vector3(kasvunopeus, kasvunopeus, kasvunopeus);
            StartCoroutine(thiscoroutine());

        }


        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (target == right)
            {
                win();
            }
            else
            {
                lose();
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (target == left)
            {
                win();
            }
            else
            {
                lose();
            }

        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (target == up)
            {
                win();
            }
            else
            {
                lose();
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (target == down)
            {
                win();
            }
            else
            {
                lose();
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (target == space)
            {
                win();
            }
            else
            {
                lose();
            }
        }

	
	}

    public void win()
    {
        voittotassu.SendMessage("activ", target.position);

    }


    public void lose()
    {
        haviotassu1.SendMessage("activ", target.position);
        haviotassu2.SendMessage("activ", target.position);
    }

    public void viskaa()
    {
        kasvu = true;

    }


    IEnumerator thiscoroutine()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
        Destroy(space);
        Destroy(up);
        Destroy(down);
        Destroy(left);
        Destroy(right);

        /*
            public Transform space;
    public Transform up;
    public Transform down;
    public Transform left;
    public Transform right;*/

    }

}