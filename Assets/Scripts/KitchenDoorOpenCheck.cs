using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class KitchenDoorOpenCheck : VRTK_InteractableObject  {
GameObject kitchenDoor;
	private KitchenDoorScript script1;
	public AudioSource audioSource;

	void Awake()
	{
		
	}
	// Use this for initialization
	void Start () {
		
	}

    override
    public void OnInteractableObjectGrabbed(InteractableObjectEventArgs e) {
        base.OnInteractableObjectGrabbed(e);

        if (kitchenDoor == null) {
            kitchenDoor = GameObject.FindWithTag("SKitchenDoor");
            if (kitchenDoor != null) {
                script1 = kitchenDoor.GetComponent<KitchenDoorScript>();
            }
        }
        

        GameObject gameObject = e.interactingObject;

        //Debug.Log("name is:" + gameObject.name);
        if (gameObject.name.Contains("LeftController") || gameObject.name.Contains("RightController"))
        //if(col.gameObject.name.Equals("[VRTK][AUTOGEN][BodyColliderContainer]"))
        {

            if (script1 != null && !script1.objectsInteractedWith.Contains(this.name)) {
                if (audioSource != null) {
                    audioSource.Play();
                }
                script1.objectsInteractedWith.Add(this.name);
            }
            //Debug.Log("Name of Game Object" + this.name);
            //Debug.Log("Number of Objects Interacted with: " + script1.objectsInteractedWith.Count);
        }
    }


    void OnCollisionEnter(Collision col)
	{	
		


	}
}
