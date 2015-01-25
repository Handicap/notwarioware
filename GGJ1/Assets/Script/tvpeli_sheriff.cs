using UnityEngine;
using System.Collections;

public class tvpeli_sheriff : MonoBehaviour {

    public GameObject laukaus;
    public bool fade = false;
    public float timer = 0;


	// Use this for initialization
	void Start () {
        laukaus.SetActive(false);
        guiTexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
        guiTexture.color = Color.clear;
	}
	
	// Update is called once per frame
	void Update () {
        timer = timer + Time.deltaTime;
        if (fade)
        {
            guiTexture.color = Color.Lerp(guiTexture.color, Color.red, timer / 75);
        }
	}

    public void ammu()
    {
        fade = true;
        laukaus.SetActive(true);
        guiTexture.enabled = true;
    }
}
