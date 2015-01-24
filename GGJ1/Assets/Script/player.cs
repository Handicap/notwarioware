using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

    public float angle;
    public float rotationSpeed = 3.0f;
    
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        


        if (Input.GetKey(KeyCode.LeftArrow))
        {

            


            angle += 400 * Time.deltaTime * rotationSpeed;
            transform.eulerAngles = new Vector3(0, 0, angle);

        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            



            angle -= 400 * Time.deltaTime * rotationSpeed;
            transform.eulerAngles = new Vector3(0, 0, angle);


        }



	}


    public void stop()
    {
        rotationSpeed = 0;
    }


    


}
