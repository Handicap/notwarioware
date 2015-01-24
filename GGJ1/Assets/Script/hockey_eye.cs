using UnityEngine;
using System.Collections;

public class hockey_eye : MonoBehaviour {

    //public Vector3 debugvector;
    public float timer = 0;
    public float rapaytysraja = 2f;
    public float kohdeaika;
    public float maksimihajonta = 8f;
    public float iskunaika = 0.2f;
    public bool isketty = false;

	// Use this for initialization
	void Start () {
        uusiaika();
	}

    public void uusiaika()
    {
        kohdeaika = rapaytysraja + Random.Range(0.0f, maksimihajonta);
        timer = 0f;
    }

    public void aseta(GameObject kohde)
    {
        Vector3 kohdevektori = kohde.transform.position;
        kohdevektori.x = kohdevektori.x - 0.43f;
        kohdevektori.y = kohdevektori.y + 0.32f;
        transform.position = kohdevektori;
        //-0.43 0.32
    }
	
	// Update is called once per frame
	void Update () {

        timer = timer + Time.deltaTime;

        if (timer > iskunaika && timer < kohdeaika) renderer.enabled = false;

        if (timer > kohdeaika && isketty == false)
        {
            renderer.enabled = true;
            uusiaika();
            isketty = true;
        }
        //transform.position = debugvector;

	}
}
