using UnityEngine;
using System.Collections;

public class menuvalintakohde : MonoBehaviour {

    public string seuraavataso;
    public GameObject kontrolleri;
    public bool randomikentta;
    public bool quit;

	// Use this for initialization
	void Start () {
        Debug.Log("Trigger: " + collider2D.isTrigger);
        kontrolleri = GameObject.FindGameObjectWithTag("GameController");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //poks
    void OnTriggerEnter2D(Collider2D other)
    {
        Game_logic_controller skripti = kontrolleri.GetComponent<Game_logic_controller>();
        if (quit) Application.Quit();
        if (!randomikentta)
        {
            skripti.uusikentta(seuraavataso);
        }
        else skripti.randomkentta();
        Debug.Log("uusikentta");
    }

    void OnTriggerExit2D(Collider2D other)
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {

    }


}
