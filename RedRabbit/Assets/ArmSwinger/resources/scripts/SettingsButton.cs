using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SettingsButton : MonoBehaviour {

	/////////////////////
	// CLASS VARIABLES //
	/////////////////////

	//// Public variables ////
	public enum ButtonType {
		Up,
		Down,
		Toggle,
		SwingMode
	}

	public SettingsDisplay settingsDisplay;
	public ButtonType buttonType;
	public Color pushColor = Color.green;

	[Tooltip("Only if this is a Swing Mode button.")]
	public ArmSwinger.ArmSwingMode swingMode;

	//// Private variables ////
	Color startingColor;
	Vector3 startingScale;

	ArmSwinger armSwinger;

	//// Private objects ////
	private SettingsButton[] allSwingModeButtons;

	//////////////////////
	// INITIATILIZATION //
	//////////////////////
	void Start () {
		startingColor = this.GetComponent<Image>().color;
		startingScale = this.transform.localScale;

		allSwingModeButtons = this.transform.parent.GetComponentsInChildren<SettingsButton>();

		armSwinger = GameObject.FindObjectOfType<ArmSwinger>();

		if (settingsDisplay.armSwingerSetting == SettingsDisplay.ArmSwingerSetting.swingMode &&
			armSwinger.armSwingMode == swingMode) {
			this.GetComponent<Image>().color = pushColor;
		}


	}
	
	///////////////////
	// MONOBEHAVIOUR //
	///////////////////
	void OnTriggerEnter() {
		this.GetComponent<Image>().color = pushColor;
		this.transform.localScale *= 1.15f;

		switch (buttonType) {
			case (ButtonType.Up):
				settingsDisplay.Up();
				break;
			case (ButtonType.Down):
				settingsDisplay.Down();
				break;
			case (ButtonType.Toggle):
				settingsDisplay.Toggle();
				break;
			case (ButtonType.SwingMode):
				armSwinger.armSwingMode = swingMode;
				foreach (SettingsButton button in allSwingModeButtons) {
					button.GetComponent<Image>().color = button.startingColor;
				}
				this.GetComponent<Image>().color = pushColor;
				break;				
		}
	}

	void OnTriggerExit() {
		if (buttonType != ButtonType.SwingMode) {
			this.GetComponent<Image>().color = startingColor;
		}
		
		this.transform.localScale = startingScale;
	}

	/////////////
	// COMPUTE //
	/////////////

	/////////
	// GET //
	/////////

	/////////
	// SET //
	/////////

}
