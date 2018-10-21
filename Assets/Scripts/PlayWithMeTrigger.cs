using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class PlayWithMeTrigger : MonoBehaviour {

    public BabyBlockPuzzle BlockPuzzleScript;

    public List<AudioClip> audioClipsToPlay;

    public AudioSource audioSource;
    public string headsetColliderContainerName = "HeadsetColliderContainer";

    public FlickerLights RoomLights;

    private void OnTriggerEnter(Collider other) {

        if (other.name.Contains(headsetColliderContainerName) && !BlockPuzzleScript.isPuzzleSolved) {
            Debug.Log("Headset collided with trigger");

            if(RoomLights != null) {
                RoomLights.FlickerOnce();
            }

            if (audioSource != null && audioClipsToPlay.Count > 0 && !audioSource.isPlaying) {
                audioSource.PlayOneShot(audioClipsToPlay[Mathf.RoundToInt(Random.Range(0, audioClipsToPlay.Count))]);

                //audioSource.Play();
            }
        }
    }
}
