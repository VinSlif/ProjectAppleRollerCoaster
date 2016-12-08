using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	public Texture2D fadeTex;
	public float fadeSpeed = 0.2f;

	public Texture2D mouseTex;
	public float mouseFadeSpeed = 0.2f;

	private int drawDepth = -1000;
	private float alpha = 1;
	private float mouseAlpha = 0;

	private float mouseTimer = 5.0f;

	public GameObject cursorPrefab;
	private GameObject customCursor;

	private GameObject player;

	private ParticleSystem.EmissionModule cursorPartEm;
	private ParticleSystem.VelocityOverLifetimeModule cursorPartVel;
	private float particleDisplay;

	public float leafReductionFactor = 5.0f;
	public ParticleSystem leafWindIndicator;
	private ParticleSystem.VelocityOverLifetimeModule leafPartVel;

	public float dustReductionFactor = 2.0f;
	public ParticleSystem dustWindIndicator;
	private ParticleSystem.VelocityOverLifetimeModule dustPartVel;

	// Use this for initialization
	void Awake () {

		// Get Player GameObject
		player = GameObject.FindGameObjectWithTag("Player");

		if (cursorPrefab != null) {
			// hide cursor
			UnityEngine.Cursor.visible = false;

			// create custom cursor
			customCursor = (GameObject)Instantiate (cursorPrefab, new Vector3(0, 0, 0), Quaternion.identity);
			customCursor.transform.parent = gameObject.transform;
			customCursor.transform.SetSiblingIndex (0);
			customCursor.name = "CursorParticles";

			cursorPartEm = customCursor.GetComponent<ParticleSystem>().emission;
			cursorPartVel = customCursor.GetComponent<ParticleSystem>().velocityOverLifetime;

			leafPartVel = leafWindIndicator.velocityOverLifetime;
			dustPartVel = dustWindIndicator.velocityOverLifetime;
		}
	}

	// Update is called once per frame
	void Update() {
		// raycast setup
		Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit mouseHit;

		// check if cursor is hitting valid point
		if (Physics.Raycast (mouseRay, out mouseHit)) {
			customCursor.SetActive(true);
			// move particles to cursor hit point
			customCursor.transform.position = new Vector3 (mouseHit.point.x, mouseHit.point.y, mouseHit.point.z);

			// handle particle effects
			if (Input.GetButton("Fire1")) {
				// cursor particle rate
				cursorPartEm.rate = player.GetComponent<ApplyForceMouseDirection>().forceFactor + 10.0f;

				// cursor velocity direction
				cursorPartVel.x = player.GetComponent<ApplyForceMouseDirection>().mouseDir.x * leafReductionFactor;
				cursorPartVel.y = player.GetComponent<ApplyForceMouseDirection>().mouseDir.y * leafReductionFactor;
				cursorPartVel.z = player.GetComponent<ApplyForceMouseDirection>().mouseDir.z * leafReductionFactor;

				// leaf velocity direction
				leafPartVel.x = player.GetComponent<ApplyForceMouseDirection>().mouseDir.x / leafReductionFactor;
				leafPartVel.y = player.GetComponent<ApplyForceMouseDirection>().mouseDir.y / leafReductionFactor;
				leafPartVel.z = player.GetComponent<ApplyForceMouseDirection>().mouseDir.z / leafReductionFactor;

				// dust velocity direction
				dustPartVel.x = player.GetComponent<ApplyForceMouseDirection>().mouseDir.x / dustReductionFactor;
				dustPartVel.y = player.GetComponent<ApplyForceMouseDirection>().mouseDir.y / dustReductionFactor;
				dustPartVel.z = player.GetComponent<ApplyForceMouseDirection>().mouseDir.z / dustReductionFactor;
			} else {
				// cursor particle rate
				cursorPartEm.rate = 10.0f;

				// cursor velocity direction
				cursorPartVel.x = 0;
				cursorPartVel.y = 0;
				cursorPartVel.z = 0;

				// leaf velocity direction
				leafPartVel.x = 0;
				leafPartVel.y = 0;
				leafPartVel.z = 0;

				// dust velocity direction
				dustPartVel.x = 0;
				dustPartVel.y = 0;
				dustPartVel.z = 0;
			}
		} else {
			customCursor.SetActive (false);
		}
	}

	void OnGUI() {
		alpha -= fadeSpeed * Time.deltaTime;
		alpha = Mathf.Clamp01(alpha);

		Color thisAlpha = GUI.color;
		thisAlpha.a = alpha;
		GUI.color = thisAlpha;
		GUI.depth = drawDepth;
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTex);

		if (alpha <= 0 && !Global.startGame) {
			mouseTimer -= Time.deltaTime;

			if (mouseTimer <= 0) {
				mouseAlpha -= mouseFadeSpeed * Time.deltaTime;
				mouseAlpha = Mathf.Clamp01(mouseAlpha);

				Color otherAlpha = GUI.color;
				otherAlpha.a = alpha;
				GUI.color = otherAlpha;
				GUI.DrawTexture(new Rect((Screen.width / 2) - (mouseTex.width / 2),
					(Screen.height / 2) - (mouseTex.width / 2),
					(Screen.width / 2) + (mouseTex.width / 2),
					(Screen.height / 2) + (mouseTex.height / 2)), mouseTex);
			}
		} else if (Global.startGame) {
			Color otherAlpha = GUI.color;
			otherAlpha.a = 0;
			GUI.color = otherAlpha;
		}
	}
}