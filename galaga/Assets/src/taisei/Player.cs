using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
	GameObject Player;
	public bool isHitwall;
	// Use this for initialization
	void Start () {
		Player = GameObject.Find ("Galaga_OBJ_dualFighter_0");
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.RightArrow)){
			transform.position += new Vector3 (0.1f, 0);
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.position += new Vector3 (-0.1f, 0);
		}
		if (Input.GetKeyDown(KeyCode.RightArrow) && isHitwall==true ) 
		{
			GetComponent<Rigidbody2D>().AddForce( 
				new Vector3(0, 300.0f, 0));
			isHitwall = false;
		}

	}
}