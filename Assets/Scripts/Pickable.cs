using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour {

    public float rotateSpeed = 45f;
    public GameObject pickedObject;
    public AudioClip pickClip;

    private new Collider collider;
    private new Renderer renderer;
    private bool picked = false;
    private AudioSource clipSource;



	// Use this for initialization
	void Start () {
        collider = GetComponent<Collider>();
        renderer = GetComponentInChildren<Renderer>();
        clipSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0f, rotateSpeed, 0f) * Time.deltaTime);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (!picked)
        {
            picked = true;
            if (pickedObject)
            {
                pickedObject.SetActive(true);
                
            }
            if (clipSource)
            {
                clipSource.PlayOneShot(pickClip);
            }
        }

        collider.enabled = false;
        renderer.enabled = false;

       
    }
}
