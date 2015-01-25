using UnityEngine;
using System.Collections;

public class tvkasi : MonoBehaviour {

    public GameObject laukaus;
    public GameObject ruudut;
    public GameObject paskaruutu;

    public float huohotus = 0.1f;
    private bool huohosuunta = false;

    public bool ammuttu = false;
    private Vector3 rekyyli;
    public GameObject kontrolleri;

	// Use this for initialization
	void Start () {
        laukaus.SetActive(false);
        rekyyli = new Vector3(0.2f, -0.7f, 0f);
        kontrolleri = GameObject.FindGameObjectWithTag("GameController");
	}
	
	// Update is called once per frame
	void Update () {


        if (!ammuttu && Input.GetKeyDown("space"))
        {
            shoot();
            transform.Translate(rekyyli);
            ammuttu = true;
        }

	}

    // BOOM BOOM BANG
    public void shoot()
    {
        laukaus.SetActive(true);
        ruudut.SetActive(false);
        paskaruutu.SetActive(true);

        Game_logic_controller skripti = kontrolleri.GetComponent<Game_logic_controller>();
        skripti.lisaapiste();
        skripti.randomkentta();
    }
}
