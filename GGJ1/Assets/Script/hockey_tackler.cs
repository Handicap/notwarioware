using UnityEngine;
using System.Collections;

public class hockey_tackler : MonoBehaviour {

    public float speed;
    public bool moving;
    [Range(0,2)]
    public int pelipaita;

    public GameObject[] pelaajat = new GameObject[3];

    public void valitse(int valinta)
    {
        pelaajat[valinta].renderer.enabled = true;
    }


    void Update()
    {
        if (moving)
        {
            transform.Translate(speed * -Time.deltaTime, 0, 0);
        }

    }
}
