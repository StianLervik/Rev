using UnityEngine;
using System.Collections;

public class mouseLook : MonoBehaviour {
	public float lookSensitivity = 5f;
	public float xRotation;
	public float yRotation;
	public float currentXRotation;
	public float currentYRotation;
	public float xRotationV;
	public float yRotationV;
	public float lookSmoothDamp = 0.1f;
	public float interactDistance;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		xRotation -= Input.GetAxis ("Mouse Y") * lookSensitivity;
		yRotation += Input.GetAxis ("Mouse X") * lookSensitivity;

		xRotation = Mathf.Clamp (xRotation, -90, 90);

		currentXRotation = Mathf.SmoothDamp (currentXRotation, xRotation, ref xRotationV, lookSmoothDamp);
		currentYRotation = Mathf.SmoothDamp (currentYRotation, yRotation, ref yRotationV, lookSmoothDamp);

		transform.rotation = Quaternion.Euler (currentXRotation, currentYRotation, 0);
	}

	void FixedUpdate()
	{
		/*RaycastHit hit;

		if (Physics.Raycast (transform.position, transform.forward, out hit, interactDistance)) {
		}*/
	}
}
