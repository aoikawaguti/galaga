using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class zankiploglum : MonoBehaviour
{
    public GameObject original;
    public GameObject zanki1;　 //残機
    public GameObject zanki2;  //残機2
    public static int  Player;  //プレイヤー
    // Use this for initialization
    void Start()
    {
        //Player_zanki = 3;
        //copied.transform.Translate(2, 0, 0);
        var wreckClone = Instantiate(wreck, transform.position, transform.rotation);
    }

    void Update()
    {
        if (Player.player == 2);
        {
            Destroy(zanki2);
        }
        if (Player.player == 1);
        {
            Destroy(zanki1);
        }
        

    }


}
       
   //void OntriggerEnter2D(other)
    //{

  // }



