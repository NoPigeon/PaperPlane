﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingBehaviour : MonoBehaviour {

    public float boostForceMag = 20f;

    public AnimationCurve forceCurve;

    [Range(0f, 1f)]
    public float zDistanceFactor = 0.5f;

    new Collider collider;
    float zDepth = 0f;
    private void Start()
    {
        collider = GetComponent<Collider>();
        zDepth = collider.bounds.size.z;
    }

    private void OnTriggerStay(Collider other)
    {
        Rigidbody planeRb = other.GetComponentInParent<Rigidbody>();
        // Debug.Log(other.transform);
        if (planeRb)
        {
            //float dot = Vector3.Dot(planeRb.velocity, transform.forward);

            Vector3 centerToPlane = other.transform.position - transform.position;
            float dist = Vector3.Dot(centerToPlane, transform.forward);
            // Debug.Log(dist);

            if(Mathf.Abs(dist) <= zDepth * zDistanceFactor)
            {
                float distFactor = dist / (zDepth * zDistanceFactor);
                distFactor = Mathf.Clamp(distFactor, -1f, 1f);

                float forceFactor = forceCurve.Evaluate(Mathf.Abs(distFactor));
                //if(distFactor > 0f)
                //{
                //    forceFactor = 1f;
                //}

                Vector3 boostForce = -transform.forward * boostForceMag * forceFactor;
                planeRb.AddForce(boostForce, ForceMode.Acceleration);
            }

            //if(dot < 0 && dist <= zDepth * zDistanceFactor)
            //{
            //    // Debug.Log("enter from front");
            //    // the plane enters the ring front the front
            //    Vector3 boostForce = -transform.forward * boostForceMag;
            //    planeRb.AddForce(boostForce, ForceMode.Acceleration);
            //}
        }
    }
}
