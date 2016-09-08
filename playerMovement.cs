using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

	public GameObject camera01;
	public float playerSpeed;
	public float playerAirSpeed;
	public float maxSpeed;
	public float sprintModefier;
	public int jumpHeight;
	public float jumpray;

	private Rigidbody body;
	private bool isJumping = false;


	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Euler (0, camera01.GetComponent<mouseLook> ().currentYRotation, 0);
		//print (body.velocity.x + body.velocity.z);
	}

	void FixedUpdate ()
	{
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");
		float sprint = Input.GetAxis ("Sprint");

		Vector3 totMove = new Vector3 (horizontal, 0.0f, vertical);
		totMove = totMove.normalized;

		if (!isJumping) {
			Vector3 moveSpeed = body.velocity;
			if (moveSpeed.magnitude < maxSpeed) {
				body.AddRelativeForce (totMove * playerSpeed);
			}
		} else {
			Vector3 moveSpeed = body.velocity;
			if (moveSpeed.magnitude < maxSpeed) {
				body.AddRelativeForce (totMove * playerAirSpeed);
			}
		}
			
		if (sprint == 1) {
			maxSpeed = 10;
		} else if (sprint == 0) {
			maxSpeed = 5;
		} else {
			maxSpeed = 3;
		}

		RaycastHit hit;

		if (Physics.BoxCast (transform.position, new Vector3 (0.40f, 0.9f, 0.40f), Vector3.down, out hit, transform.rotation, jumpray)) {
			if (Input.GetKey ("space") && !isJumping) {
				body.AddForce (0, jumpHeight, 0);
				isJumping = true;
			}
			isJumping = false;
		} else {
			isJumping = true;
		}
	}
}
