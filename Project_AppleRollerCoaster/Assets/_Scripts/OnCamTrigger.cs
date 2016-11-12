using UnityEngine;
using System.Collections;

public class OnCamTrigger : MonoBehaviour {

	public bool InTrigger = false;

	void OnTriggerEnter(Collider col){
		if (col.tag == "Cam Trigger") {
			InTrigger = true;
		}
	}

	void OnTriggerExit(Collider col) {
		if (col.tag == "Cam Trigger") {
			InTrigger = false;
		}
	}
}