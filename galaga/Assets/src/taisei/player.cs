using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	// Use this for initialization
	//GameObject Player;
	void Start () {
		//Player = GameObject.Find ("Player");
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.position += new Vector3 (0.1f, 0);
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.position += new Vector3 (-0.1f, 0);
		}
		if (transform.position.x < -6.25f) {
			transform.position = new Vector3(-6.25f,transform.position.y,0);	//移動制限（左）
		}
		if (transform.position.x > 6.25f) {
			transform.position = new Vector3(6.25f,transform.position.y,0);		//移動制限（右）
		}
	}
}