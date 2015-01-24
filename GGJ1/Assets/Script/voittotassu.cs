using UnityEngine;
using System.Collections;

public class voittotassu : MonoBehaviour {
    public float speed;
    private bool action = false;
    private Vector3 target1;
    private bool push = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (push)
        {
            action = false;
            StartCoroutine(thiscoroutine());
            push = false;
        }

        if (!action) return;
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target1, step);


        if (transform.position.Equals(target1))
        {
            transform.localScale -= new Vector3(0.07F, 0.07F, 0.07F);
            push = true;
        }
	}


    public void activ(Vector3 target)
    {
        target.y = target.y - 0.59962f;
        target1 = target;
        action = true;
    }

    IEnumerator thiscoroutine()
    {
        yield return new WaitForSeconds(0.7f);
        transform.localScale += new Vector3(0.07F, 0.07F, 0.07F);
    }

}
