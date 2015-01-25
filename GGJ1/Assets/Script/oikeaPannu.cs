using UnityEngine;
using System.Collections;

public class oikeaPannu : MonoBehaviour {
    public float angle;
    public float maxAngle;
    public float rotationSpeed;

    public float maxOsuu;
    public float minOsuu;

    public bool pressed;
    public bool kahvia;
    public bool osuu;


    public GameObject kahviosuu1;
    public GameObject kahviosuu2;
    public GameObject kahviohi;

    public GameObject kasi;

    public Vector3 kahvipaikka1;
    public Vector3 kahvipaikka2;
    public Vector3 kahvipaikka3;

    public Vector3 sivupaikka;

    public GameObject kontrolleri;

	// Use this for initialization
	void Start () {

        kontrolleri = GameObject.FindGameObjectWithTag("GameController");
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.Space))
        {
            pressed = true;

        }

        if (!pressed) return;

        if (angle < maxAngle)
        {
            angle += 100 * Time.deltaTime * rotationSpeed;
            transform.eulerAngles = new Vector3(0, 0, angle);

        }
        else
        {
            Game_logic_controller skripti = kontrolleri.GetComponent<Game_logic_controller>();
            if (kasi.transform.position.x < maxOsuu && kasi.transform.position.x > minOsuu) osuu = true;
            kahviosuu1.SendMessage("uusipaikka", kahvipaikka1);
            kahviosuu2.SendMessage("uusipaikka", kahvipaikka2);

            if (osuu)
            {
                kahviohi.SendMessage("uusipaikka", kahvipaikka3);
                skripti.lisaapiste();
                skripti.randomkentta();

            }
            else
            {
                skripti.vahennaelama();
                skripti.randomkentta();
            }


        }

        

	}



 
}
