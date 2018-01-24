using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindForce : MonoBehaviour {
    private bool stay;
    public GameObject plant;
    public float pw_x;
    public float pw_y;
    public float pw_z;

    // Use this for initialization
    void Start ()
    {
        stay = false;
        
    }
    
    void FixedUpdate()
    {
        if (stay)
        {
        plant.GetComponent<Rigidbody>().AddForce(pw_x,pw_y,pw_z);
        }

    }

    private void OnTriggerStay(Collider collider)
    {
        stay = true;
    }
    private void OnTriggerExit(Collider collider)
    {
        stay = false;
    }
    // Update is called once per frame
    void Update () {
      /*  if (stay)
        {
            Debug.Log("1");

        }*/
	}
}
