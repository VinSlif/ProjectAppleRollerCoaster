using UnityEngine;
using System.Collections;

public class AppleBehavior : MonoBehaviour {

	private bool firstClick = false;

	// Update is called once per frame
	void Update () {
		if (!firstClick) {
			if (Input.GetButton("Fire1")) {
				Global.startGame = true;
				this.GetComponent<Rigidbody>().useGravity = true;
			}
		}
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Trigger Box") {
			Global.index = int.Parse(col.name.Substring(col.name.IndexOf("(") + 1,
				col.name.Length - 2 - col.name.IndexOf("(")));
		}
	}
}