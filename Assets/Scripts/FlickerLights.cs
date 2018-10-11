using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerLights : MonoBehaviour {

    public GameObject LightsContainer;

    public float MinimumPulseInterval = 0.01f;
    public float MaximumPulseInterval = 0.2f;
    public float PulseDuration = 1.0f;

    public bool FlickerOnLoad = false;

    public bool FlickerFlashlight = true;
    public Flashlight FlashlightObject;

    private bool IsFlickering = false;
    private Light[] ChildLights;

	// Use this for initialization
	void Start () {
        if(LightsContainer == null) {
            LightsContainer = this.gameObject;
        }

        ChildLights = GetComponentsInChildren<Light>();

		if(FlickerOnLoad) {
            StartFlickering();
        }
	}

    public void StartFlickering() {
        IsFlickering = true;
        StartCoroutine(Flicker());
    }

    public void StopFlickering() {
        IsFlickering = false;
    }

    public void ToggleLights(bool switchOn) {
        foreach (Light light in ChildLights) {
            light.enabled = switchOn;
        }
        if(FlickerFlashlight && FlashlightObject != null) {
            if (switchOn)
                FlashlightObject.SwitchOn(false);
            else
                FlashlightObject.SwitchOff(false);
        }
    }

    IEnumerator Flicker() {
        float durationTimer = 0.0f;

        while (IsFlickering) {
            float intervalTimer;

            intervalTimer = Random.Range(MinimumPulseInterval, MaximumPulseInterval);
            durationTimer += intervalTimer;
            ToggleLights(false);
            yield return new WaitForSeconds(intervalTimer);

            intervalTimer = Random.Range(MinimumPulseInterval, MaximumPulseInterval);
            durationTimer += intervalTimer;
            ToggleLights(true);
            yield return new WaitForSeconds(intervalTimer);

            if(durationTimer >= PulseDuration) {
                yield return new WaitForSeconds(PulseDuration);
                durationTimer = 0.0f;
            }
        }
    }
}
