using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCloseScript : MonoBehaviour {

    public float rotationDegreesPerSecond = 45f;
    public float rotationDegreesAmount = 180f;
    private float totalRotation = 0;
	bool closeDoor=false;
	bool doorClosed=false;
	GameObject doorToClose;
	// Use this for initialization
	void Start () {

		doorToClose=GameObject.FindWithTag("CellarDoor");
		
	}
	
	// Update is called once per frame
	void Update () {

		/* if(closeDoor==true && doorClosed==false)
		{
			if(Mathf.Abs(totalRotation) <  Mathf.Abs(rotationDegreesAmount))
			{
            	closeTheDoor();
			}
			else
			{
				doorClosed=true;
			}			
		}*/
		
	}
	private void OnTriggerEnter(Collider Other)
    {
		
		if(closeDoor==false)
		{
		doorToClose.transform.Rotate(new Vector3(0, -90f, 0));
		Debug.Log("Name is: " + doorToClose.name);
		}
		closeDoor=true;

    }
	void closeTheDoor()
	{
		/* float currentAngle = transform.rotation.eulerAngles.y;
		   //Debug.Log(currentAngle);
   			doorToClose.transform.rotation = 
    		Quaternion.AngleAxis(currentAngle + (Time.deltaTime * rotationDegreesPerSecond ), Vector3.up);
   			totalRotation += Time.deltaTime * rotationDegreesPerSecond ;*/
	}
}
