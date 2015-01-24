using UnityEngine;
using System.Collections;

public class menuvalitsin : MonoBehaviour {

    public float speed = 20;

	// Use this for initialization
	void Start () {
        Debug.Log("Trigger: " + collider2D.isTrigger);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("left"))
        {
            transform.Translate(Vector3.left*Time.deltaTime*speed);
        }

        if (Input.GetKey("right"))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

        if (Input.GetKey("up"))
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }

        if (Input.GetKey("down"))
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }
        
	}
}
