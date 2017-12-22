using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy4_7 : MonoBehaviour {
    public enemy_4 enemy_4;
    public Bezier myBezier10;
    public Bezier5 myBezier11;
    public int Speed = 1;
    int a;
    private float t = 0f;
    private float t2 = 0f;
    double flg7 = 0;
    double cnt9;
    double e = 101;
    // Use this for initialization
    void Start () {
        //StartCoroutine(CoroutineSample());
        myBezier10 = new Bezier(new Vector3(7f, -5f, 0f), new Vector3(-14f, 6f, 0f), new Vector3(4f, 6f, 0f), new Vector3(5f, -1f, 0f));
        myBezier11 = new Bezier5(new Vector3(5f, -1f, 0f), new Vector3(-4f, -2f, 0f), new Vector3(-1f, -2f, 0f), new Vector3(-1.6f, 2.9f, 0f));
    }
    IEnumerator CoroutineSample()
    {

        yield return new WaitForSeconds(1.79f);
        while (true)
        {
            Vector3 vec2 = myBezier11.GetPointAtTime2(t2);

            transform.position = vec2;

            t2 += 0.01f;
            if (t2 > 1f)
            {
                t2 = 1f;
            }

            yield return null;
        }
    }
    // Update is called once per frame
    void Update () {
    
       
        if (flg7 == 0)
        {
            Vector3 vec = myBezier10.GetPointAtTime(t);

            transform.position = vec;
            t += 0.01f;
            if (t > 1f)
            {
                t = 1f;
            }
            cnt9++;
            if (cnt9 == (e + 2 / 3))
            {
                flg7 = 1;
                cnt9 = 0;
            }
        }
        if (flg7 == 1)
        {
            cnt9++;
            Vector3 vec2 = myBezier11.GetPointAtTime2(t2);

            transform.position = vec2;

            t2 += 0.01f;
            if (t2 > 1f)
            {
                t2 = 1f;
            }
            if (cnt9 == 100)
            {
                flg7 = 2;
            }
        }
        if (enemy_4.flg21 == 2)
        {
            a = (int)(Time.time % 2);
            if (a == 0) transform.Translate(new Vector3(0.05f, 0f, 0) * Time.deltaTime * Speed);
            else transform.Translate(new Vector3(-0.05f, 0f, 0) * Time.deltaTime * Speed);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        Destroy(this.gameObject);   //自分を消去する
    }
}
