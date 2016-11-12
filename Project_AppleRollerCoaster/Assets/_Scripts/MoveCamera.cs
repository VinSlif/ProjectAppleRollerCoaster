using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {

	public float camSpeed = 10.0f;

	public int index = 0;

	private GameObject player;

	private GameObject[] camPos;
	private GameObject[] trigPos;

	private GameObject Trigger1;
	private GameObject Trigger2;

	// Use this for initialization
	void Awake() {

		player = GameObject.FindGameObjectWithTag("Player");

		Trigger1 = GameObject.Find("TriggerBox (0)");
		Trigger2 = GameObject.Find("TriggerBox (1)");

		// sort camera position names
		camPos = GameObject.FindGameObjectsWithTag("Cam Pos");
		SortAscendingOrder(camPos);

		// sort trigger position names
		trigPos = GameObject.FindGameObjectsWithTag("Cam Trigger Pos");
		SortAscendingOrder(trigPos);
		MoveTriggers(index);
	}

	// Update is called once per frame
	void Update() {
		
		if (player.GetComponent<OnCamTrigger>().InTrigger && Camera.main.WorldToScreenPoint(player.transform.position).x > Screen.width / 2) {
			index++;
		} else if (player.GetComponent<OnCamTrigger>().InTrigger && Camera.main.WorldToScreenPoint(player.transform.position).x < Screen.width / 2) {
			index--;
		}

		if (index < 0) {
			index = 0;
		} else if (index > camPos.Length - 1) {
			index = camPos.Length - 1;
		}

		MoveTriggers(index);
		CamMove(index);
	}

	void CamMove(int index) {
		Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position,
			camPos[index].transform.position,
			camSpeed * Time.deltaTime);
		Camera.main.transform.eulerAngles = camPos[index].transform.eulerAngles;
	}

	void MoveTriggers(int index) {
		Trigger1.transform.position = trigPos[index].transform.position;
		Trigger2.transform.position = trigPos[index+1].transform.position;
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