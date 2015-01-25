using UnityEngine;
using System.Collections;

public class vaki : MonoBehaviour {
    public float speed;
    public Transform target;
    public bool active = false;
    public float angle;
    public float rotationSpeed = 3.0f;
    Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!active) return;
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        angle += 400 * Time.deltaTime * rotationSpeed;
        transform.eulerAngles = new Vector3(0, 0, angle);
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


    public void pum()
    {
        active = true;

    }
}
