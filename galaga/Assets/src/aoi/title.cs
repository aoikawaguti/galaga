using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class title : MonoBehaviour {

    Renderer dia;

    static int blink_cnt;

    // Use this for initialization
    void Start () {
        
    }

    // Update is called once per frame
    void Update()
    {

        blink_cnt++;

        Debug.Log(blink_cnt);

        //Debug.Log(blink_flg);

        dia = GameObject.Find("galaga01").GetComponent<Renderer>();


        


        if (this.transform.position.y <= 1)
        {

            if (Input.GetKeyUp(KeyCode.Space))
            {
                this.transform.position = new Vector3(0, 1, 0);
            }
            this.transform.position += new Vector3(0, 0.05f, 0);
            
        }
        else
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("Scene1");
            }

            if ((blink_cnt >= 0 && blink_cnt <= 5)) 
            {
                dia.material.color = new Color(2.0f, 2.0f, 2.0f, 1.0f);
            }
            else if ((blink_cnt >= 6 && blink_cnt <= 10))
            {
                dia.material.color = new Color(0f, 0f, 0f, 0f);
            }
            else if((blink_cnt >= 10 && blink_cnt <= 15))
            {
                dia.material.color = Color.green;
            }
        }

        if(blink_cnt >= 15)
        {
            blink_cnt = 0;
            
        }

        

    }
}
