using UnityEngine;
using System.Collections;

public class SwitchCamera : MonoBehaviour {

	public Camera[] cameras;
	private int currentCameraIndex = 0;

	// Use this for initialization
	void Awake () {
		//Turn all cameras off, except the first default one
		for (int i=1; i < cameras.Length; i++) {
			cameras[i].gameObject.SetActive(false);
		}

		//If any cameras were added to the controller, enable the first one
		if (cameras.Length > 0) {
			cameras [currentCameraIndex].gameObject.SetActive (true);
		}
	}

	// Update is called once per frame
	void Update () {

		//If the c button is pressed, switch to the next camera
		//Set the camera at the current index to inactive, and set the next one in the array to active
		//When we reach the end of the camera array, move back to the beginning or the array.

		if (Input.GetKeyDown(KeyCode.C)) {
			currentCameraIndex ++;

			if (currentCameraIndex < cameras.Length){
				cameras [currentCameraIndex - 1].gameObject.SetActive (false);
				cameras [currentCameraIndex - 1].tag = "Untagged";
				cameras [currentCameraIndex].gameObject.SetActive (true);
				cameras [currentCameraIndex].tag = "MainCamera";
			} else {
				cameras [currentCameraIndex - 1].gameObject.SetActive (false);
				cameras [currentCameraIndex - 1].tag = "Untagged";
				currentCameraIndex = 0;
				cameras [currentCameraIndex].gameObject.SetActive (true);
				cameras [currentCameraIndex].tag = "MainCamera";
			}
		}
	}
}