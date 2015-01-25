using UnityEngine;
using System.Collections;

public class kelloskripti : MonoBehaviour {

    public float zrot = -180f;
    public float kerroin = -20f;
    public float raja_arvo = -540f;

    public GameObject kontrolleri;

	// Use this for initialization
	void Start () {
        kontrolleri = GameObject.FindGameObjectWithTag("GameController");
	}
	
	// Update is called once per frame
	void Update () {
        zrot = zrot + Time.deltaTime * kerroin;
        gameObject.transform.eulerAngles = new Vector3(0,0,zrot);

        if (zrot < raja_arvo)
        {
            Game_logic_controller skripti = kontrolleri.GetComponent<Game_logic_controller>();
            skripti.vahennaelama();
            skripti.randomkentta();
        }

	}
}
