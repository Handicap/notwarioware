using UnityEngine;
using System.Collections;

public class punnauskontrolli : MonoBehaviour {


    //ÄLKÄÄ KYSYKÖ
    public float punnausarvo = 0;
    //jos painat ylöspäin, pää pullistuu paskasta
    public float punnauskerroin = 1;
    //ettei paska lennä pään läpi
    public float maksimipunni = 3;
    public int paskamaara;
    public int paskatavoite;
    public float variarvo;

    //animaatiota
    public bool punnailee;
    public float punnailutimer = 0f;
    public Animator animaattori;
    public Animator paa_anim;

    public float keyweight = 0.15f;

    public GameObject paa;
    private SpriteRenderer paarender;

    // 0 vasen, 1 alas, 2 oikea, 3 space
    public int lastpress;

    // tässä se paska joka pierrään ulos
    public GameObject paska;

    // helpottiko vai punnaako?
    public bool punnausvaihe = true;
    public float huilausaika = 0;

    public bool voitto = false;
    public GameObject oikeaverho;
    public GameObject vasenverho;

	// Use this for initialization
	void Start () {
        paarender = paa.GetComponent<SpriteRenderer>();
        paskatavoite = 3 + Random.Range(0, 5);
	}
	
	// Update is called once per frame
	void Update () {

        if (voitto){
            paarender.color = new Color(paarender.color.r, paarender.color.g + 0.1f, paarender.color.g + 0.1f);
            if (paa.transform.localScale.x > 1) paa.transform.localScale = new Vector3(paa.transform.localScale.x - Time.deltaTime / 5, paa.transform.localScale.y - Time.deltaTime / 5);
            oikeaverho.GetComponent<punnariesiriippu>().auki = false;
            vasenverho.GetComponent<punnariesiriippu>().auki = false;
        }
        else{

        // punnataan
        if (punnausvaihe)
        {
            if (punnailee)
            {
                punnailutimer = punnailutimer + Time.deltaTime;
                animaattori.SetBool("punnaaminen", true);
            }
            if (punnailutimer > 0.2f && punnailee)
            {
                punnailee = false;
                punnailutimer = 0f;
                animaattori.SetBool("punnaaminen", false);
            }

            // PUNNAA PUNNAA
            variarvo = variarvo + Time.deltaTime / 12000;
            paarender.color = new Color(paarender.color.r, paarender.color.g - variarvo, paarender.color.b - variarvo);
            paa.transform.localScale = new Vector3(paa.transform.localScale.x + Time.deltaTime / 75, paa.transform.localScale.y + Time.deltaTime / 75);

            //PÄÄ PULLISTUU, PUNNAA-PUNNAA!
                // punnaus kasvaa
            if (punnausarvo < maksimipunni) punnausarvo = punnausarvo + Time.deltaTime * punnauskerroin;
            else punnausarvo = punnausarvo - 0.2f;
                // pää pullistuu
                // pää punoittaa
                //if (paarender.color.g > 0) paarender.color = new Color(paarender.color.r, paarender.color.g - variarvo, paarender.color.b - variarvo);
            
                //paarender.color = new Color(paarender.color.r, paarender.color.g + 0.03f, paarender.color.b + 0.03f);

            //kontrollit
            if (Input.GetKeyDown("left"))
            {
                if (lastpress != 0)
                {
                    punnausarvo = punnausarvo - keyweight;
                    punnailee = true;
                }
                lastpress = 0;
            }

            if (Input.GetKeyDown("down"))
            {
                if (lastpress != 1)
                {
                    punnausarvo = punnausarvo - keyweight;
                    punnailee = true;
                }
                lastpress = 1;
            }

            if (Input.GetKeyDown("right"))
            {
                if (lastpress != 2)
                {
                    punnausarvo = punnausarvo - keyweight;
                    punnailee = true;
                }
                lastpress = 2;
            }

            if (Input.GetKeyDown("space"))
            {
                if (lastpress != 3)
                {
                    punnausarvo = punnausarvo - keyweight;
                    punnailee = true;
                }
                lastpress = 3;
            }
            //kjäh, punnaa-punnaa
            if (Input.GetKeyDown("up"))
            {
                punnauskerroin++;
            }

        } else
        {
            // huilitaan
            huilausaika = huilausaika + Time.deltaTime;
            if (huilausaika > 1f)
            {
                punnausvaihe = true;
                huilausaika = 0;
                paa_anim.SetBool("helpotus", false);
                uusipaska();
            }
        }
            
        }
        }

        

    public void irtoaminen()
    {
        punnausvaihe = false;
        punnauskerroin = 1;
        punnausarvo = 0;
        variarvo = 0;
        paa_anim.SetBool("helpotus", true);
        paskamaara++;
        if (paskamaara == paskatavoite)
        {
            voitto = true;
            animaattori.SetBool("punnaaminen", false);
        }
    }


    //seuraavapaska
    public void uusipaska()
    {
        GameObject uusi = (GameObject)Instantiate(paska);
    }
}
