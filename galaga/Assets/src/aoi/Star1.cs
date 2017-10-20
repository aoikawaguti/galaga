using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star1 : MonoBehaviour
{

    Renderer dia1;

    // Use this for initialization
    void Start()
    {
        Color randomColor = new Color(Random.value, Random.value, Random.value, 1.0f);
        dia1 = GameObject.Find("Circle 1").GetComponent<Renderer>();
        dia1.material.color = randomColor;

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position -= new Vector3(0, 0.2f, 0);
    }
}

