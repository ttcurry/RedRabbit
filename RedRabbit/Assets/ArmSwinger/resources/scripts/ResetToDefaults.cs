using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ResetToDefaults : MonoBehaviour {

	void OnTriggerEnter() {
		SteamVR_Fade.View(Color.black, .5f);
		Invoke("reloadLevel", .5f);
	}


	void reloadLevel() {
		SteamVR_Fade.View(Color.clear, .5f);
		Application.LoadLevel(Application.loadedLevel);
	}

}


