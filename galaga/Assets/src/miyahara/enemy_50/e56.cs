using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e56 : MonoBehaviour {
    public Bezier myBezier;
    public Bezier5 myBezier9;
    private float t2 = 0f;
    private float t = 0f;
    public int Speed = 1;
    int a;
    int flg;
    double cnt;
    int cnt2;
    int e = 101;
    public GameObject bullet_teki; // 弾のオブジェクト
    int frame;
    SpriteRenderer MainSpriteRenderer;
    public Sprite StandbySprite;
    public Sprite HoldSprite;
    public int h_flg = -1;
    int cnt3;
    // Use this for initialization
    void Start () {
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        myBezier = new Bezier(new Vector3(-2f, 6f, 0f), new Vector3(-1f, -5f, 0f), new Vector3(3f, 3f, 0f), new Vector3(5f, -1f, 0f));
        myBezier9 = new Bezier5(new Vector3(5f, -1f, 0f), new Vector3(-3f, -2f, 0f), new Vector3(0f, 0f, 0f), new Vector3(3.2f, 2.1f, 0f));
        //StartCoroutine(Exec2());

    }
    IEnumerator Exec2()
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

    }
    // Update is called once per frame
    void Update () {
        cnt3++;
        if (e58.cnt3 >= 20)
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

        if (e58.flg == 2)//定位置に着いた後、横移動
        {
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
        if (e58.flg == 3)
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
