using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupboardTriggerScript : MonoBehaviour {

	//public Transform drawerLeft;
	//public Transform drawerRight;
	private float openspeed=5;

	public Animator drawerLeft;
	public Animator drawerRight;
	public AudioSource audioSource;
	public Animator zombieWalk;

	//public Vector3 closedPositionDrawerLeft = new Vector3(0.194981f,0.765f,0.2081708f);
	//public Vector3 closedPositionDrawerRight = new Vector3(0.1953043f,0.765f,-0.2082729f);

	//public Vector3 openPositionDrawerLeft = new Vector3(0.5f,0.765f,0.208f);
	//public Vector3 openPositionDrawerRight = new Vector3(0.5f,0.765f,-0.208f);

	private bool drawersOpen;

	
	// Use this for initialization
	void Start () {

		drawersOpen=false;	
		
	}
	
	// Update is called once per frame
	void Update () {
		/* if (drawersOpen)
		{
			
			//drawerLeft.position=Vector3.Lerp(drawerLeft.position,openPositionDrawerLeft, Time.deltaTime*openspeed);
			//drawerRight.position=Vector3.Lerp(drawerRight.position,openPositionDrawerRight, Time.deltaTime*openspeed);
		}
		else
		{
			//drawerLeft.position=Vector3.Lerp(drawerLeft.position,closedPositionDrawerLeft, Time.deltaTime*openspeed);
			//drawerRight.position=Vector3.Lerp(drawerRight.position,closedPositionDrawerRight, Time.deltaTime*openspeed);
		}*/
	}
	public void openDrawers()
	{
         drawersOpen=true;
		 //Debug.Log("Playing Animation");
		 audioSource.Play();
		 drawerLeft.enabled=true;
		 drawerRight.enabled=true;
		 zombieWalk.enabled=true;
		 drawerLeft.Play("Base Layer.LeftDrawerOut");
		 drawerRight.Play("Base Layer.RightDrawerOut");
		 zombieWalk.Play("Base Layer.LivingRoomZombieWalk");
		 
	}
    public void closeDrawers()
	{
		 drawersOpen=false;
		 audioSource.Play();
		 //drawerLeft.enabled=true;
		 drawerLeft.Play("Base Layer.LeftDrawerIn");
		 drawerRight.Play("Base Layer.RightDrawerIn");
		 //drawerLeft.enabled=false;
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.name.Equals("[VRTK][AUTOGEN][HeadsetColliderContainer]"))
		{
			Debug.Log("Trigger Drawer Entered");
			openDrawers();
		}

	}
	public void OnTriggerExit(Collider other)
	{
		if(other.gameObject.name.Equals("[VRTK][AUTOGEN][HeadsetColliderContainer]"))
		{
		  Debug.Log("Trigger Drawer  Exited.");	
          closeDrawers();
		}
	}
}
