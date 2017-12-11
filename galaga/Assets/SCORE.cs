using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SCORE : MonoBehaviour {
    int ScoreData = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Text>().text = "" + ScoreData.ToString("00");
        
	}
    void ScoreUp()
    {
        ScoreData += 100;
    }
}
