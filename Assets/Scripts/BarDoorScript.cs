using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarDoorScript : MonoBehaviour {

	public bool openDoor;
	public List<string> objectsInteractedWith = new List<string>(); 
	public float rotationDegreesPerSecond = 20f;
    public float rotationDegreesAmount = 120f;
    private float totalRotation = 0;
	public AudioSource audioSource;
	bool soundPlayed;

	void Awake()
	{
		openDoor=false;
		soundPlayed=false;
		//objectsInteractedWith=new List<string>();
		
	}
	// Use this for initialization
	void Start () {
		Debug.Log("Length=" + objectsInteractedWith.Count);
	}
	
	// Update is called once per frame
	void Update () 
	{
		//if(objectsInteractedWith.Count>1 && openDoor==false )
		if(objectsInteractedWith.Count>1 && openDoor==false )
		{
			    if(Mathf.Abs(totalRotation) <  Mathf.Abs(rotationDegreesAmount))
				//if(totalRotation < rotationDegreesAmount)
				{
                  openTheDoor();
				}
				else
				{
				  openDoor=true;
				}
			
		}
		
	}

	void openTheDoor()
	{
		    if(soundPlayed==false)
			{
				audioSource.Play();
				soundPlayed=true;
			}
		   float currentAngle = transform.rotation.eulerAngles.y;
		   Debug.Log(currentAngle);
   			transform.rotation = 
    		Quaternion.AngleAxis(currentAngle + (Time.deltaTime * rotationDegreesPerSecond ), Vector3.up);
   			totalRotation += Time.deltaTime * rotationDegreesPerSecond ;


	}
}
