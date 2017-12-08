using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class title : MonoBehaviour {

    Renderer dia;

    static int cnt;

    // Use this for initialization
    void Start () {
        
    }

    // Update is called once per frame
    void Update()
    {

        cnt++;

        Debug.Log(cnt);

        dia = GameObject.Find("galaga01").GetComponent<Renderer>();
        
        if (this.transform.position.y <= 1)
        {
            this.transform.position += new Vector3(0, 0.05f, 0);

        }
        else
        {
            if (cnt >= 0 && cnt <= 5)
            {
                dia.material.color = new Color(2.0f, 2.0f, 2.0f, 1.0f);
            }
            else if (cnt >= 6 && cnt <= 10)
            {
                dia.material.color = new Color(0f, 0f, 0f, 0f);
            }
            else
            {
                dia.material.color = Color.green;
            }
        }

        if(cnt == 15)
        {
            cnt = 0;
        }

    }
}
