using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ControllerHaptics : MonoBehaviour {

    public GameObject LeftController;
    public GameObject RightController;

    public float strength = 0.5f;
    public float duration = 1f;
    public float pulseInterval = 0.2f;

    private bool isVibrating = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void VibrateControllers() {
        if (isVibrating)
            return;

        Debug.Log("Vibrating...");

        isVibrating = true;
        StartCoroutine(KeepVibrating());
    }

    public void CancelControllerVibrations() {
        Debug.Log("Vibration cancelled");
        VRTK_ControllerHaptics.CancelHapticPulse(VRTK_ControllerReference.GetControllerReference(LeftController));
        VRTK_ControllerHaptics.CancelHapticPulse(VRTK_ControllerReference.GetControllerReference(RightController));
        isVibrating = false;
    }

    IEnumerator KeepVibrating() {
        while (isVibrating) {
            VRTK_ControllerHaptics.TriggerHapticPulse(VRTK_ControllerReference.GetControllerReference(LeftController), strength, duration, pulseInterval);
            VRTK_ControllerHaptics.TriggerHapticPulse(VRTK_ControllerReference.GetControllerReference(RightController), strength, duration, pulseInterval);

            yield return new WaitForSeconds(duration);
        }
    }
}
