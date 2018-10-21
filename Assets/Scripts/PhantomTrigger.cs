using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhantomTrigger : MonoBehaviour {

    public string headsetColliderContainerName = "HeadsetColliderContainer";
    public Animator PhantomAnimator;
    public AudioSource audioSource;
    public float delayBetweenSFXAndVFX = 0.8f;
    public float lightsOffDuration = 4.0f;

    public FlickerLights RoomLights;
    private FlickerLights ThunderLights;

    private bool isInProgress = false;

    private void OnTriggerEnter(Collider other) {
        if (!isInProgress && other.name.Contains(headsetColliderContainerName)) {

            if (audioSource == null) {
                audioSource = GetComponent<AudioSource>();
            }

            if (ThunderLights == null) {
                foreach (FlickerLights item in FindObjectsOfType<FlickerLights>()) {
                    if (item.name.Contains("Thunder")) {
                        ThunderLights = item;
                    }
                }
            }

            StartCoroutine(PhantomFlyByRoutine());
        }
    }

    IEnumerator PhantomFlyByRoutine() {
        isInProgress = true;

        if(RoomLights != null) {
            RoomLights.ToggleLights(false);
        }

        if(audioSource != null) {
            audioSource.Play();
        }

        yield return new WaitForSeconds(delayBetweenSFXAndVFX);

        Debug.Log("Headset collided with " + name);

        PhantomAnimator.SetTrigger("FlyBy");

        if (ThunderLights != null) {
            ThunderLights.FlickerOnce();
        }

        yield return new WaitForSeconds(lightsOffDuration - delayBetweenSFXAndVFX);

        if (RoomLights != null) {
            RoomLights.ToggleLights(true);
            RoomLights.FlickerOnce();
        }

        isInProgress = false;
    }
}
