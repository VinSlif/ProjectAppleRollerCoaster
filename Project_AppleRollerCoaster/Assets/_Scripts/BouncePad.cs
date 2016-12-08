using UnityEngine;
using System.Collections;

public class BouncePad : MonoBehaviour {

	public float bForce = 10.0f;
	public bool isAngled = false;

	private Animator anim;

	private GameObject sporeParticle;

	void Awake() {
		anim = GetComponent<Animator>();

		foreach (Transform t in transform) {
			if (t.name == "Mushroom_Poof_part") {
				sporeParticle = t.gameObject;
				break;
			}
		}
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Player") {
			if (isAngled) {
				anim.Play("Angled_Bounce");
			} else {
				anim.Play("Normal_Bounce");
			}
			
			sporeParticle.GetComponent<ParticleSystem>().Play();
			col.rigidbody.AddForce (-col.contacts[0].normal * bForce, ForceMode.VelocityChange);
		}
	}
}