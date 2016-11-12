using UnityEngine;
using System.Collections;

public class BouncePad : MonoBehaviour {

	public float bForce = 10.0f;

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.GetComponent<Rigidbody>()) {
			col.rigidbody.AddForce (-col.contacts[0].normal * bForce, ForceMode.VelocityChange);
		}
	}
}