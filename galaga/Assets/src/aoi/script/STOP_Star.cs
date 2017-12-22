using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class STOP_Star : MonoBehaviour {

    public static float READY_time;




    // Use this for initialization
    void Start () {
        StartCoroutine("Flash");

    }

    private IEnumerator Flash()
    {
        Renderer renderer = GetComponent<Renderer>();
        while(true)//401試験運用
        {
            renderer.enabled = !renderer.enabled;

            yield return new WaitForSeconds(Random.Range(0.1f, 1.0f)); //401 時間(秒)を指定して待機したい場合
                                                                       //401 yield return null; // 1フレーム待機したい場合
        }
    }

    // Update is called once per frame
    void Update () {


        READY_time += Time.deltaTime;

        if (READY_time >= 260f)
        {
            SceneManager.LoadScene("Scene1");
        }


	}
}
