using UnityEngine;
using System.Collections;

public class InvisibleObjectsManager : MonoBehaviour {

	public bool makeInvisible = true;

	// Use this for initialization
	void Awake() {
		EnableRenderer(makeInvisible);
	}

	void Update() {
		EnableRenderer(makeInvisible);
	}

	void EnableRenderer(bool off) {
		GameObject triggerVol = GameObject.Find("TriggerBox");
		GameObject[] invisWalls = GameObject.FindGameObjectsWithTag("Invis Wall");
		GameObject[] track = GameObject.FindGameObjectsWithTag("Track");

		// turn off mesh renderer
		if (off) {
			// trigger volume
			triggerVol.GetComponent<Renderer>().enabled = false;
			// invisible walls
			for (int i=0; i < invisWalls.Length; i++) {
				invisWalls[i].GetComponent<Renderer>().enabled = false;
			}
			// track components
			for (int i=0; i < track.Length; i++) {
				if (track[i].GetComponent<Renderer>()) {
					track[i].GetComponent<Renderer>().enabled = false;
				} else {
					Component[] trackChild = track[i].GetComponentsInChildren<Renderer>();
					foreach (Renderer comp in trackChild) {
						comp.enabled = false;
					}
				}
			}

		// turn on mesh renderer
		} else {
			// trigger volume
			triggerVol.GetComponent<Renderer>().enabled = true;
			// invivislbe walls
			for (int i=0; i < invisWalls.Length; i++) {
				invisWalls[i].GetComponent<Renderer>().enabled = true;
			}
			// track components
			for (int i=0; i < track.Length; i++) {
				if (track[i].GetComponent<Renderer>()) {
					track[i].GetComponent<Renderer>().enabled = true;
				} else {
					Component[] trackChild = track[i].GetComponentsInChildren<Renderer>();
					foreach (Renderer comp in trackChild) {
						comp.enabled = true;
					}
				}
			}
		}
	}
		
}