using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		transform.Translate (0, 0.3f, 0);	//0.3ずつ上に飛ぶ

		if (transform.position.y > 6) {
			player.count--;					//弾のカウントを減らす
			Destroy (this.gameObject);		//弾を消す
		}
	}
} 
