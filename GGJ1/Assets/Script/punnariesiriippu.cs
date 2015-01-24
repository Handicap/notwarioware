using UnityEngine;
using System.Collections;

public class punnariesiriippu : MonoBehaviour {

    // -1 vasen, 1 oikea
    public int dir;
    public bool auki = true;

    public float avonaisuus = 0;
    public float maksimi = 4;
    public float offset = 8.0f;
    public float speed = 6;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        if (auki && avonaisuus < maksimi)
        {
            transform.Translate(dir * speed * Time.deltaTime, 0, 0);
            avonaisuus = avonaisuus + Time.deltaTime;
        }else if (!auki && avonaisuus >= 0)
        {
            transform.Translate(-dir * speed * Time.deltaTime, 0, 0);
            avonaisuus = avonaisuus - Time.deltaTime;
        }

	}
}
