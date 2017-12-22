using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIt : MonoBehaviour {

    int cnt = 0;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (STOP_Star.READY_time <= 150)
        {
            GameObject.Find("Text").GetComponent<CanvasRenderer>().SetAlpha(100);
            GameObject.Find("Text (1)").GetComponent<CanvasRenderer>().SetAlpha(0);
            GameObject.Find("Text (2)").GetComponent<CanvasRenderer>().SetAlpha(0);
        }else if(STOP_Star.READY_time <= 200){
            GameObject.Find("Text").GetComponent<CanvasRenderer>().SetAlpha(0);
            GameObject.Find("Text (1)").GetComponent<CanvasRenderer>().SetAlpha(0);
            GameObject.Find("Text (2)").GetComponent<CanvasRenderer>().SetAlpha(0);
        }
        else if(STOP_Star.READY_time <= 230)
        {
            if (cnt <= 0)
            {
                GetComponent<AudioSource>().Play();
            }
            cnt++;
            GameObject.Find("Text").GetComponent<CanvasRenderer>().SetAlpha(0);
            GameObject.Find("Text (1)").GetComponent<CanvasRenderer>().SetAlpha(100);
            GameObject.Find("Text (2)").GetComponent<CanvasRenderer>().SetAlpha(0);
        }
        else if(STOP_Star.READY_time <= 260)
        {
            GameObject.Find("Text").GetComponent<CanvasRenderer>().SetAlpha(0);
            GameObject.Find("Text (1)").GetComponent<CanvasRenderer>().SetAlpha(0);
            GameObject.Find("Text (2)").GetComponent<CanvasRenderer>().SetAlpha(100);
        }
       
    }
}
