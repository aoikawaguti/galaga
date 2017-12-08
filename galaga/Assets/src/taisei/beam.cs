using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beam : MonoBehaviour {
	public int beamframe;
	public static int beamflg;

	// Use this for initialization
	void Start (){
		beamframe = 0;
		beamflg = 0;
	}
	// Update is called once per frame
	void Update () {
		beamframe++;
		if (beamframe > 160) {
			Destroy (this.gameObject);
			beamflg = 1;
		}
	}
}
