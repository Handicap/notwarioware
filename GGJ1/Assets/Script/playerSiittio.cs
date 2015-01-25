using UnityEngine;
using System.Collections;

public class playerSiittio : MonoBehaviour {

    public float angle2;
    public float angle3;

    public float angle;
    public float rotationSpeed = 0.001f;
    public float speed;
    public GameObject target;
    public Vector3 direction;

    public GameObject solu;

    public int hits = 10;


    public GameObject kontrolleri;
    
	// Use this for initialization
	void Start () {
        direction = new Vector3(0, 0, 0);
        kontrolleri = GameObject.FindGameObjectWithTag("GameController");
        
	}
	
	// Update is called once per frame
	void Update () {

        //rigidbody2D.velocity = direction * movingSpeed;

        angle2 = ((transform.position.y - target.transform.position.y) / (transform.position.x - target.transform.position.x));
        angle3 = ((transform.position.x - target.transform.position.x) / (transform.position.y - target.transform.position.y));

        direction.y = angle2;
        direction.x = angle3;
        rigidbody2D.velocity = Vector3.zero;
        

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            
            rigidbody2D.velocity = direction * speed;

            angle += 40 * Time.deltaTime * rotationSpeed;
            transform.eulerAngles = new Vector3(0, 0, angle);
           
        }
       

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {


            rigidbody2D.velocity = direction * speed;

            angle -= 40 * Time.deltaTime * rotationSpeed;
            transform.eulerAngles = new Vector3(0, 0, angle);

            
        }
       

        

	
	}



    void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.collider.tag == "maali")
        {
            hits -= 1;
            if (hits <= 0) win();
        }

        if (coll.collider.tag == "laita")
        {
            lose();
        }


    }


    void win()
    {
        

        solu.SendMessage("rajahda");
        Destroy(gameObject);
    }


    void lose()
    {
        Debug.Log("you lose");
         //or if distance < attactDistance * 2
        StartCoroutine(losecoroutine());
    }

    IEnumerator losecoroutine()
    {
        yield return new WaitForSeconds(3.5f);
        Game_logic_controller skripti = kontrolleri.GetComponent<Game_logic_controller>();
        skripti.vahennaelama();
        skripti.randomkentta();
    }

}
