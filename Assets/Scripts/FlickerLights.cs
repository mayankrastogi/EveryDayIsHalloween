using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerLights : MonoBehaviour {

    public GameObject LightsContainer;

    public float MinimumPulseInterval = 0.01f;
    public float MaximumPulseInterval = 0.1f;
    public float PulseDuration = 0.8f;
    public float TimeBetweenFlickers = 2.5f;

    public bool StayOnWhenNotFlickering = true;
    public bool FlickerOnLoad = false;

    public bool FlickerFlashlight = true;
    public Flashlight FlashlightObject;

    public bool IsFlickering { get; private set; }
    private Light[] ChildLights;
    private AudioSource[] ChildAudioSources;

	// Use this for initialization
	void Start () {
        IsFlickering = false;

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
            ToggleLights(!StayOnWhenNotFlickering);
            yield return new WaitForSeconds(intervalTimer);

            intervalTimer = Random.Range(MinimumPulseInterval, MaximumPulseInterval);
            durationTimer += intervalTimer;
            ToggleLights(StayOnWhenNotFlickering);
            yield return new WaitForSeconds(intervalTimer);

            if(durationTimer >= PulseDuration) {
                if (once) {
                    StopFlickering();
                    break;
                }

                yield return new WaitForSeconds(TimeBetweenFlickers);
                durationTimer = 0.0f;
            }
        }
    }
}
