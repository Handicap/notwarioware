using UnityEngine;
using System.Collections;

public class siittiokamera : MonoBehaviour {
    public Transform target;
    private Vector3 location;
    public float muutos = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (target == null) return;

        location = this.transform.position;
        location.x = target.position.x + muutos;
        this.transform.position = location;
	}
}
