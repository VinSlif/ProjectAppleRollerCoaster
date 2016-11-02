using UnityEngine;
using System.Collections;

public class ApplyForceMouseDirection : MonoBehaviour {

	public float maxSpeed = 10.0f;
	public float driftSpeed = 3.0f;
	public float accelerationAdd = 4.0f;
	public float accelerationSubtract = 1.0f;

	private Rigidbody rb;
	private float accelSpeed3D;

	void Awake() {
		if (gameObject.GetComponent<Rigidbody> ()) {
			rb = gameObject.GetComponent<Rigidbody> ();
		}
	}

	void FixedUpdate () {

		if (Input.GetMouseButtonDown (0)) {
			Vector2 mouse = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);

			Ray ray;
			ray = Camera.main.ScreenPointToRay (mouse);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit)) {
				Vector3 mouseDir = hit.point - gameObject.transform.position;
				mouseDir = mouseDir.normalized;

				rb.AddForce (mouseDir * hit.distance);
			}
		}
	}
}