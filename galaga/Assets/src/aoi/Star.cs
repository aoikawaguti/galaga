using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{

    Renderer dia;

    int cnt = 0, flg;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        this.transform.position -= new Vector3(0, 0.1f, 0);

        if(this.transform.position.y <= -5)
        {
            this.transform.position = new Vector3(this.transform.position.x, 10,0);
        }

        cnt++;

    }
}
    
