using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarDoorOpenCheck : MonoBehaviour {

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
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(script1.openDoor);
	}

	void OnCollisionEnter(Collision col)
	{	
		Debug.Log("name is:" + col.gameObject.name);
		if(col.gameObject.name.Equals("VRSimulatorCameraRig"))
		//if(col.gameObject.name.Equals("[VRTK][AUTOGEN][BodyColliderContainer]"))
		{

			if(!script1.objectsInteractedWith.Contains(this.name))
			{
				audioSource.Play();
				script1.objectsInteractedWith.Add(this.name);
			}
			Debug.Log("Name of Game Object" + this.name);
			Debug.Log("Number of Objects Interacted with: " + script1.objectsInteractedWith.Count);
		}


	}
}
