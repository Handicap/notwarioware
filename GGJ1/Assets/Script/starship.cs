using UnityEngine;
using System.Collections;

public class starship : MonoBehaviour {
    public float speed;
    public float speed2;
    public bool losed = false;
    Animator anim;

	// Use this for initialization
	void Start () {

        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 position = this.transform.position;

        position.x = position.x + speed;
        this.transform.position = position;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            position.y = position.y + speed2;
            this.transform.position = position;
        }
        

        if (Input.GetKey(KeyCode.DownArrow))
        {

            position.y = position.y - speed2;
            this.transform.position = position;
        }
        

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
        speed = 0;
        speed2 = 0;
    }

    void lose()
    {
        anim.SetBool("losed", true);
        Debug.Log("you lose");
        losed = true;
        speed = 0;
        speed2 = 0;

    }


}
