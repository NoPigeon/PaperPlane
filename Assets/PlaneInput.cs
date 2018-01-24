using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using HTC.UnityPlugin.Vive;

public class PlaneInput : MonoBehaviour {

    public static PlaneInput instance = null;

    public Transform leftHand;
    public Transform rightHand;


    public float maxRollAngle = 30f;

    // [-1, 1]
    //public float rollAxis {
    //    get; private set;
    //}
    public float rollAxis;

    [ReadOnly]
    public float rollAngle = 0f;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else if(instance != this)
        {
            Destroy(gameObject);
        }

    }

    // Use this for initialization
    void Start () {
        rollAxis = 0;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 leftPos = leftHand.position;
        Vector3 rightPos = rightHand.position;

        Vector3 rightToLeft = leftPos - rightPos;
        Vector3 rightHori = new Vector3(rightToLeft.x, 0f, rightToLeft.z);

        rollAngle = Vector3.Angle(rightToLeft, rightHori);
        if(leftPos == rightPos)
        {
            rollAngle = 0f;
        }

        if(rightToLeft.y < 0f)
        {
            rollAngle = -rollAngle;
        }

        float clampedRollAngle = Mathf.Clamp(rollAngle, -maxRollAngle, maxRollAngle);

        rollAxis = clampedRollAngle / maxRollAngle;
        
	}
}
