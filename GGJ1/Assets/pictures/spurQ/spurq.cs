using UnityEngine;
using System.Collections;

public class spurq : MonoBehaviour {

    public Transform iloinen;
    public Transform normi;
    public Transform vihanen;

    public Transform[] hatut = new Transform[7];

    public Transform edellinen;
    public int oikea;
    public int index = 0;
    public float kasvunopeus;
    public float movespeed;

    public bool end = false;

    public int kasvuaika;
    public int moveaika;
    public Vector3 moveposition;


	// Use this for initialization
	void Start () {

        oikea = UnityEngine.Random.Range(0, 7);
        
	}
	
	// Update is called once per frame
	void Update () {

        if (end) return;
                
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            index++;
            if (index >= hatut.Length) index = 0;

            if (index == oikea) ilo();
            else norm();

            hatut[index].transform.SendMessage("naamaan");
            if (edellinen == null)
            {
                edellinen = hatut[index];
                return;
            }
            edellinen.transform.SendMessage("pois");
            edellinen = hatut[index];

            
        }


        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            index--;
            if (index < 0) index = hatut.Length - 1;

            if (index == oikea) ilo();
            else norm();

            hatut[index].transform.SendMessage("naamaan");
            if (edellinen == null)
            {
                edellinen = hatut[index];
                return;
            }
            edellinen.transform.SendMessage("pois");
            edellinen = hatut[index];
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (index == oikea) win();
            else lose();

        }

	}

    public void lose()
    {
        StartCoroutine(thiscoroutine2());
        StartCoroutine(thiscoroutine());
        
        end = true;
        suru();
    }


    public void win()
    {
        StartCoroutine(thiscoroutine2());
        StartCoroutine(thiscoroutine());
        
        end = true;
        ilo();
    }

    public void ilo()
    {
        iloinen.transform.SendMessage("naamaan");
        normi.transform.SendMessage("pois");
        vihanen.transform.SendMessage("pois");
    }

    public void norm()
    {
        iloinen.transform.SendMessage("pois");
        normi.transform.SendMessage("naamaan");
        vihanen.transform.SendMessage("pois");
    }

    public void suru()
    {
        iloinen.transform.SendMessage("pois");
        normi.transform.SendMessage("pois");
        vihanen.transform.SendMessage("naamaan");
    }

    IEnumerator thiscoroutine2()
    {
        for (int i = 0; i < moveaika; i++)
        {
            yield return new WaitForSeconds(0.1f);

            float step = movespeed * Time.deltaTime;

            if (transform.position.Equals(moveposition)) transform.position = moveposition;

            else transform.position = Vector3.MoveTowards(transform.position, moveposition, step);

            //this.transform.position = moveposition;
        }
    }

    IEnumerator thiscoroutine()
    {
        for (int i = 0; i < kasvuaika; i++)
        {
            yield return new WaitForSeconds(0.1f);
            transform.localScale += new Vector3(kasvunopeus, kasvunopeus, kasvunopeus);
        }
    }
}
