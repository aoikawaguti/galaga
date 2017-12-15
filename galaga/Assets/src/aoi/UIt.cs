using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIt : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y <= 330)
        {

            if (Input.GetKeyUp(KeyCode.Space))
            {
                transform.position = new Vector3(475, 330, 0);
            }
            transform.position += new Vector3(0, 3.5f, 0);
        }
    }
}
