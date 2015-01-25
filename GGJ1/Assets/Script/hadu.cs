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

    public GameObject kontrolleri;

    public GameObject huuto;

    Animator anim;
	// Use this for initialization
	void Start () {
        kontrolleri = GameObject.FindGameObjectWithTag("GameController");
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        

        if (!a)
        {
            if (Input.anyKey)
            {
                
               if (!Input.GetKey(KeyCode.DownArrow)) lose();
            }
        }


        

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


        if (Input.GetKeyUp(KeyCode.DownArrow) && !b) lose();

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
        StartCoroutine(losecoroutine());
    }

    public void win()
    {
        Debug.Log("u win");
        isku.transform.SendMessage("iske");

        for (int i = 0; i < vaki.Length; i++)
        {
            vaki[i].transform.SendMessage("pum");
        }
        huuto.audio.Play();
        StartCoroutine(wincoroutine());

    }

    IEnumerator losecoroutine()
    {
        yield return new WaitForSeconds(2.5f);
        Game_logic_controller skripti = kontrolleri.GetComponent<Game_logic_controller>();
        skripti.vahennaelama();
        skripti.randomkentta();
    }

    IEnumerator wincoroutine()
    {
        yield return new WaitForSeconds(2.5f);
        Game_logic_controller skripti = kontrolleri.GetComponent<Game_logic_controller>();
        skripti.lisaapiste();
        skripti.randomkentta();
    }
}
