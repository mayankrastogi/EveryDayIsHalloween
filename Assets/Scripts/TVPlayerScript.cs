using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class TVPlayerScript : MonoBehaviour {

    public GameObject tvScreen;
    bool isvideoPlaying = false;
    VideoPlayer vp;
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
        Debug.Log("Trigger Entered");
        if(isvideoPlaying==false)
        {
            isvideoPlaying = true;
            vp.Play();
        }

    }
    private void OnTriggerExit(Collider Other)
    {
        Debug.Log("Trigger Exited");
        if (isvideoPlaying == true)
        {
            isvideoPlaying = false;
            vp.Pause();
        }
    }

}
