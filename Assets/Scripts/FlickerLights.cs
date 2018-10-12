using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerLights : MonoBehaviour {

    public GameObject LightsContainer;

    public float MinimumPulseInterval = 0.01f;
    public float MaximumPulseInterval = 0.1f;
    public float PulseDuration = 0.8f;
    public float TimeBetweenFlickers = 2.5f;

    public bool FlickerOnLoad = false;

    public bool FlickerFlashlight = true;
    public Flashlight FlashlightObject;

    private bool IsFlickering = false;
    private Light[] ChildLights;
    private AudioSource[] ChildAudioSources;

	// Use this for initialization
	void Start () {
        if(LightsContainer == null) {
            LightsContainer = this.gameObject;
        }

        ChildLights = GetComponentsInChildren<Light>();
        ChildAudioSources = GetComponentsInChildren<AudioSource>();

		if(FlickerOnLoad) {
            StartFlickering();
        }
	}

    public void StartFlickering(bool once = false) {
        IsFlickering = true;
        StartCoroutine(Flicker(once));
    }

    public void StopFlickering() {
        IsFlickering = false;
    }

    public void FlickerOnce() {
        StartFlickering(true);
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

    public void PlaySFX() {
        foreach(AudioSource audioSource in ChildAudioSources) {
            audioSource.Play();
        }
    }

    IEnumerator Flicker(bool once = false) {
        float durationTimer = 0.0f;

        while (IsFlickering) {
            float intervalTimer;

            if(durationTimer == 0.0f) {
                PlaySFX();
            }

            intervalTimer = Random.Range(MinimumPulseInterval, MaximumPulseInterval);
            durationTimer += intervalTimer;
            ToggleLights(false);
            yield return new WaitForSeconds(intervalTimer);

            intervalTimer = Random.Range(MinimumPulseInterval, MaximumPulseInterval);
            durationTimer += intervalTimer;
            ToggleLights(true);
            yield return new WaitForSeconds(intervalTimer);

            if(durationTimer >= PulseDuration) {
                yield return new WaitForSeconds(TimeBetweenFlickers);
                durationTimer = 0.0f;
            }

            if(once) {
                StopFlickering();
                break;
            }
        }
    }
}
