using UnityEngine;
using System.Collections;

public class golfball1 : MonoBehaviour {
    public int invert;
    public float speed;
    public float stoppingspeed;
    public float speedup;
    public float speeddown;
    public float speedleft;
    public float speedright;

    public GameObject kontrolleri;

	// Use this for initialization
	void Start () {
        kontrolleri = GameObject.FindGameObjectWithTag("GameController");
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (speedleft < speed) speedleft += stoppingspeed;
            else speedleft = speed;
            //Vector3 position = this.transform.position;
            //position.x = position.x - speed;
            //this.transform.position = position;
        }
        else
        {
            if (0 < speedleft) speedleft = speedleft - stoppingspeed;
            if (0 > speedleft) speedleft = 0f;

        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            //speedright = speed;
            if (speedright < speed) speedright += stoppingspeed;
            else speedright = speed;
            //Vector3 position = this.transform.position;
            //position.x = position.x + speed;
            //this.transform.position = position;
        }
        else
        {
            if (0 < speedright) speedright = speedright - stoppingspeed;
            if (0 > speedright) speedright = 0f;

        }


        if (Input.GetKey(KeyCode.UpArrow))
        {
            //speedup = speed;
            if (speedup < speed) speedup += stoppingspeed;
            else speedup = speed;
            //Vector3 position = this.transform.position;
            //position.y = position.y + speed;
            //this.transform.position = position;
        }
        else
        {
            if (0 < speedup) speedup = speedup - stoppingspeed;
            if (0 > speedup) speedup = 0f;

        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            //speeddown = speed;
            if (speeddown < speed) speeddown += stoppingspeed;
            else speeddown = speed;
            //Vector3 position = this.transform.position;
            //position.y = position.y - speed;
            //this.transform.position = position;
        }
        else
        {
            if (0 < speeddown) speeddown = speeddown - stoppingspeed;
            if (0 > speeddown) speeddown = 0f;
        }

        move();

	}

    void move()
    {
        Vector3 position = this.transform.position;
        position.x = position.x + speedleft;
        this.transform.position = position;
        position.x = position.x - speedright;
        this.transform.position = position;
        position.y = position.y - speedup;
        this.transform.position = position;
        position.y = position.y + speeddown;
        this.transform.position = position;

        
        
        
      

    }




    void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.collider.tag == "maali")
        {
            win();
        }

        if (coll.collider.tag == "laita")
        {
            lose();
        }


    }

    void win()
    {
        Debug.Log("you win");

        Game_logic_controller skripti = kontrolleri.GetComponent<Game_logic_controller>();
        skripti.lisaapiste();
        skripti.randomkentta();

    }

    void lose()
    {
        Debug.Log("you lose");

        Game_logic_controller skripti = kontrolleri.GetComponent<Game_logic_controller>();
        skripti.vahennaelama();
        skripti.randomkentta();

    }


}
