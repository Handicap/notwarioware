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

        int rand = UnityEngine.Random.Range(-1, 2);

        transform.position = new Vector3(vali2 * rand, type * vali3 + vali); //= -1.8604f;
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(0, Speed, 0);
	}
}
