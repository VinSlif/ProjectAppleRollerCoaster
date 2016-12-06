using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour {

	// Use this for initialization
	void OnCollisionEnter (Collision col) {
		SceneManager.LoadScene("TechDemo", LoadSceneMode.Single);
	}
}