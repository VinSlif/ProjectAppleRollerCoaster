using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

	public float camSpeed = 1.0f;
	public bool lookAt = false;

	private int index = 0;

	private GameObject player;

	public GameObject[] camPos;
	private GameObject[] trigPos;

	private GameObject trigger;

	// Use this for initialization
	void Awake() {

		player = GameObject.FindGameObjectWithTag("Player");
		trigger = GameObject.Find("TriggerBox");

		// sort camera position names
//		camPos = GameObject.FindGameObjectsWithTag("Cam Pos");
//		SortAscendingOrder(camPos);

		// sort trigger position names
		trigPos = GameObject.FindGameObjectsWithTag("Cam Trigger Pos");
		SortAscendingOrder(trigPos);

		// initialize placement
		MoveTrigger(index);
		MoveCam(index);
	}

	// Update is called once per frame
	void Update() {
		
		if (player.GetComponent<IsInTrigger>().IsIn) {
//			index += (DetermineScreenSideLeft(player)) ? -1 : 1;
			index++;

			if (index < 0) {
				index = 0;
			} else if (index > camPos.Length - 1) {
				index = camPos.Length - 1;
			}
		}

		MoveTrigger(index);
		MoveCam(index);
	}

	bool DetermineScreenSideLeft(GameObject target) {
		if (Camera.main.WorldToScreenPoint(target.transform.position).x < Screen.width / 2) {
			return true;
		} else {
			return false;
		}
	}

	void MoveCam(int n) {
		Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position,
			camPos[n].transform.position,
			camSpeed * Time.deltaTime);
		if (lookAt) {
			Camera.main.transform.LookAt(player.transform.position);
		} else {
			Camera.main.transform.eulerAngles = camPos[n].transform.eulerAngles;
		}
	}

	void MoveTrigger(int n) {
//		if (!leftSide) {
			trigger.transform.position = trigPos[n].transform.position;
			trigger.transform.eulerAngles = trigPos[n].transform.eulerAngles;
			trigger.transform.localScale = trigPos[n].transform.localScale;
//		} else {
//			trigger.transform.position = trigPos[n+1].transform.position;
//			trigger.transform.eulerAngles = trigPos[n+1].transform.eulerAngles;
//			trigger.transform.localScale = trigPos[n+1].transform.localScale;
//		}
	}

	void SortAscendingOrder(GameObject[] sorting) {
		for (int i = 0; i < sorting.Length; i++) {
			for (int j = 0; j < sorting.Length - 1; j++) {
				float getNum = float.Parse(sorting[j].name.Substring(sorting[j].name.IndexOf("(") + 1,
					sorting[j].name.Length - 2 - sorting[j].name.IndexOf("(")));
				float nextNum = float.Parse(sorting[j+1].name.Substring(sorting[j+1].name.IndexOf("(") + 1,
					sorting[j+1].name.Length - 2 - sorting[j+1].name.IndexOf("(")));

				if (getNum > nextNum) {
					GameObject temp = sorting[j];
					sorting[j] = sorting[j+1];
					sorting[j+1] = temp;
				}
			}
		}
	}
}