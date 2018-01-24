using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRFollow : MonoBehaviour {

    public Transform vrPivot;

	// Use this for initialization
	void Start () {
        transform.position = vrPivot.position;
        transform.rotation = vrPivot.rotation;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = vrPivot.position;
        transform.forward = vrPivot.forward;
	}
}
