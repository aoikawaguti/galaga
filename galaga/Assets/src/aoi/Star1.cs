using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star1 : MonoBehaviour
{

    Renderer dia1;


    // Use this for initialization
    void Start()
    {
        StartCoroutine("Flash");
    }

    private IEnumerator Flash()
    {
        Renderer renderer = GetComponent<Renderer>();
        for (int i = 0; i < 100; i++)//401 ここはゲームモードの変更でループ
        {
            renderer.enabled = !renderer.enabled;

            yield return new WaitForSeconds(Random.Range(0.1f,1.0f)); // 時間(秒)を指定して待機したい場合
                                                   // yield return null; // 1フレーム待機したい場合
        }
    }

    // Update is called once per frame
    void Update()
    {
        
            this.transform.position -= new Vector3(0, 0.07f, 0);
            if (this.transform.position.y <= -5)
            {
                this.transform.position = new Vector3(this.transform.position.x, 10, 0);
            }
    }
}

