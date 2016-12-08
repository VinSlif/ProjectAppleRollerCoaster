using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour {

	public Texture2D fadeTex;
	public float fadeSpeed = 0.2f;
	public int drawDepth = -1000;

	private float alpha = 0;

	private bool restart = false;

	void OnGUI() {
		if (restart) {
			alpha += fadeSpeed * Time.deltaTime;
			alpha = Mathf.Clamp01(alpha);

			Color thisAlpha = GUI.color;
			thisAlpha.a = alpha;
			GUI.color = thisAlpha;
			GUI.depth = drawDepth;
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTex);

			if (alpha >= 1.0f) {
				SceneManager.LoadScene("TechDemo", LoadSceneMode.Single);
			}
		}
	}

	// Use this for initialization
	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Player") {
			Global.startGame = false;
			restart = true;
		}
	}
}