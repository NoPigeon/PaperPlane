using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;
	public GameObject myPrefab;

	private Rigidbody rb;
	private int count;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		winText.text = "";
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float x = Input.GetAxis ("Horizontal");
		float z = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (x, 0.0f, z);

		rb.AddForce (movement*speed);

	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Pick Up")) {
			GameObject newObject = (GameObject)Instantiate (myPrefab, other.transform.position, other.transform.rotation);
			Destroy (newObject, 2);
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		}
	}

	void SetCountText(){
		countText.text = "Count:" + count.ToString ();
		if (count >= 12) {
			winText.text="You Win!";
		}
	}


}


