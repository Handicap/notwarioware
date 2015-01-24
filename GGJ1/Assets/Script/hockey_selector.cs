using UnityEngine;
using System.Collections;

public class hockey_selector : MonoBehaviour {

    // 0 vasen, 1 keski, 2 oikea
    public GameObject p0;
    public GameObject p1;
    public GameObject p2;

    public GameObject taklaaja;
    public GameObject kohde;
        [Range(0, 2)]
    public int valinta;
        [Range(0,2)]
    public int oikea;

    public GameObject valintaruutu;

    public GameObject silma;

	// Use this for initialization
	void Start () {
        oikea = Random.Range(0, 3);
        hockey_eye silmaskripti = silma.GetComponent<hockey_eye>();
        switch (oikea)
        {
            case 0:
                silmaskripti.aseta(p0);
                break;
            case 1:
                silmaskripti.aseta(p1);
                break;
            case 2:
                silmaskripti.aseta(p2);
                break;
            default:
                break;
        }
        
	}


	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("right"))
        {
            switch (valinta)
            {
                case 0:
                    valinta = 1;
                    transform.position = p1.transform.position;
                    break;
                case 1:
                    valinta = 2;
                    transform.position = p2.transform.position;
                    break;
                case 2:
                    valinta = 0;
                    transform.position = p0.transform.position;
                    break;
                default:
                    break;
            }
        }

        if (Input.GetKeyDown("left"))
        {
            switch (valinta)
            {
                case 0:
                    valinta = 2;
                    transform.position = p2.transform.position;
                    break;
                case 1:
                    valinta = 0;
                    transform.position = p0.transform.position;
                    break;
                case 2:
                    valinta = 1;
                    transform.position = p1.transform.position;
                    break;
                default:
                    break;
            }
        }

        if (Input.GetKeyDown("space"))
        {
            hockey_tackler takli = taklaaja.GetComponent<hockey_tackler>();
            takli.valitse(valinta);
            takli.moving = true;
            hockey_target taklattava = kohde.GetComponent<hockey_target>();
            if (valinta == oikea)
                taklattava.olikooikein = true;
            else taklattava.olikooikein = false;

            Destroy(valintaruutu);
        }
	
	}
}
