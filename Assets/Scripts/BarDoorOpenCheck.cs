using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class BarDoorOpenCheck : VRTK_InteractableObject {

	GameObject barDoor;
	private BarDoorScript script1;
	public AudioSource audioSource;

	void Awake()
	{
		
	}
	// Use this for initialization
	void Start () {
		barDoor=GameObject.FindWithTag("CellarDoor");
		script1=barDoor.GetComponent<BarDoorScript>();
	}

    override
    public void OnInteractableObjectGrabbed(InteractableObjectEventArgs e) {
        base.OnInteractableObjectGrabbed(e);

        GameObject gameObject = e.interactingObject;

        Debug.Log("name is:" + gameObject.name);
        if (gameObject.name.Contains("LeftController") || gameObject.name.Contains("RightController"))
        //if(col.gameObject.name.Equals("[VRTK][AUTOGEN][BodyColliderContainer]"))
        {

            if (!script1.objectsInteractedWith.Contains(this.name)) {
                audioSource.Play();
                script1.objectsInteractedWith.Add(this.name);
            }
            Debug.Log("Name of Game Object" + this.name);
            Debug.Log("Number of Objects Interacted with: " + script1.objectsInteractedWith.Count);
        }
    }


    void OnCollisionEnter(Collision col)
	{	
		


	}
}
