﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy3_2 : MonoBehaviour {
    public enemy3_8 enemy3_8;
    public Bezier myBezier9;
    public Bezier5 myBezier10;
    private float t = 0f;
    private float t2 = 0f;
    public int Speed = 1;
    int a;
    int flg = 0;
    double cnt2;
    double e = 101;
   
    void Start () {
        myBezier9 = new Bezier(new Vector3(-7f, -5f, 0f), new Vector3(14f, 6f, 0f), new Vector3(-4f, 6f, 0f), new Vector3(-5f, -1f, 0f));
        myBezier10 = new Bezier5(new Vector3(-5f, -1f, 0f), new Vector3(4f, -2f, 0f), new Vector3(1f, -2f, 0f), new Vector3(-0.5f, 4.5f, 0f));
        //StartCoroutine(Exec2());
       
    }
    /*IEnumerator Exec2()
    {

        yield return new WaitForSeconds(1.79f);
        while (true)
        {
            Vector3 vec2 = myBezier10.GetPointAtTime2(t2);

            transform.position = vec2;

            t2 += 0.01f;
            if (t2 > 1f)
            {
                t2 = 1f;
            }

            yield return null;
        }
    }*/
    void Generate2()
    {

        transform.Translate(0f, 7f, 0f);

    }
    
    // Update is called once per frame
    void Update () {

        if (flg == 0)
        {
            Vector3 vec = myBezier9.GetPointAtTime(t);

            transform.position = vec;
            t += 0.01f;
            if (t > 1f)
            {
                t = 1f;
            }
            cnt2++;
            if (cnt2 == (e+2/3))
            {
                flg = 1;
                cnt2 = 0;
            }
        }
        if (flg == 1)
        {
            cnt2++;
            Vector3 vec2 = myBezier10.GetPointAtTime2(t2);

            transform.position = vec2;

            t2 += 0.01f;
            if (t2 > 1f)
            {
                t2 = 1f;
            }
            if (cnt2 == 100)
            {
                flg = 2;
            }
        }
      
        if (enemy3_8.flg21 == 2)
        {
            a = (int)(Time.time % 2);
            if (a == 0) transform.Translate(new Vector3(-0.05f, 0f, 0) * Time.deltaTime * Speed);
            else transform.Translate(new Vector3(0.05f, 0f, 0) * Time.deltaTime * Speed);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        Destroy(this.gameObject);   //自分を消去する
    }
}
