using UnityEngine;
using System.Collections;

public class horse : MonoBehaviour {
    public Transform target;
    private Vector3 location;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        location = target.position;
        location.z = location.z + 0.1f;
        this.transform.position = location;
	}


}
