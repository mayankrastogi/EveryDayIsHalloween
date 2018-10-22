using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour {

    public float rotationDegreesPerSecond = 20f;
    public float rotationDegreesAmount = 120f;
    private float totalRotation = 0;
    public AudioSource audioSource;
    public bool soundPlayed = false;
    public bool doorOpened = false;
    public bool openDoor = false;

    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update() {
        if (openDoor && doorOpened == false) {
            if (Mathf.Abs(totalRotation) < Mathf.Abs(rotationDegreesAmount)) {
                openTheDoor();
            }
            else {
                doorOpened = true;
            }
        }
    }
    void openTheDoor() {

        if (soundPlayed == false) {
            audioSource.Play();
            soundPlayed = true;
        }
        float currentAngle = transform.rotation.eulerAngles.y;
        Debug.Log(currentAngle);
        transform.rotation =
     Quaternion.AngleAxis(currentAngle + (Time.deltaTime * rotationDegreesPerSecond), Vector3.up);
        totalRotation += Time.deltaTime * rotationDegreesPerSecond;


    }
}
