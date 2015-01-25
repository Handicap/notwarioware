using UnityEngine;

using System.Collections;

public class trap : MonoBehaviour {

    public float Speed = -1f;
    public int type;
    static int count;
    public float vali;
    public float vali2 = 1.8604f;
    public float vali3 = 5f;

	// Use this for initialization
	void Start () {

        type = ++count;

        if (count > 25) count = 0;

        int rand = UnityEngine.Random.Range(-1, 2);

        transform.position = new Vector3(vali2 * rand, type * vali3 + vali); //= -1.8604f;
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(0, Speed, 0);
	}

    public void stop()
    {
        Speed = 0;

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Speed = 0;
        //transform.Translate(0, 0, 0);
        
        transform.parent.SendMessage("stop");
        StartCoroutine(thiscoroutine());

    }


    IEnumerator thiscoroutine()
    {
        yield return new WaitForSeconds(0.001f);
        //Destroy(gameObject);
    }
}
