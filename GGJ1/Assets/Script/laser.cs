using UnityEngine;
using System.Collections;

public class laser : MonoBehaviour {
    public Vector3 paikka1;
    public Vector3 paikka2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void iske()
    {

        this.transform.position = paikka1;
    }

}
