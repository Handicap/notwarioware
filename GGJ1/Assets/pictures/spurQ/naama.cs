using UnityEngine;
using System.Collections;

public class naama : MonoBehaviour {

	// Use this for initialization
    public Vector3 paikka1;
    public Vector3 paikka2;
	
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void naamaan()
    {
        this.transform.position = paikka1;

    }

    public void pois()
    {

        this.transform.position = paikka2;
    }
}
