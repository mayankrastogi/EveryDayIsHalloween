using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class TVPlayerScript : MonoBehaviour {

    public GameObject tvScreen;
    bool isvideoPlaying = false;
    VideoPlayer vp;
    public AudioSource backgroundMusic;
	// Use this for initialization

    void Awake()
    {
        vp=tvScreen.GetComponent<VideoPlayer>();
    }
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider Other)
    {
        //Debug.Log("Trigger Entered");
        //Debug.Log("Name is " + Other.gameObject.name + " .");
        //[VRTK][AUTOGEN][BodyColliderContainer]
        if(Other.gameObject.name.Equals("[VRTK][AUTOGEN][HeadsetColliderContainer]"))
        {
            Debug.Log("Trigger Entered");
            if(isvideoPlaying==false)
            {
                backgroundMusic.Pause();
                vp.Play();
                isvideoPlaying = true;
            }
        }

    }
    private void OnTriggerExit(Collider Other)
    {
        //Debug.Log("Trigger Exited");
        //[VRTK][AUTOGEN][BodyColliderContainer]
        if(Other.gameObject.name.Equals("[VRTK][AUTOGEN][HeadsetColliderContainer]"))
        {
            Debug.Log("Trigger Exited");
            if (isvideoPlaying == true)
            {
                vp.Pause();
                backgroundMusic.Play();
                isvideoPlaying = false;
            }
        }
    }

}
