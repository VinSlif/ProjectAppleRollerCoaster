using UnityEngine;
using System.Linq;
using System.Collections;

public class CameraManager : MonoBehaviour {

	public float camSpeed = 1.0f;
	public bool lookAt = false;
	private GameObject[] camPos;

	private GameObject player;

	// Use this for initialization
	void Awake() {
		
		// Get Player GameObject
		player = GameObject.FindGameObjectWithTag("Player");

		// sort camera position names
		camPos = GameObject.FindGameObjectsWithTag("Cam Pos").OrderBy(go => go.name).ToArray();
	}

	// Update is called once per frame
	void Update() {
		if (Global.startGame) {
			Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position,
				camPos[Global.index].transform.position,
				camSpeed * Time.deltaTime);
				
			if (lookAt) {
				Camera.main.transform.LookAt(player.transform.position);
			} else {
				Camera.main.transform.rotation = Quaternion.Lerp(Camera.main.transform.rotation,
					camPos[Global.index].transform.rotation,
					camSpeed * Time.deltaTime);
			}
		}
	}
}