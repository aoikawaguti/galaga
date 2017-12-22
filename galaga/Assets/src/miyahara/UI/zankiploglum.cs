using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class zankiploglum: MonoBehaviour
{
    public GameObject original;
    public GameObject copied;
    public GameObject copied2;
    // Use this for initialization
    void Start()
    {
        copied = Instantiate(original) as GameObject;    //左側の残機
        copied2 = Instantiate(original) as GameObject;　//右側の残機
        copied2.transform.position = new Vector3(6.2f,-2.12f,0);
        //copied.transform.Translate(2, 0, 0);
    }
    // Update is called once per frame
    void Update()
    {
       
        {
            Destroy(copied2, 4f);
        }
    }
}
    
