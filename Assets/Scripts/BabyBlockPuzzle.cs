using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyBlockPuzzle : MonoBehaviour {

    public string BabyBlocksTagName = "BabyBlock";

    public AudioSource audioOnPuzzleSolved;
    public AudioSource audioOnPuzzleWrong;

    public FlickerLights RoomLights;
    private FlickerLights ThunderLights;

    private Dictionary<string, bool> blocksPlaced = new Dictionary<string, bool>() {
        {"A",  false},
        {"B",  false},
        {"C",  false},
        {"D",  false},
        {"E",  false},
    };

    public float timeToWaitBeforeOpeeningDoor = 5.0f;
    public string doorToOpenTag = "BedroomDoor";

    public bool isPuzzleSolved { get; private set; }

    private void Start() {
        isPuzzleSolved = false;
    }

    private void OnCollisionEnter(Collision collision) {
        Debug.Log("Collision detected: " +collision.gameObject.name +", tag: " +collision.gameObject.tag);

        if (!isPuzzleSolved) {
            if (collision.gameObject.CompareTag(BabyBlocksTagName)) {
                Debug.Log("BabyBlock placed");
                blocksPlaced[BlockKey(collision)] = true;
                
                if(AllBlocksPlaced()) {
                    isPuzzleSolved = true;
                    Debug.Log("BabyBlock puzzle solved!");

                    //Trigger Puzzle Solved Sequence
                    StartCoroutine(TriggerPuzzleSolvedSequence());
                }
                else {
                    Debug.Log("BabyBlock puzzle remains unsolved!");
                    audioOnPuzzleWrong.Play();
                }
            }

        }
    }

    private void OnCollisionStay(Collision collision) {
        if (!isPuzzleSolved) {
            if (collision.gameObject.CompareTag(BabyBlocksTagName) && blocksPlaced[BlockKey(collision)] == false) {
                Debug.Log("BabyBlock placed");
                blocksPlaced[BlockKey(collision)] = true;
            }
        }
    }

    private void OnCollisionExit(Collision collision) {
        Debug.Log("Collision exit: " + collision.gameObject.name + ", tag: " + collision.gameObject.tag);

        if (collision.gameObject.CompareTag(BabyBlocksTagName)) {
            Debug.Log("BabyBlock removed");
            blocksPlaced[BlockKey(collision)] = false;
        }
    }

    private string BlockKey(Collision collision) {
        string name = collision.gameObject.name;
        return name.Substring(name.Length - 1);       
    }

    private bool AllBlocksPlaced() {
        foreach(KeyValuePair<string, bool> item in blocksPlaced) {
            if(item.Value == false) {
                return false;
            }
        }
        return true;
    }

    public IEnumerator TriggerPuzzleSolvedSequence() {
        if (ThunderLights == null) {
            foreach (FlickerLights item in FindObjectsOfType<FlickerLights>()) {
                if (item.name.Contains("Thunder")) {
                    ThunderLights = item;
                }
            }
        }

        if(RoomLights != null) {
            RoomLights.StayOnWhenNotFlickering = false;
            RoomLights.StartFlickering();
        }

        if(ThunderLights != null) {
            ThunderLights.StartFlickering();
        }

        if(audioOnPuzzleSolved != null) {
            audioOnPuzzleSolved.Play();
        }

        yield return new WaitForSeconds(timeToWaitBeforeOpeeningDoor);

        GameObject doorObject = GameObject.FindGameObjectWithTag(doorToOpenTag);
        Debug.Log("DoorObject: " + doorObject);
        if(doorObject != null) {
            DoorOpen doorOpenScript = doorObject.GetComponent<DoorOpen>();
            Debug.Log("DoorOpenScript: " + doorOpenScript);
            if (doorOpenScript != null) {
                doorOpenScript.soundPlayed = false;
                doorOpenScript.rotationDegreesAmount = 180.0f;
                doorOpenScript.openDoor = true;
                doorOpenScript.doorOpened = false;
            }

            GameObject kitchenDoor = GameObject.FindGameObjectWithTag("SKitchenDoor");
            if(kitchenDoor != null) {
                kitchenDoor.SetActive(false);
            }
        }
    }
}
