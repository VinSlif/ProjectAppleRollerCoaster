using UnityEngine;
using System.Collections;

public static class Global {
	public static int index = 0;
	public static bool startGame = false;

	// Determine which side of the screen a target is
	public static bool DetermineScreenSideLeft(GameObject target) {
		if (Camera.main.WorldToScreenPoint(target.transform.position).x < Screen.width / 2) {
			return true;
		} else {
			return false;
		}
	}
}