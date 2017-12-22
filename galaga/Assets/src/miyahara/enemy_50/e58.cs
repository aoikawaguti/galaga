using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e58 : MonoBehaviour {
    public Bezier myBezier;
    public Bezier5 myBezier9;
    private float t2 = 0f;
    private float t = 0f;
    public int Speed = 5;
    int a;
    int flg;
    double cnt;
    int e = 101;
    public GameObject bullet_teki; // 弾のオブジェクト
    int frame;
    // Use this for initialization
    void Start () {
        myBezier = new Bezier(new Vector3(-2f, 6f, 0f), new Vector3(-1f, -5f, 0f), new Vector3(4f, 4f, 0f), new Vector3(5f, -1f, 0f));
        myBezier9 = new Bezier5(new Vector3(5f, -1f, 0f), new Vector3(-4f, -4f, 0f), new Vector3(0f, 0f, 0f), new Vector3(3.2f, 1.3f, 0f));
        //StartCoroutine(Exec2());
       

    }
    /*IEnumerator Exec2()
    {
        yield return new WaitForSeconds(1.8f);
        while (true)
        {

            Vector3 vec2 = myBezier9.GetPointAtTime2(t2);

            transform.position = vec2;

            t2 += 0.01f;
            if (t2 > 1f)
            {
                t2 = 1f;
            }
            yield return null;
        }

    }*/
    // Update is called once per frame
    void Update () {
        if (flg == 0)
        {
            Vector3 vec = myBezier.GetPointAtTime(t);

            transform.position = vec;
            t += 0.01f;
            if (t > 1f)
            {
                t = 1f;
            }
            cnt++;
            if (cnt == (e + 2 / 3))
            {
                flg = 1;
                cnt = 0;
            }
        }
        if (flg == 1)
        {
            cnt++;
            Vector3 vec2 = myBezier9.GetPointAtTime2(t2);

            transform.position = vec2;

            t2 += 0.01f;
            if (t2 > 1f)
            {
                t2 = 1f;
            }
            if (cnt == 100)
            {
                flg = 2;
            }
        }

        if (flg == 2)
        {
            a = (int)(Time.time % 2);
            if (a == 0) transform.Translate(new Vector3(0.05f, 0f, 0) * Time.deltaTime * Speed);
            else transform.Translate(new Vector3(-0.05f, 0f, 0) * Time.deltaTime * Speed);
        }


        frame++;
        if (frame == 200)
        {
            Instantiate(bullet_teki, new Vector2(transform.position.x - 0.1f, transform.position.y), Quaternion.identity); // 敵の位置に弾を生成します
            frame = 0;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.Find("SCORE").SendMessage("ScoreUp");
        Destroy(this.gameObject);   //自分を消去する
    }
}
