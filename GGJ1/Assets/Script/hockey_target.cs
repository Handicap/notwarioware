using UnityEngine;
using System.Collections;

public class hockey_target : MonoBehaviour {

    public GameObject tackler;
    public bool pyllahdys = false;

    public float pyllahdysvaihe = 1f;
    public float pyllykerroin = 1f;

    //skaalat
    public Vector3 skaalaus;
    public float skaalauskerroin = 1f;
    public float skaalausraja = 0.3f;

    public int kierto = 10;

    public bool olikooikein;
    private bool ohitti = false;

    public GameObject kontrolleri;

	// Use this for initialization
	void Start () {
        skaalaus = transform.localScale;
        kontrolleri = GameObject.FindGameObjectWithTag("GameController");
	}
	
	// Update is called once per frame
	void Update () {

        if (tackler.transform.position.x < transform.position.x && olikooikein)
        {
            pyllahdys = true;
        }
        else if (tackler.transform.position.x < transform.position.x && ohitti == false)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            ohitti = true;

            Game_logic_controller skripti = kontrolleri.GetComponent<Game_logic_controller>();
            skripti.randomkentta();
            skripti.lives--;
        }

        if (pyllahdys)
        {

            //skaalaus
            if (skaalaus.x > skaalausraja)
            {
                float skaalaussuhde = Time.deltaTime * skaalauskerroin;
                skaalaus.x = skaalaus.x - skaalaussuhde;
                skaalaus.y = skaalaus.y - skaalaussuhde;
                skaalaus.z = skaalaus.z - skaalaussuhde;
                transform.localScale = skaalaus;
                //kierto
                transform.Rotate(Vector3.forward, kierto);

                //pyllähdys
                pyllahdysvaihe = (pyllahdysvaihe - Time.deltaTime * 1.5f);
                transform.Translate(0, pyllahdysvaihe * pyllykerroin, 0, Space.World);
            }
            else
            {
                SpriteRenderer rendereri = gameObject.GetComponent<SpriteRenderer>();
                rendereri.sortingOrder = 2;

                Game_logic_controller skripti = kontrolleri.GetComponent<Game_logic_controller>();
                skripti.totalscore++;
                skripti.randomkentta();
            }



        }

	}
}
