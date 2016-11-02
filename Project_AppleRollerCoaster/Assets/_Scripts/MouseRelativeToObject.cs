using UnityEngine;
using System.Collections;

public class MouseRelativeToObject : MonoBehaviour {

	void Update () {

		if (Input.GetMouseButtonDown (0)) {
			Vector2 mouse = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);

			Ray ray;
			ray = Camera.main.ScreenPointToRay (mouse);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit)) {
				Debug.Log (hit.distance);
//			if (hit.point.x < transform.position.x) {
//				Debug.Log ("Left");
//			} else {
//				Debug.Log ("Right");
//			}
			}
		}
	}
}