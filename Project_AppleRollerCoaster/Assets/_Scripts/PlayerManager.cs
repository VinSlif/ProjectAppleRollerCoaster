using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	public GameObject cursorPrefab;
	private GameObject customCursor;

	// Use this for initialization
	void Awake () {

		if (cursorPrefab != null) {
			// hide cursor
			UnityEngine.Cursor.visible = false;

			// create custom cursor
			customCursor = (GameObject)Instantiate (cursorPrefab, new Vector3(0, 0, 0), Quaternion.identity);
			customCursor.transform.parent = gameObject.transform;
			customCursor.transform.SetSiblingIndex (0);

			// set cursor position
			Ray mouseRay = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit mouseHit;

			if (Physics.Raycast (mouseRay, out mouseHit)) {
				customCursor.SetActive(true);
				customCursor.transform.position = new Vector3 (mouseHit.point.x, mouseHit.point.y, mouseHit.point.z);
			} else {
				customCursor.SetActive (false);
			}
		}
	}

	// Update is called once per frame
	void Update () {

		// move cursor
		Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit mouseHit;

		if (Physics.Raycast (mouseRay, out mouseHit)) {
			customCursor.SetActive(true);
			customCursor.transform.position = new Vector3 (mouseHit.point.x, mouseHit.point.y, mouseHit.point.z);
		} else {
			customCursor.SetActive (false);
		}
	}
}