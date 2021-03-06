﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement : MonoBehaviour {

	public float forwardWindSpeed = 40f;
	public float maxForwardSpeed = 30f;
    public float maxBackwardSpeed = 30f;



	public float lerpFactor = 0.5f;

	float lastVertical = 0f;

	public float yawSpeed = 10f;

    [Range(0f, 1f)]
    public float rollAngleFactor = 0.33f;

	Rigidbody rb;
	new Collider collider;

	Vector3 tailPivot;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		collider = GetComponent<Collider> ();


		Vector3 zOffset = new Vector3 (0f, 0f, -collider.bounds.extents.z);
		tailPivot = collider.bounds.center + zOffset;
	}
	
	// Update is called once per frame
	void Update () {
        // Debug.Log (rb.velocity.y);
        
	}

	void FixedUpdate(){
		Vector3 forwardWindForce = transform.forward * forwardWindSpeed;
		rb.AddForce (forwardWindForce, ForceMode.Acceleration);

		float forwardInput = Input.GetAxis ("Vertical");

        float playerForceMag = 0f;
        if(forwardInput > 0f)
        {
            playerForceMag = maxForwardSpeed * forwardInput;
        } else
        {
            playerForceMag = maxBackwardSpeed * forwardInput;
        }

		Vector3 playerFactorForce = transform.forward * playerForceMag;
		rb.AddForce (playerFactorForce, ForceMode.Acceleration);


		float yawInput = Input.GetAxis ("Horizontal");
		Vector3 yawTorque = Vector3.up * yawSpeed * yawInput;

        // rb.AddTorque (yawTorque, ForceMode.VelocityChange);

        rb.angularVelocity += yawTorque;

        Vector3 rollTorque = -transform.forward * yawSpeed * yawInput * rollAngleFactor;
        //rb.AddTorque(rollTorque, ForceMode.VelocityChange);
        // rb.angularVelocity += rollTorque;

        Vector3 newRotEuler = rb.rotation.eulerAngles;
        newRotEuler.z = -rb.angularVelocity.y * Mathf.Rad2Deg * rollAngleFactor;
        Quaternion newRot = Quaternion.Euler(newRotEuler);

        rb.rotation = newRot;

        //float rollAngle = rb.angularVelocity.y * rollAngleFactor;
        //Quaternion rollQuat = Quaternion.Euler(0f, 0f, rollAngle * Mathf.Rad2Deg);
        //rb.rotation = rollQuat;

    }
}
