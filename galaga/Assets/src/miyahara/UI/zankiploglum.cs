using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class zankiploglum : MonoBehaviour
{
    public GameObject zanki1;　 //残機
    public GameObject zanki2;  //残機2
    // Use this for initialization
    void Start()
    {
       
    }
    void Update()
    {
        if (Player.player_zanki == 2)
        {
            Destroy(zanki2);
        }
        if (Player.player_zanki == 1)
        {
            Destroy(zanki1);
        }
    }
}


      
 




