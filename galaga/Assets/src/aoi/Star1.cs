using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star1 : MonoBehaviour
{

    Renderer dia1;
   
    void Start()
    {
        StartCoroutine("LateStart");
        StartCoroutine("Flash");
    }

    IEnumerator LateStart(float time)
    {
        yield return new WaitForSeconds(time);
    }

    private IEnumerator Flash()
    {
        Renderer renderer = GetComponent<Renderer>();

        while(true)//401 ここはゲームモードの変更でループ
        {
            renderer.enabled = !renderer.enabled;

            yield return new WaitForSeconds(Random.Range(0.1f,1.0f)); 
                                                  
        }
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(LateStart(10.0f));

        this.transform.position -= new Vector3(0, 0.07f, 0);
            if (this.transform.position.y <= -5)
            {
                this.transform.position = new Vector3(this.transform.position.x, 10, 0);
            }
    }
}

