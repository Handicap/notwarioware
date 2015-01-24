using UnityEngine;
using System.Collections;

public class punnarinpaska : MonoBehaviour {

    public bool irtopaska = false;
    public float irtoamiskorkeus = 0;
    public GameObject paapaska;
    private Rigidbody2D paarigidbdy;
    public float punnausarvo;
    public punnauskontrolli punnari;

    // Use this for initialization
    void Start()
    {
        paarigidbdy = paapaska.GetComponent<Rigidbody2D>();
        paarigidbdy.gravityScale = 0;
        GameObject punnaaja = GameObject.Find("punnaaja");
        punnari = punnaaja.GetComponent<punnauskontrolli>();
        this.punnausarvo = punnari.punnausarvo;
    }

	// Update is called once per frame
	void Update () {

        if (!irtopaska)
        {
            punnausarvo = punnari.punnausarvo;
            paapaska.transform.position = new Vector3(paapaska.transform.position.x, punnausarvo, paapaska.transform.position.z);

            if (punnausarvo < irtoamiskorkeus)
            {
                this.irtopaska = true;
                punnari.irtoaminen();
                paarigidbdy.gravityScale = 1f;
            }
        }
        
	}
}
