using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teki_bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, -0.3f, 0);    //0.3ずつ下に飛ぶ

        if (transform.position.y < -8)
        {
                        
            Destroy(this.gameObject);       //弾を消す
        }
    }
}
