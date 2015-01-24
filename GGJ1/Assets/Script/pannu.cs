using UnityEngine;
using System.Collections;

public class pannu : MonoBehaviour {
    public float minX;
    public float maxX;
   
    public float speed;
    

    public bool pressed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.Space))
        {
            pressed = true;

        }


        if (!pressed)
        {

            if (transform.position.x > minX && transform.position.x < maxX)
            {

                Vector3 position = this.transform.position;

                position.x = position.x + speed;
                //position.y = 0;
                //position.z = 0;
                this.transform.position = position;
                //transform.Translate(position);
            }
            else
            {

                speed = speed * -1;
                Vector3 position = this.transform.position;

                position.x = position.x + speed;
                //position.y = 0;
                //position.z = 0;
                this.transform.position = position;
            }


        }
        else
        {
            Vector3 position = this.transform.position;
            this.transform.position = position;

        }

	}
}
