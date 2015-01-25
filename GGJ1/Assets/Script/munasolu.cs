using UnityEngine;
using System.Collections;

public class munasolu : MonoBehaviour {
    Animator anim;


    public GameObject kontrolleri;
    

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        kontrolleri = GameObject.FindGameObjectWithTag("GameController");
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void rajahda()
    {
        Debug.Log("Pum!");
        anim.SetBool("pum", true);
        StartCoroutine(wincoroutine());
    }

    IEnumerator wincoroutine()
    {
        yield return new WaitForSeconds(3.5f);
        Game_logic_controller skripti = kontrolleri.GetComponent<Game_logic_controller>();
        skripti.lisaapiste();
        skripti.randomkentta();
    }
}
