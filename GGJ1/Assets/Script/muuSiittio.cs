using UnityEngine;
using System.Collections;

public class muuSiittio : MonoBehaviour {
    public float angle2;
    public float angle3;
    public float movingSpeed;
    public float angle;
    public float rotationSpeed = 0.001f;
    public float speed;
    public GameObject target;
    public Vector3 direction;
    public float currentDistance;
	// Use this for initialization
	void Start () {
        direction = new Vector3(0, 0, 0);


	}
	
	// Update is called once per frame
	void Update () {
        
        angle = ((transform.position.y - target.transform.position.y) / (transform.position.x - target.transform.position.x));
        if (transform.position.x < target.transform.position.x) direction = -direction;

        countMovingDirection();

        rigidbody2D.velocity = direction * movingSpeed;

        
	}
        

     public void countMovingDirection()
    {
        if (angle <= -0.75)
        {
            direction.x = 0f;
            direction.y = 1f;

        }
        else if (angle <= -0.25 && angle > -0.75)
        {
            direction.x = -0.7070707f;
            direction.y = 0.7070707f;
        }
        else if (angle <= 0.25 && angle > -0.25)
        {
            direction.x = -1f;
            direction.y = 0f;
        }
        else if (angle > 0.75)
        {
            direction.x = 0f;
            direction.y = -1f;
        }
        else if (angle > 0.25 && angle <= 0.75)
        {
            direction.x = -0.7070707f;
            direction.y = -0.7070707f;
        }
        else rigidbody2D.velocity = Vector2.zero;



         if (transform.position.x < target.transform.position.x) direction = -direction;

         rigidbody2D.velocity = direction * movingSpeed;
         //transform.eulerAngles = new Vector3(0, 0, -1);
    }

    public void coundDistance()
    {
        if (Vector3.Distance(transform.position, target.transform.position) < 0) currentDistance = -Vector3.Distance(transform.position, target.transform.position);
        else currentDistance = Vector3.Distance(transform.position, target.transform.position);

    }

       
	}

