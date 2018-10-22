using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class RecenterPlayArea : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Recenter() {
        Transform playArea = VRTK_DeviceFinder.PlayAreaTransform();
        if (playArea != null) {
            Debug.Log("PlayArea position: " + playArea.position + " rotation " + playArea.rotation);
            playArea.position = Vector3.zero;
            playArea.rotation = Quaternion.identity;
        }
    }
}
