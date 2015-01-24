using UnityEngine;
using System.Collections;

public class meteori : MonoBehaviour {

    public float speed;
    public Transform target;

    Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
	}


    void OnCollisionEnter2D(Collision2D coll)
    {
        speed = 0.1f;
        anim.SetBool("pum", true);
        StartCoroutine(killCoroutine());


    }


    IEnumerator killCoroutine()
    {
      
            

            yield return new WaitForSeconds(1);
            Destroy(gameObject);

        }
}


