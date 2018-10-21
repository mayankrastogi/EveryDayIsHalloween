using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarTriggerScript : MonoBehaviour {

	public Animator clownHead;
	public AudioSource audioSource;
	float elapsed;
	//public Animator zombieWalk;

	bool playAnim;
	bool soundPlayed;
	
	// Use this for initialization
	void Start () {
	
		playAnim=true;
		elapsed = 0f;
		soundPlayed=false;

		
	}
	
	// Update is called once per frame
	void Update () {

			if(playAnim==false)
			{
				elapsed += Time.deltaTime;
                if (elapsed >= 1f) {
                elapsed = elapsed % 1f;
				//Debug.Log("Elapsed Time:" + elapsed);
					if(soundPlayed==false)
					{
                		playSound();
					}
                }
			}
	}
	public void playAnimation()
	{
		//if(playAnim==true)
		//{
	     playAnim=false;
		 //audioSource.Play();
		 clownHead.enabled=true;
		 clownHead.Play("Base Layer.Default Take");
		 
		//}

		 
	}
	public void playSound()
	{
		audioSource.Play();
		soundPlayed=true;
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.name.Equals("[VRTK][AUTOGEN][BodyColliderContainer]"))
		{
			Debug.Log("Bar Trigger Entered");
			if(playAnim==true)
			{
				playAnimation();
			}
		}

	}
	public void OnTriggerExit(Collider other)
	{
	    if(other.gameObject.name.Equals("[VRTK][AUTOGEN][BodyColliderContainer]"))
		{
			Debug.Log("Bar Trigger Exited");
		}
	}
}
