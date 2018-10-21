using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ISeeYouTrigger : MonoBehaviour {

    public AudioSource audioSource;
    public string headsetColliderContainerName = "HeadsetColliderContainer";

    public FlickerLights RoomLights;

    private void OnTriggerEnter(Collider other) {

        if (other.name.Contains(headsetColliderContainerName)) {
            Debug.Log("Headset collided with trigger");

            if (RoomLights != null) {
                RoomLights.FlickerOnce();
            }

            if (audioSource != null && !audioSource.isPlaying) {
                audioSource.Play();
            }
        }
    }
}
