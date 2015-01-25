using UnityEngine;
using System.Collections;

public class nappis : MonoBehaviour {


    public Transform space;
    public Transform up;
    public Transform down;
    public Transform left;
    public Transform right;
    public Transform target;
    public Transform voittotassu;
    public Transform haviotassu1;
    public Transform haviotassu2;

    public float kasvunopeus;
    public float pyorimisnopeus;
    public bool kasvu;

    public GameObject kontrolleri;

	// Use this for initialization
	void Start () {

        kontrolleri = GameObject.FindGameObjectWithTag("GameController");

        int rand = UnityEngine.Random.Range(1, 6);


        switch (rand)
        {
            case 1:
                target = space;
                break;
            case 2:
                target = right;
                break;
            case 3:
                target = up;
                break;
            case 4:
                target = down;
                break;
            case 5:
                target = left;
                break;
            default:
                target = right;
                break;
        }


        target.position = new Vector3 (target.position.x, target.position.y, -1f);


	}
	
	// Update is called once per frame
	void Update () {

        if (kasvu)
        {
            transform.localScale += new Vector3(kasvunopeus, kasvunopeus, kasvunopeus);
            if (transform.localScale.x > 0.6f) kasvunopeus = kasvunopeus - 2f * Time.deltaTime;
            else kasvunopeus = 0;
            transform.Rotate(Vector3.right, 10);
            StartCoroutine(thiscoroutine());
            transform.Translate(0, 0.05f, 0, Space.World);
            
        }


        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (target == right)
            {
                win();
            }
            else
            {
                lose();
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (target == left)
            {
                win();
            }
            else
            {
                lose();
            }

        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (target == up)
            {
                win();
            }
            else
            {
                lose();
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (target == down)
            {
                win();
            }
            else
            {
                lose();
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (target == space)
            {
                win();
            }
            else
            {
                lose();
            }
        }

	
	}

    public void win()
    {
        voittotassu.SendMessage("activ", target.position);
        StartCoroutine(thatcoroutine());
    }


    public void lose()
    {
        haviotassu1.SendMessage("activ", target.position);
        haviotassu2.SendMessage("activ", target.position);
    }

    public void viskaa()
    {
        kasvu = true;

    }


    IEnumerator thiscoroutine()
    {
        yield return new WaitForSeconds(1.1f);
        Destroy(gameObject);
        Destroy(space);
        Destroy(up);
        Destroy(down);
        Destroy(left);
        Destroy(right);

        Debug.Log("you lose");

        Game_logic_controller skripti = kontrolleri.GetComponent<Game_logic_controller>();
        skripti.vahennaelama();
        skripti.randomkentta();

        /*
            public Transform space;
    public Transform up;
    public Transform down;
    public Transform left;
    public Transform right;*/

    }

    IEnumerator thatcoroutine()
    {
        yield return new WaitForSeconds(3.1f);

        Debug.Log("you win");

        Game_logic_controller skripti = kontrolleri.GetComponent<Game_logic_controller>();
        skripti.lisaapiste();
        skripti.randomkentta();

        /*
            public Transform space;
    public Transform up;
    public Transform down;
    public Transform left;
    public Transform right;*/

    }

}
