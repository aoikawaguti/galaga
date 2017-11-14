using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG : MonoBehaviour {

    Renderer dia,dia1,dia2,dia3,dia4, dia5, dia6, dia7, dia8, dia9, dia10, dia11, dia12, dia13, dia14;

    int[] xaxis = new int[] { -7, -6, -5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5, 6, 7 };
    int[] yaxis = new int[] { -7, -6, -5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5, 6, 7 };
    public static int cnt;

    // Use this for initialization
    void Start () {
       
        GameObject diamond = GameObject.Find("Circle");

        GameObject star = GameObject.Find("Circle 1"); 

        GameObject obj = Instantiate(diamond, new Vector3(xaxis[2], yaxis[5], 0.0f), Quaternion.identity) as GameObject;
        
        GameObject obj1 = Instantiate(star, new Vector3(xaxis[4], yaxis[6], 0.0f), Quaternion.identity) as GameObject;

        GameObject obj2 = Instantiate(diamond, new Vector3(xaxis[3], yaxis[4], 0.0f), Quaternion.identity) as GameObject;

        GameObject obj3 = Instantiate(star, new Vector3(xaxis[13], yaxis[5], 0.0f), Quaternion.identity) as GameObject;

        GameObject obj4 = Instantiate(diamond, new Vector3(xaxis[8], yaxis[14], 0.0f), Quaternion.identity) as GameObject;

        GameObject obj5 = Instantiate(star, new Vector3(xaxis[12], yaxis[7], 0.0f), Quaternion.identity) as GameObject;

        GameObject obj6 = Instantiate(diamond, new Vector3(xaxis[6], yaxis[13], 0.0f), Quaternion.identity) as GameObject;

        GameObject obj7 = Instantiate(star, new Vector3(xaxis[11], yaxis[12], 0.0f), Quaternion.identity) as GameObject;

        GameObject obj8 = Instantiate(diamond, new Vector3(xaxis[3], yaxis[4], 0.0f), Quaternion.identity) as GameObject;

        GameObject obj9 = Instantiate(star, new Vector3(xaxis[6], yaxis[4], 0.0f), Quaternion.identity) as GameObject;

        GameObject obj10 = Instantiate(diamond, new Vector3(xaxis[5], yaxis[5], 0.0f), Quaternion.identity) as GameObject;

        GameObject obj11 = Instantiate(star, new Vector3(xaxis[4], yaxis[11], 0.0f), Quaternion.identity) as GameObject;

        

    }

    // Update is called once per frame
    void Update () {

        if (cnt >= 10 && cnt <= 20)
        {
             
            Debug.Log("cnt:" + cnt);

            if (cnt == 20)
            {
                cnt = 0;
            }
        }

    }
}
