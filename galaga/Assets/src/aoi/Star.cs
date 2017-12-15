using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{

    Renderer dia;

    static int flg = 1;

    private float nextTime;
    public float interval = 3.0f;//点滅用の間隔

    // Use this for initialization
    void Start()
    {
        //401 点滅コルーチンを実行
        StartCoroutine("Flash");
    }

    private IEnumerator Flash()
    {
        Renderer renderer = GetComponent<Renderer>();
        while (true)//401試験運用
        {
            renderer.enabled = !renderer.enabled;

            yield return new WaitForSeconds(Random.Range(0.1f,1.0f)); //401 時間(秒)を指定して待機したい場合
                                                   //401 yield return null; // 1フレーム待機したい場合
        }
    }

    void Update()
    {
        this.transform.position -= new Vector3(0, 0.04f, 0);

        if (this.transform.position.y <= -5)
        {
            this.transform.position = new Vector3(this.transform.position.x, 10, 0);
        }

    }
}
    
