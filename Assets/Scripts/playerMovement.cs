using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

	public GameObject camera01;
	public float playerSpeed;
	public float playerAirSpeed;
	public int jumpHeight;
	public float jumpray;
	public float rotationSpeed;

	private Rigidbody body;
	private bool isJumping = false;
	private float maxSpeed;
	private float sprintModefier;
	private Animator anim;
	private bool camFrontBack = true;


	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 rotering = transform.localEulerAngles;

		if (Input.GetKeyDown ("v")) {
				camFrontBack = !camFrontBack;
			}

		if (camFrontBack) {
			camera01.transform.localPosition = new Vector3 (0.0f, 2.49f, -6.16f);
			rotering.y = 0.0f;
		} else {
			camera01.transform.localPosition = new Vector3 (0.0f, 2.49f, 6.16f);
			rotering.y = 180.0f;
		}

		camera01.transform.localEulerAngles = rotering;
	}

	void FixedUpdate ()
	{
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");
		float sprint = Input.GetAxis ("Sprint");

		Vector3 totMove = new Vector3 (0.0f, 0.0f, vertical);
		totMove = totMove.normalized;

		RaycastHit hit;

		if (Physics.BoxCast (transform.position, new Vector3 (0.3f, 0.6f, 1.5f), Vector3.down, out hit, transform.rotation, jumpray)) {
			if (Input.GetKey ("space") && !isJumping) {
				body.AddForce (0, jumpHeight, 0);
				isJumping = true;
			}
			isJumping = false;
		} else {
			isJumping = true;
		}

		if (vertical != 0.0f) {
			anim.SetBool ("Running", true);
		} else {
			anim.SetBool ("Running", false);
		}

		transform.Rotate (0.0f, horizontal * rotationSpeed, 0.0f);

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
			maxSpeed = 7;
		} else {
			maxSpeed = 3;
		}
		Debug.DrawRay (transform.position, Vector3.down);
		print (hit.transform);
	}
}
