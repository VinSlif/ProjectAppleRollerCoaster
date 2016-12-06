using UnityEngine;
using System.Collections;

public class IsInTrigger : MonoBehaviour {

	public bool IsIn = false;

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Cam Trigger") {
			IsIn = true;
		}
	}

	void OnTriggerExit(Collider col) {
		if (col.gameObject.tag == "Cam Trigger") {
			IsIn = false;
		}
	}
}