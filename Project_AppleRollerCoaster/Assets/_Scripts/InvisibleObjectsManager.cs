using UnityEngine;
using System.Collections;

public class InvisibleObjectsManager : MonoBehaviour {

	public bool makeInvisible = true;
	public bool forBuild = false;

	// Use this for initialization
	void Start() {
		if (forBuild) {
			DelMeshRenderer();
		} else {
			EnableRenderer(makeInvisible);
		}
	}

	// Use for updating while running
	void Update() {
		if (forBuild) {
			DelMeshRenderer();
		} else {
			EnableRenderer(makeInvisible);
		}
	}

	void EnableRenderer(bool off) {
		// Get all inisible objects
		GameObject[] TriggerBox = GameObject.FindGameObjectsWithTag("Trigger Box");
		GameObject[] invisWalls = GameObject.FindGameObjectsWithTag("Invis Wall");
		GameObject[] track = GameObject.FindGameObjectsWithTag("Track");

		// turn off mesh renderer
		if (off) {
			// TriggerBox volume
			for (int i=0; i < TriggerBox.Length; i++) {
				TriggerBox[i].GetComponent<Renderer>().enabled = false;
			}
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
			// TriggerBox volume
			for (int i=0; i < TriggerBox.Length; i++) {
				TriggerBox[i].GetComponent<Renderer>().enabled = true;
			}
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

	void DelMeshRenderer() {
		// Get all inisible objects
		GameObject[] TriggerBox = GameObject.FindGameObjectsWithTag("Trigger Box");
		GameObject[] invisWalls = GameObject.FindGameObjectsWithTag("Invis Wall");
		GameObject[] track = GameObject.FindGameObjectsWithTag("Track");

		// TriggerBox volume
		if (TriggerBox.Length > 0) {
			for (int i=0; i < TriggerBox.Length; i++) {
				Destroy(TriggerBox[i].GetComponent<Renderer>());
			}
		}
		// invisible walls
		if (invisWalls.Length > 0) {
			for (int i=0; i < invisWalls.Length; i++) {
				Destroy(invisWalls[i].GetComponent<Renderer>());
			}
		}
		// track components
		if (track.Length > 0) {
			for (int i=0; i < track.Length; i++) {
				if (track[i].GetComponent<Renderer>()) {
					Destroy(track[i].GetComponent<Renderer>());
				} else {
					Component[] trackChild = track[i].GetComponentsInChildren<Renderer>();
					foreach (Renderer comp in trackChild) {
						Destroy(comp);
					}
				}
			}
		}
	}
}