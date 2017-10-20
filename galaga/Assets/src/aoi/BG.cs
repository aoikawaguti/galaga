using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG : MonoBehaviour {

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        GameObject diamond = GameObject.Find("Circle");

        GameObject star = GameObject.Find("Circle 1");

        GameObject obj = Instantiate(diamond,new Vector3(Random.Range(-7.0f,7.0f),7.0f,0.0f),Quaternion.identity) as GameObject;
        Destroy(obj, 2);

        GameObject obj1 = Instantiate(star, new Vector3(Random.Range(-7.0f, 7.0f), 7.0f, 0.0f), Quaternion.identity) as GameObject;
        Destroy(obj1, 2);


    }
}
