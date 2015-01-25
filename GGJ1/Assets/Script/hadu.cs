using UnityEngine;
using System.Collections;

public class hadu : MonoBehaviour {
    public Transform isku;

    public bool a = false;
    public bool b = false;
    public bool c = false;
    public bool d = false;

    public Transform[] vaki = new Transform[8];

    public int index = 0;

    Animator anim;
	// Use this for initialization
	void Start () {

        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.DownArrow))
        {

            StartCoroutine(coroutineA());

            if (!a)
            {
                index++;
                a = true;
                
            }




            if (!a) return;

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {

                if (!b)
                {
                    index++;
                    b = true;
                    anim.SetBool("a", true);
                }




            }
        }

        if (!b) return;

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            if (!c)
            {
                index++;
                c = true;
                anim.SetBool("b", true);
            }




        }


        if (!c) return;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!d)
                {
                    index++;
                    d = true;
                    anim.SetBool("c", true);
                    win();
                }
                StopCoroutine("coroutineA");

            }
        }
	
	}



    IEnumerator coroutineA()
    {



        yield return new WaitForSeconds(4f);

        if (index != 4) lose();
        

    }






    public void lose()
    {

        Debug.Log("u lose");
        anim.SetBool("fail", true);
    }

    public void win()
    {
        Debug.Log("u win");
        isku.transform.SendMessage("iske");

        for (int i = 0; i < vaki.Length; i++)
        {
            vaki[i].transform.SendMessage("pum");
        }

    }
}
