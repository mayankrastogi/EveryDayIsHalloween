using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class LookTowardsPlayer : MonoBehaviour {

    public float speedInRadiansPerSecond = 1.0f;

    private Transform startingTransform;

    void Start() {
        //startingTransform = transform.
    }

    // Update is called once per frame
    void Update () {
        Transform headsetTransform = VRTK_DeviceFinder.HeadsetTransform();

        Vector3 targetDirection = headsetTransform.position - transform.position;

        // The step size is equal to speed times frame time.
        float step = speedInRadiansPerSecond * Time.deltaTime;

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, step, 0.0f);

        // Move our position a step closer to the target.
        transform.rotation = Quaternion.LookRotation(newDirection) * Quaternion.Euler(0, 0, -90f);
    }
}
