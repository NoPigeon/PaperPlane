using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindForce : MonoBehaviour {
    public Vector3 windForce = Vector3.zero;

    public AnimationCurve forceCurve;

    new Collider collider;

    float highest;
    float height;

    private void Start()
    {
        collider = GetComponent<Collider>();

        highest = collider.bounds.center.y + collider.bounds.extents.y;
        height = collider.bounds.size.y;
    }

    private void OnTriggerStay(Collider collider)
    {
        Rigidbody rb = collider.GetComponentInParent<Rigidbody>();

        Vector3 colliderPos = collider.transform.position;

        if (rb)
        {
            // rb.AddForce(windForce, ForceMode.Acceleration);

            float delta = highest - colliderPos.y;


            float sinkFactor = delta / height;
            sinkFactor = Mathf.Clamp(sinkFactor, 0f, 1f);

//            Debug.Log(sinkFactor);

            float forceFactor = forceCurve.Evaluate(sinkFactor);
            Vector3 finalForce = Vector3.Lerp(Vector3.zero, windForce, forceFactor);
            finalForce = finalForce - Physics.gravity;


            rb.AddForce(finalForce, ForceMode.Acceleration);
        }
    }
}
