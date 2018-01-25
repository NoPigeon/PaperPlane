using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRFollow : MonoBehaviour {

    public Transform vrPivot;

    [Range(0f, 1f)]
    public float lerpFactor = 0.5f;

	// Use this for initialization
	void Start () {
        transform.position = vrPivot.position;
        transform.rotation = vrPivot.rotation;
	}
	
	void Update () {
        transform.position = vrPivot.position;

        //Vector3 targetForward = vrPivot.forward;
        //Vector3 currentForward = transform.forward;

        //float deltaAngle = Vector3.Angle(currentForward, targetForward) * Mathf.Deg2Rad;
        //Debug.Log(deltaAngle);


        //Vector3 lerpedForward = Vector3.RotateTowards(currentForward, targetForward, deltaAngle * lerpFactor, 0f);

        //// transform.forward = lerpedForward;
        transform.forward = vrPivot.forward;

        //Quaternion pivotRotation = vrPivot.rotation;
        //Quaternion targetRotation = Quaternion.Euler(0f, pivotRotation.eulerAngles.y, 0f);
        //transform.rotation = 
        // Debug.Log(1f / Time.deltaTime);
	}
}
