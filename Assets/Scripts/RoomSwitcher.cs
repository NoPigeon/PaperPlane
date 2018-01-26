using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSwitcher : MonoBehaviour {

    public List<GameObject> collectables;

    public GameObject switchFrom;
    public GameObject switchTo;

    bool switched = false;

	// Use this for initialization
	void Start () {
		if(collectables == null)
        {
            collectables = new List<GameObject>();
        }
	}

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        foreach(GameObject collectable in collectables)
        {
            if (!collectable.activeSelf)
            {
                return;
            }
        }

        // could switch the scene
        if (!switched)
        {
            switched = true;
            switchFrom.SetActive(false);
            switchTo.SetActive(true);

            gameObject.SetActive(false);
        }
    }
}
