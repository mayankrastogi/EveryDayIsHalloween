using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyBlockPuzzle : MonoBehaviour {

    public string BabyBlocksTagName = "BabyBlock";

    public AudioSource audioOnPuzzleSolved;
    public AudioSource audioOnPuzzleWrong;

    private Dictionary<string, bool> blocksPlaced = new Dictionary<string, bool>() {
        {"A",  false},
        {"B",  false},
        {"C",  false},
        {"D",  false},
        {"E",  false},
    };
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

                    // TODO: Trigger Puzzle Solved Sequence

                    audioOnPuzzleSolved.Play();
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
}
