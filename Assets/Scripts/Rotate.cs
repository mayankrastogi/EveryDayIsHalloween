using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    public int speed;
    //string name1;
	// Use this for initialization
	void Start () {
        //name1=this.name;
        //Debug.Log("The name of the object is" + name1);
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(new Vector3(0, Time.deltaTime * 50, 0));
    }
}
