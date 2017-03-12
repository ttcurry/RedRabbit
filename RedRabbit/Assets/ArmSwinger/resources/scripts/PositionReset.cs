using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PositionReset : MonoBehaviour {

	/////////////////////
	// CLASS VARIABLES //
	/////////////////////

	//// Public variables ////

	//// Public objects ////

	//// Private variables ////
	private Valve.VR.EVRButtonId menuButton = Valve.VR.EVRButtonId.k_EButton_ApplicationMenu;
	bool leftMenuButtonDown = false;
	bool rightMenuButtonDown = false;

	//// Private objects ////
	private SteamVR_ControllerManager controllerManager;
	private GameObject leftControllerGameObject;
	private GameObject rightControllerGameObject;
	private SteamVR_TrackedObject leftControllerTrackedObj;
	private SteamVR_TrackedObject rightControllerTrackedObj;
	private SteamVR_Controller.Device leftController;
	private SteamVR_Controller.Device rightController;
	private int leftControllerIndex;
	private int rightControllerIndex;

	private ArmSwinger armSwinger;

	//////////////////////
	// INITIATILIZATION //
	//////////////////////
	void Start () {

		// Find an assign components and objects
		controllerManager = GameObject.FindObjectOfType<SteamVR_ControllerManager>();
		leftControllerGameObject = controllerManager.left;
		rightControllerGameObject = controllerManager.right;
		leftControllerTrackedObj = leftControllerGameObject.GetComponent<SteamVR_TrackedObject>();
		rightControllerTrackedObj = rightControllerGameObject.GetComponent<SteamVR_TrackedObject>();

		armSwinger = GameObject.FindObjectOfType<ArmSwinger>();

	}
	
	////////////
	// UPDATE //
	////////////
	void Update () {

		// If ArmSwinger is using the menu button as the activator, avoid overwriting it.  Instead, just disable this module.
		if (armSwinger.armSwingButton == ArmSwinger.ControllerButton.Menu) {
			return;
		}

		// Assign controllers
		// Left
		leftControllerIndex = (int) leftControllerTrackedObj.index;
		if (leftControllerIndex != -1) {
			leftController = SteamVR_Controller.Input(leftControllerIndex);
		}

		// Right
		rightControllerIndex = (int) rightControllerTrackedObj.index;
		if (rightControllerIndex != -1) {
			rightController = SteamVR_Controller.Input(rightControllerIndex);
		}

		// Store controller button states
		getControllerButtons();

		if (leftMenuButtonDown || rightMenuButtonDown) {
			SteamVR_Fade.View(Color.black, .5f);
			Invoke("moveToWallOSettings", .5f);
		}

	}

	///////////////////
	// MONOBEHAVIOUR //
	///////////////////

	/////////////
	// COMPUTE //
	/////////////

	// Sets the button variables each frame
	void getControllerButtons() {
		if (leftController != null) {
			leftMenuButtonDown = leftController.GetPressDown(menuButton);
		}

		if (rightController != null) {
			rightMenuButtonDown = rightController.GetPressDown(menuButton);
		}
	}

	void moveToWallOSettings() {
		armSwinger.moveCameraRig(new Vector3(30.5f, 0, 11.695f));
		SteamVR_Fade.View(Color.clear, .5f);
		
	}
	/////////
	// GET //
	/////////

	/////////
	// SET //
	/////////

}
