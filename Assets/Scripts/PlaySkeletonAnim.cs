using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySkeletonAnim : MonoBehaviour {

    public Animator skeleton;
	public AudioSource audioSource;

    float elapsed;
	//public Animator zombieWalk;

	bool playAnim;
	bool soundPlayed;

	void Start () {
	
		playAnim=true;
		elapsed = 0f;
		soundPlayed=false;

	}	

	// Use this for initialization
	void Update () {
		if(playAnim==false)
			{
				//elapsed += Time.deltaTime;
                //if (elapsed >= 1f) {
                //elapsed = elapsed % 1f;
				//Debug.Log("Elapsed Time:" + elapsed);
					if(soundPlayed==false)
					{
                		playSound();
					}
                }
			}

public void playAnimation()
	{

	     playAnim=false;
		 //audioSource.Play();
		 skeleton.enabled=true;
		 skeleton.Play("Base Layer.SkeletonAnim");
		 
		 
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
			Debug.Log("Trigger Entered for Skeleton Anim");
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
