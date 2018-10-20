using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ZombieAnimation : MonoBehaviour {

	public AudioSource audioSource;
	int count;
	// Use this for initialization
	void Start () {
		count=0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void Hello()
    {
        
    }
	void playZombieSound()
	{
		
		if(count < 1)
		{		
			
		    audioSource.Play();
		}
		count ++;
		if (count >5)
		{
			count=0;
		}
		
	}
}
