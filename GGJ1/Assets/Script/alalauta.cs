using UnityEngine;
using System.Collections;

public class alalauta : MonoBehaviour {
    public float speed;
    public GameObject kohde;
    public float angle;
    public float rotationSpeed = 3.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void win()
    {
        Debug.Log("shit");
        rigidbody2D.velocity = kohde.transform.position * speed;
        angle += 400 * Time.deltaTime * rotationSpeed;
        transform.eulerAngles = new Vector3(0, 0, angle);

    }
}
