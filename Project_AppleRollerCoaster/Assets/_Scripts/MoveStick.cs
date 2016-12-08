using UnityEngine;
using System.Collections;

public class MoveStick : MonoBehaviour {

	public GameObject stickVisual;
	public GameObject target;

	public GameObject secondaryVisual;
	public GameObject secondaryTarget;
	public float speed = 1.0f;

	private bool activated = false;

	void Awake() {
		GetComponent<MeshCollider>().enabled = true;
		if (target.GetComponent<MeshCollider>()) {
			target.GetComponent<MeshCollider>().enabled = false;
		}
		if (secondaryTarget != null) {
			target.GetComponent<MeshCollider>().enabled = true;
			if (secondaryTarget.GetComponent<MeshCollider>()) {
				secondaryTarget.GetComponent<MeshCollider>().enabled = false;
			}
		}
	}

	void Update() {
		if (activated) {
			stickVisual.transform.position = Vector3.Lerp(stickVisual.transform.position,
				target.transform.position,
				speed * Time.deltaTime);
			stickVisual.transform.rotation = Quaternion.Lerp(stickVisual.transform.rotation,
				target.transform.rotation,
				speed * Time.deltaTime);
			if (secondaryTarget != null) {
				if (Mathf.Abs(stickVisual.transform.position.x) - Mathf.Abs(target.transform.position.x) < 1.0f &&
					Mathf.Abs(stickVisual.transform.position.y) - Mathf.Abs(target.transform.position.y) < 1.0f &&
					Mathf.Abs(stickVisual.transform.position.z) - Mathf.Abs(target.transform.position.z) < 1.0f) {

					target.GetComponent<MeshCollider>().enabled = false;
					if (secondaryTarget.GetComponent<MeshCollider>()) {
						secondaryTarget.GetComponent<MeshCollider>().enabled = true;
					}

					stickVisual.transform.position = Vector3.Lerp(stickVisual.transform.position,
						secondaryTarget.transform.position,
						speed * Time.deltaTime);
					stickVisual.transform.rotation = Quaternion.Lerp(stickVisual.transform.rotation,
						secondaryTarget.transform.rotation,
						speed * Time.deltaTime);
					
					secondaryVisual.transform.position = Vector3.Lerp(secondaryVisual.transform.position,
						secondaryTarget.transform.position,
						speed * Time.deltaTime);
					secondaryVisual.transform.rotation = Quaternion.Lerp(secondaryVisual.transform.rotation,
						secondaryTarget.transform.rotation,
						speed * Time.deltaTime);
				}
			}
		}
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Player") {
			GetComponent<MeshCollider>().enabled = false;
			if (target.GetComponent<MeshCollider>()) {
				target.GetComponent<MeshCollider>().enabled = true;
			}
			activated = true;
		}
	}
}