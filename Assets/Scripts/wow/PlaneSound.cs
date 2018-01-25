using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaneSound : MonoBehaviour {

    Rigidbody rb;
    public float speed;


    float count;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();

    }
	
	// Update is called once per frame
	void Update () {
        
        Vector3 v = rb.velocity;
        v = transform.InverseTransformVector(v);

//        Debug.Log(v);

       //  v = new Vector3(0f, 0f, v.z);

        float pp = v.magnitude;

        pp = pp / speed;
        if (pp > 1)
        {
            pp = 1;
        }
        rb.gameObject.GetComponent<AudioSource>().volume = (float)pp;
	}

}
