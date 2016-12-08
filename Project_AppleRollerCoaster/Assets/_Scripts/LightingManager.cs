using UnityEngine;
using System.Linq;
using System.Collections;

public class LightingManager : MonoBehaviour {

	public GameObject[] guideLights;

	// Use this for initialization
	void Awake () {
		guideLights = GameObject.FindGameObjectsWithTag("Guide Lights").OrderBy(go => go.name).ToArray();

		for (int i=1; i < guideLights.Length; i++) {
			guideLights[i].SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
