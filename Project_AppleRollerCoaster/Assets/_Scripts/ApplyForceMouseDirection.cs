using UnityEngine;
using System.Collections;

public class ApplyForceMouseDirection : MonoBehaviour {

	public float scale = 1.0f;

	private Rigidbody rb;
	private float distToGround;

	public float forceFactor;
	public Vector3 mouseDir;

	void Awake() {
		if (gameObject.GetComponent<Rigidbody> ()) {
			rb = gameObject.GetComponent<Rigidbody> ();
		}

		if (gameObject.GetComponent<Collider> ()) {
			distToGround = gameObject.GetComponent<Collider> ().bounds.extents.y;
		} else {
			distToGround = 0.5f;
		}
	}

	void FixedUpdate () {
		if (Input.GetButton("Fire1") && IsGrounded()) {
			
			Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit mouseHit;

			if (Physics.Raycast (mouseRay, out mouseHit)) {
				mouseDir = (mouseHit.point - gameObject.transform.position).normalized;

				forceFactor = mouseHit.distance * scale;
				rb.AddForce (mouseDir * (mouseHit.distance * scale));
			}
		}
	}

	bool IsGrounded() {
		return Physics.Raycast (gameObject.transform.position, -Vector3.up, distToGround + 0.1f);
	}
}