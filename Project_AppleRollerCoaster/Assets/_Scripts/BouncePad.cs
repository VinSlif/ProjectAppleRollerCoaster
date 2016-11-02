using UnityEngine;
using System.Collections;

public class BouncePad : MonoBehaviour {

	public float bForce = 10.0f;

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Player") {
			collision.rigidbody.AddForce (Vector3.up * bForce, ForceMode.VelocityChange);
		}
	}
}