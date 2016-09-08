using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {
	public float gravity;
	public float maxSpeed;

	private Rigidbody body;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate (){
		Vector3 nyGravity = new Vector3(0.0f, gravity, 0.0f);
		if (body.velocity.y < maxSpeed) {
			body.AddForce (nyGravity);
		}
	}
}
