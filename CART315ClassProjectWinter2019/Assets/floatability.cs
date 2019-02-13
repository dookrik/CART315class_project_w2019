using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatability : MonoBehaviour {

	public Vector3 force = new Vector3(0,0,0);
	public Vector3 speed = new Vector3(10,2,0);
	public Rigidbody rb;
	//null for now
	public float viscosity= 1f;
	public float drag = 10f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		rb.velocity = new Vector3 (2, 0, 0);
	}

	// Update is called once per frame
	void Update () {
		if (transform.localPosition.y <= 0) {
			rb.AddForce (force);

			if (transform.localPosition.y <= -5) {
				print ("xx");
				rb.AddForce (rb.velocity * -drag * viscosity);
			}
		}
		print ("postition: " + transform.localPosition);
		print ("velocity: " + rb.velocity);
//		if (transform.localPosition.y <= -5){
//			rb.AddForce (force);
//		}
	}
		
}


