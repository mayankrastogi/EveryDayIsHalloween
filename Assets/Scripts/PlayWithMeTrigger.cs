using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class PlayWithMeTrigger : MonoBehaviour {

    public BabyBlockPuzzle BlockPuzzleScript;
    public AudioSource audioSource;
    public string headsetColliderContainerName = "HeadsetColliderContainer";

    private void OnTriggerEnter(Collider other) {
        if (other.name.Contains(headsetColliderContainerName) && !BlockPuzzleScript.isPuzzleSolved) {
            Debug.Log("Headset collided with trigger");

            if (audioSource != null && !audioSource.isPlaying) {
                audioSource.Play();
            }
        }
    }
}
