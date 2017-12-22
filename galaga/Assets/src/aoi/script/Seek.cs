using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : MonoBehaviour {

    float Ene_x, Ene_F;
    int D_Flg;

	// Use this for initialization
	void Start () {
        Ene_F = this.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x > 0 && transform.position.x <= Ene_F+0.9f && D_Flg == 0) {
            transform.position += new Vector3(0.05f,0,0);
        }
        else if (transform.position.x < 0 && transform.position.x >= Ene_F - 0.9f) {
            transform.position -= new Vector3(0.05f, 0, 0);
        }
    }
}
