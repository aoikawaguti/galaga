using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
	// Use this for initialization
	GameObject Player;
	void Start () {
		Player = GameObject.Find ("Player");
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.RightArrow)){
			transform.position += new Vector3 (0.1f, 0);
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.position += new Vector3 (-0.1f, 0);
		}
		Player.transform.position = (new Vector3(Mathf.Clamp (Player.transform.position.x, -6, 6)));
	}
}