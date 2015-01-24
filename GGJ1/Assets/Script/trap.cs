using UnityEngine;

using System.Collections;

public class trap : MonoBehaviour {

    public float Speed = -1f;
    public int type;
    static int count;
    public float vali;

	// Use this for initialization
	void Start () {

        type = ++count;

        int rand = UnityEngine.Random.Range(-1, 2);

        transform.position = new Vector3(1.8604f * rand, type * 5 + vali); //= -1.8604f;
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(0, Speed, 0);
	}
}
