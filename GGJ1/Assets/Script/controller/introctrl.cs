using UnityEngine;
using System.Collections;

public class introctrl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	StartCoroutine(kentanvaihto());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator kentanvaihto()
    {
        yield return new WaitForSeconds(3.5f);
        Application.LoadLevel(1);
    }
}
