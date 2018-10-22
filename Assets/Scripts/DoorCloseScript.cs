using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCloseScript : MonoBehaviour {

    public string NameOfColliderToTest = "HeadsetCollider";
    public string doorToCloseTag;
    public string doorToOpenTag;
    public float rotationDegreesPerSecond = 45f;
    public float rotationDegreesAmount = 180f;
    private float totalRotation = 0;
    bool closeDoor = false;
    bool doorClosed = false;

    GameObject doorToClose;
    DoorOpen doorToOpen;
    // Use this for initialization

    bool IsNullOrEmpty(string str) {
        return str == null || str.Length == 0;
    }

    void Start() {

        doorToClose = !IsNullOrEmpty(doorToCloseTag) ? GameObject.FindWithTag(doorToCloseTag) : null;
        GameObject doorToOpenGameObject = !IsNullOrEmpty(doorToOpenTag) ? GameObject.FindWithTag(doorToOpenTag) : null;
        if (doorToOpenGameObject != null) {
            doorToOpen = doorToOpenGameObject.GetComponent<DoorOpen>();
        }
    }

    private void OnTriggerEnter(Collider Other) {
		
        if (doorToClose != null && Other.name.Contains(NameOfColliderToTest)) {
         Debug.Log("Name is:  " + Other.gameObject.name);
            if (closeDoor == false) {
                doorToClose.transform.Rotate(new Vector3(0, -90f, 0));
            }
            closeDoor = true;
        }

    }

    private void OnTriggerExit(Collider other) {
        if(doorToOpen != null && other.name.Contains(NameOfColliderToTest)) {
            doorToOpen.openDoor = true;
        }
    }
}
