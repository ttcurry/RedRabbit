using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SettingsDisplay : MonoBehaviour {

	/////////////////////
	// CLASS VARIABLES //
	/////////////////////

	public enum ArmSwingerSetting {
		useNonLinearMovementCurve,
		maxSpeed,
		swingSpeedBothControllersCoefficient,
		swingSpeedSingleControllerCoefficient,
		swingMode,
		numHeightRaycastsToAverageAcross,
		preventWallClipping,
		preventClimbing,
		maxAnglePlayerCanClimb,
		preventFalling,
		maxAnglePlayerCanFall,
		preventWallWalking,
		maxAnglePlayerCanWallWalk,
		maxInstantHeightChange,
		onlyHeightAdjustWhileArmSwinging,
		stoppingInertia,
		movingInertia,
		stoppingInertiaTimeToStopAtMaxSpeed,
		movingInertiaTimeToStopAtMaxSpeed
		
	}
	
	//// Public variables ////
	[Tooltip("The ArmSwinger setting to display.")]
	public ArmSwingerSetting armSwingerSetting;
	public Color trueColor = Color.green;
	public Color falseColor = Color.red;

	//// Public objects ////



	//// Private objects ////
	ArmSwinger armSwinger;

	Text display;

	//////////////////////
	// INITIATILIZATION //
	//////////////////////
	void Start() {

		armSwinger = GameObject.FindObjectOfType<ArmSwinger>();

		displaySetting();
		
	}

	/////////////
	// COMPUTE //
	/////////////

	public void displaySetting() {

		display = this.GetComponent<Text>();

		if (display) {
			switch (armSwingerSetting) {
				case (ArmSwingerSetting.useNonLinearMovementCurve):
					displayTrueFalse(armSwinger.useNonLinearMovementCurve, display);
					break;
				case (ArmSwingerSetting.maxSpeed):
					display.text = armSwinger.armSwingMaxSpeed.ToString("F2");
					break;
				case (ArmSwingerSetting.swingSpeedBothControllersCoefficient):
					display.text = armSwinger.armSwingBothControllersCoefficient.ToString("F2");
					break;
				case (ArmSwingerSetting.swingSpeedSingleControllerCoefficient):
					display.text = armSwinger.armSwingSingleControllerCoefficient.ToString("F2");
					break;
				case (ArmSwingerSetting.numHeightRaycastsToAverageAcross):
					display.text = armSwinger.raycastAverageHeightCacheSize.ToString();
					break;
				case (ArmSwingerSetting.preventWallClipping):
					displayTrueFalse(armSwinger.preventWallClip, display);
					break;
				case (ArmSwingerSetting.preventClimbing):
					displayTrueFalse(armSwinger.preventClimbing, display);
					break;
				case (ArmSwingerSetting.maxAnglePlayerCanClimb):
					display.text = armSwinger.preventClimbingMaxAnglePlayerCanClimb.ToString("F0");
					break;
				case (ArmSwingerSetting.preventFalling):
					displayTrueFalse(armSwinger.preventFalling, display);
					break;
				case (ArmSwingerSetting.maxAnglePlayerCanFall):
					display.text = armSwinger.preventFallingMaxAnglePlayerCanFall.ToString("F0");
					break;
				case (ArmSwingerSetting.preventWallWalking):
					displayTrueFalse(armSwinger.preventWallWalking, display);
					break;
				case (ArmSwingerSetting.maxInstantHeightChange):
					display.text = armSwinger.instantHeightMaxChange.ToString("F2");
					break;
				case (ArmSwingerSetting.onlyHeightAdjustWhileArmSwinging):
					displayTrueFalse(armSwinger.raycastOnlyHeightAdjustWhileArmSwinging, display);
					break;
				case (ArmSwingerSetting.stoppingInertia):
					displayTrueFalse(armSwinger.stoppingInertia, display);
					break;
				case (ArmSwingerSetting.movingInertia):
					displayTrueFalse(armSwinger.movingInertia, display);
					break;
				case (ArmSwingerSetting.movingInertiaTimeToStopAtMaxSpeed):
					display.text = armSwinger.movingInertiaTimeToStopAtMaxSpeed.ToString("F2");
					break;
				case (ArmSwingerSetting.stoppingInertiaTimeToStopAtMaxSpeed):
					display.text = armSwinger.stoppingInertiaTimeToStopAtMaxSpeed.ToString("F2");
					break;
				default:
					display.text = null;
					break;
			}
		}
	}

	void displayTrueFalse(bool setting, Text display) {
		if (display) {
			if (setting) {
				display.text = "On";
				display.color = trueColor;
			} else {
				display.text = "Off";
				display.color = falseColor;
			}
		}
	}
	
	public void Up() {

		switch (armSwingerSetting) {
			case (ArmSwingerSetting.maxSpeed):
				armSwinger.armSwingMaxSpeed += .25f;
				break;
			case (ArmSwingerSetting.swingSpeedBothControllersCoefficient):
				armSwinger.armSwingBothControllersCoefficient += .05f;
				break;
			case (ArmSwingerSetting.swingSpeedSingleControllerCoefficient):
				armSwinger.armSwingSingleControllerCoefficient += .05f;
				break;
			case (ArmSwingerSetting.numHeightRaycastsToAverageAcross):
				armSwinger.raycastAverageHeightCacheSize++;
				break;
			case (ArmSwingerSetting.maxAnglePlayerCanClimb):
				armSwinger.preventClimbingMaxAnglePlayerCanClimb++;
				break;
			case (ArmSwingerSetting.maxAnglePlayerCanFall):
				armSwinger.preventFallingMaxAnglePlayerCanFall++;
				break;
			case (ArmSwingerSetting.maxInstantHeightChange):
				armSwinger.instantHeightMaxChange += .02f;
				break;
			case (ArmSwingerSetting.stoppingInertiaTimeToStopAtMaxSpeed):
				armSwinger.stoppingInertiaTimeToStopAtMaxSpeed += .05f;
				break;
			case (ArmSwingerSetting.movingInertiaTimeToStopAtMaxSpeed):
				armSwinger.movingInertiaTimeToStopAtMaxSpeed += .05f;
				break;
		}

		displaySetting();
	}

	public void Down () {

		switch (armSwingerSetting) {
			case (ArmSwingerSetting.maxSpeed):
				armSwinger.armSwingMaxSpeed -= .25f;
				break;
			case (ArmSwingerSetting.swingSpeedBothControllersCoefficient):
				armSwinger.armSwingBothControllersCoefficient -= .05f;
				break;
			case (ArmSwingerSetting.swingSpeedSingleControllerCoefficient):
				armSwinger.armSwingSingleControllerCoefficient -= .05f;
				break;
			case (ArmSwingerSetting.numHeightRaycastsToAverageAcross):
				armSwinger.raycastAverageHeightCacheSize--;
				break;
			case (ArmSwingerSetting.maxAnglePlayerCanClimb):
				armSwinger.preventClimbingMaxAnglePlayerCanClimb--;
				break;
			case (ArmSwingerSetting.maxAnglePlayerCanFall):
				armSwinger.preventFallingMaxAnglePlayerCanFall--;
				break;
			case (ArmSwingerSetting.maxInstantHeightChange):
				armSwinger.instantHeightMaxChange -= .02f;
				break;
			case (ArmSwingerSetting.stoppingInertiaTimeToStopAtMaxSpeed):
				armSwinger.stoppingInertiaTimeToStopAtMaxSpeed -= .05f;
				break;
			case (ArmSwingerSetting.movingInertiaTimeToStopAtMaxSpeed):
				armSwinger.movingInertiaTimeToStopAtMaxSpeed -= .05f;
				break;
		}

		displaySetting();
	}

	public void Toggle() {
		switch (armSwingerSetting) {
			case (ArmSwingerSetting.useNonLinearMovementCurve):
				armSwinger.useNonLinearMovementCurve = !armSwinger.useNonLinearMovementCurve;
				break;
			case (ArmSwingerSetting.preventWallClipping):
				armSwinger.preventWallClip = !armSwinger.preventWallClip;
				break;
			case (ArmSwingerSetting.preventClimbing):
				armSwinger.preventClimbing = !armSwinger.preventClimbing;
				break;
			case (ArmSwingerSetting.preventFalling):
				armSwinger.preventFalling = !armSwinger.preventFalling;
				break;
			case (ArmSwingerSetting.preventWallWalking):
				armSwinger.preventWallWalking = !armSwinger.preventWallWalking;
				break;
			case (ArmSwingerSetting.onlyHeightAdjustWhileArmSwinging):
				armSwinger.raycastOnlyHeightAdjustWhileArmSwinging = !armSwinger.raycastOnlyHeightAdjustWhileArmSwinging;
				break;
			case (ArmSwingerSetting.stoppingInertia):
				armSwinger.stoppingInertia = !armSwinger.stoppingInertia;
				break;
			case (ArmSwingerSetting.movingInertia):
				armSwinger.movingInertia = !armSwinger.movingInertia;
				break;
		}

		displaySetting();

	}
}
