using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{

    Renderer dia;

    // Use this for initialization
    void Start()
    {
        Color randomColor = new Color(Random.value, Random.value, Random.value, 1.0f);
        dia = GameObject.Find("Circle").GetComponent<Renderer>();
        dia.material.color = randomColor;
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position -= new Vector3(0, 0.1f, 0);   
    }
}
    
