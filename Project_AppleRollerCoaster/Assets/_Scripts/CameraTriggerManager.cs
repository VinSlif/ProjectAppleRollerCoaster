using UnityEngine;
using System.Linq;
using System.Collections;

public class CameraTriggerManager : MonoBehaviour {

	public GameObject triggerBoxPrefab;
	private GameObject[] trigPos;

	// Use this for initialization
	void Awake () {

		// sort trigger position names
		trigPos = GameObject.FindGameObjectsWithTag("Cam Trigger Pos").OrderBy(go => go.name).ToArray();

		// place trigger boxes at trigger positions
		for (int i=0; i < trigPos.Length; i++) {
			// hold trigger boxes for hiearchy
			GameObject triggerHolder;
			if (!GameObject.FindGameObjectWithTag("Cam Trigger")) {
				triggerHolder = new GameObject();
				triggerHolder.transform.position = Vector3.zero;
				triggerHolder.name = "CameraTriggerBoxes";
				triggerHolder.tag = "Cam Trigger";
			} else {
				triggerHolder = GameObject.FindGameObjectWithTag("Cam Trigger");
			}

			// create + place trigger box
			GameObject trigger = (GameObject)Instantiate(triggerBoxPrefab,
				trigPos[i].transform.position,
				Quaternion.Euler(trigPos[i].transform.eulerAngles));
			trigger.transform.localScale = trigPos[i].transform.localScale;
			trigger.tag = "Trigger Box";
			trigger.name = "TriggerBox (" + i + ")";
			trigger.transform.parent = triggerHolder.transform;
		}
	}
}