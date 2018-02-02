using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_4 : MonoBehaviour {
    public Bezier myBezier10;
    public Bezier5 myBezier11;
    public int Speed = 1;
    int a;
    private float t = 0f;
    private float t2 = 0f;
    public static int flg21 = 0;
    double cnt9;
    double e = 101;
    SpriteRenderer MainSpriteRenderer;
    public Sprite StandbySprite;
    public Sprite HoldSprite;
    public int h_flg = -1;
    int cnt3;
    int cnt2;
    // Use this for initialization
    void Start() {
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        //StartCoroutine(CoroutineSample());
        myBezier10 = new Bezier(new Vector3(6.5f, -5.5f, 0f), new Vector3(-11.5f, 6f, 0f), new Vector3(0.9f, 5f, 0f), new Vector3(5f, -0.5f, 0f));
        myBezier11 = new Bezier5(new Vector3(5f, -0.5f, 0f), new Vector3(-2f, -4f, 0f), new Vector3(-0.4f, -1.5f, 0f), new Vector3(3.2f, 3.7f, 0f));
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
    void Generate2()
    {

        transform.Translate(0f, 7f, 0f);

    }
   
   

    // Update is called once per frame
    void Update () {
        cnt3++;
        if (enemy4_8.cnt3 >= 20)
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

        if (flg21 == 0)
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
                flg21 = 1;
                cnt9 = 0;
            }
        }
        if (flg21 == 1)
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
                flg21 = 2;
            }
        }
        if (enemy4_8.flg == 2)//定位置に着いた後、横移動
        {
            if (cnt2 < 180)
            {
                cnt2++;
                transform.position += new Vector3(0.04f, 0f, 0f) * Time.deltaTime * Speed;
            }
            else
            {
                cnt2 = 0;


            }
        }
        if (enemy4_8.flg == 3)
        {
            if (cnt2 < 180)
            {
                cnt2++;
                transform.position += new Vector3(-0.04f, 0f, 0f) * Time.deltaTime * Speed;
            }
            else
            {
                cnt2 = 0;


            }
        }
    }
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {

        Destroy(this.gameObject);   //自分を消去する
    }
}
