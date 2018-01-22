using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy3_8 : MonoBehaviour {
    public Bezier myBezier9;
    public Bezier5 myBezier10;
    private float t = 0f;
    private float t2 = 0f;
    public float Speed = 0.5f;
    int a;
    public static int flg = 0;
    double cnt8;
    double e = 101;
    SpriteRenderer MainSpriteRenderer;
    public Sprite StandbySprite;
    public Sprite HoldSprite;
    public int h_flg = -1;
    public static int cnt3;
    int cnt2;
    // Use this for initialization
    void Start () {
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        myBezier9 = new Bezier(new Vector3(-6.5f, -5.5f, 0f), new Vector3(11.5f, 6f, 0f), new Vector3(-0.9f, 5f, 0f), new Vector3(-5f, -0.5f, 0f));
        myBezier10 = new Bezier5(new Vector3(-5f, -0.5f, 0f), new Vector3(2f, -4f, 0f), new Vector3(0.4f, -1.5f, 0f), new Vector3(-0.8f, 2.9f, 0f));
        // StartCoroutine(Exec2());

    }
    IEnumerator Exec2()
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

    }
    // Update is called once per frame
    void Update () {
        cnt3++;
        if (cnt3 >= 23)
        {
            h_flg *= -1;
            cnt3 = 0;
        }

        if (h_flg == -1)
        {
            MainSpriteRenderer.sprite = StandbySprite;
        }
        else
        {
            MainSpriteRenderer.sprite = HoldSprite;
        }
        if (flg == 0)
        {
            Vector3 vec = myBezier9.GetPointAtTime(t);

            transform.position = vec;
            t += 0.01f;
            if (t > 1f)
            {
                t = 1f;
            }
            cnt8++;
            if (cnt8 == (e+2/3))
            {
                flg = 1;
                cnt8 = 0;
            }
        }
        if (flg == 1)
        {
            cnt8++;
            Vector3 vec2 = myBezier10.GetPointAtTime2(t2);

            transform.position = vec2;

            t2 += 0.01f;
            if (t2 > 1f)
            {
                t2 = 1f;
            }
            if (cnt8 == 100)
            {
                flg = 2;
            }
        }
        if (flg == 2)//定位置に着いた後、横移動
        {
            if (cnt2 < 50)
            {
                cnt2++;
                transform.position += new Vector3(0.04f, 0f, 0f) * Time.deltaTime * Speed;
                if (cnt2 == 50)
                {
                    cnt2 = 0;
                }
            }
            if (cnt2 < 180)
            {
                cnt2++;
                transform.position += new Vector3(0.04f, 0f, 0f) * Time.deltaTime * Speed;
            }
            else
            {
                cnt2 = 0;
                flg = 3;

            }
        }
        if (flg == 3)
        {
            if (cnt2 < 180)
            {
                cnt2++;
                transform.position += new Vector3(-0.04f, 0f, 0f) * Time.deltaTime * Speed;
            }
            else
            {
                cnt2 = 0;
                flg = 2;

            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        Destroy(this.gameObject);   //自分を消去する
    }

}
