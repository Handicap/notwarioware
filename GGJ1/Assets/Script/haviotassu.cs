using UnityEngine;
using System.Collections;

public class haviotassu : MonoBehaviour {

    public Vector3 target;
    public Vector3 target2;

    public Transform nappis;
    public bool action = false;
    public bool smash = false;
    public float speed;
    public float speed2;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (smash)
        {
            StartCoroutine(thiscoroutine());
            smash = false;
        }

        if (!action) return;
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);


        if (transform.position.Equals(target))
        {
            action = false;
            smash = true;

        }
	}


    public void activ()
    {
        
        
        action = true;
    }


    IEnumerator thiscoroutine()
    {
        nappis.SendMessage("viskaa");

        transform.localScale += new Vector3(0.2F, 0.2F, 0.2F);
        for (int i = 0; i < 10; i++)
        {

            yield return new WaitForSeconds(0.001f);

            float step = speed2 * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target2, step);
            if (transform.position.Equals(target2)) continue;

            transform.localScale += new Vector3(0.2F, 0.2F, 0.2F);
        }
    }
}
//-1.2426
//1.0445