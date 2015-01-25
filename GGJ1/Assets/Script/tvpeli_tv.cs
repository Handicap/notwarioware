using UnityEngine;
using System.Collections;

public class tvpeli_tv : MonoBehaviour {

    public bool tv_paalla = false;
    public bool ohjelma = false;
    public int ohjelmajarjestys = 0;
    public int nykyinenohjelma;

    public GameObject tvfiltteri;
    public GameObject[] ohjelmat;
    public bool[] nahty;
    public GameObject sheriffi;

    public GameObject kasi;

    // 0 sheriffchancella tulee sheriffi
    public int sheriffchance = 1;

    private bool sheriffiarvottu = false;

    public float ajastin = 0f;
    public GameObject kontrolleri;

	// Use this for initialization
	void Start () {
        kontrolleri = GameObject.FindGameObjectWithTag("GameController");
	}
	
	// Update is called once per frame
	void Update () {

        ajastin = ajastin + Time.deltaTime;

        // telkkari päälle
        if (!tv_paalla && ajastin > 3)
        {
            tv_paalla = true;
            ajastin = 0;
            tvfiltteri.SetActive(true);
        }


        //sheriffin kosto

        if (!sheriffiarvottu)
        {
            sheriffchance = Random.Range(0, ohjelmat.Length - ohjelmajarjestys+1);
            sheriffiarvottu = true;
        }


        // ohjelmia tulemaan
        if ((tv_paalla && ajastin > 1.5f) && !ohjelma)
        {
            //SHERIFFI
            if (sheriffchance == 0)
            {
                ohjelma = true;

                //varmuuden vuoksi for
                for (int i = 0; i < ohjelmat.Length; i++)
                {
                    ohjelmat[i].SetActive(false);
                }

                sheriffi.SetActive(true);
                ajastin = 0;
            }
            else
                // jotain muuta
            {
                ohjelma = true;
                while (nahty[nykyinenohjelma] == true)
                {
                    nykyinenohjelma = Random.Range(0, 6);
                }
                ohjelmat[nykyinenohjelma].SetActive(true);
                nahty[nykyinenohjelma] = true;
                ajastin = 0;
                ohjelmajarjestys++;
            }

        }

        if ((ohjelma && ajastin > 3))
        {
            ohjelmat[nykyinenohjelma].SetActive(false);
            ohjelma = false;
            if (sheriffchance != 0)
            {
                sheriffiarvottu = false;
                ajastin = 0;
            }

        }

        if (sheriffchance == 0 && ajastin > 1.5f)
        {
            tvpeli_sheriff sheriffiskripti = sheriffi.GetComponent<tvpeli_sheriff>();
            sheriffiskripti.ammu();
            tvkasi kasiskripti = kasi.GetComponent<tvkasi>();
            kasiskripti.ammuttu = true;

            Game_logic_controller skripti = kontrolleri.GetComponent<Game_logic_controller>();
            skripti.vahennaelama();
            skripti.randomkentta();
        }

	}
}
