using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Bezier : System.Object
{
    public Vector3 p0;
    public Vector3 p1;
    public Vector3 p2;
    public Vector3 p3;

    public float ti = 0f;

    private Vector3 b0 = Vector3.zero;
    private Vector3 b1 = Vector3.zero;
    private Vector3 b2 = Vector3.zero;
    private Vector3 b3 = Vector3.zero;

    private float Ax;
    private float Ay;
    private float Az;

    private float Bx;
    private float By;
    private float Bz;

    private float Cx;
    private float Cy;
    private float Cz;



    public Bezier(Vector3 v0, Vector3 v1, Vector3 v2, Vector3 v3)
    {
        this.p0 = v0;
        this.p1 = v1;
        this.p2 = v2;
        this.p3 = v3;
    }
    // 0.0 >= t <= 1.0
    public Vector3 GetPointAtTime(float t)
    {
        this.CheckConstant();
        float t2 = t * t;
        float t3 = t * t * t;
        float x = this.Ax * t3 + this.Bx * t2 + this.Cx * t + p0.x;
        float y = this.Ay * t3 + this.By * t2 + this.Cy * t + p0.y;
        float z = this.Az * t3 + this.Bz * t2 + this.Cz * t + p0.z;
        return new Vector3(x, y, z);
    }
    private void SetConstant()
    {
        this.Cx = 3f * ((this.p0.x + this.p1.x) - this.p0.x);
        this.Bx = 3f * ((this.p3.x + this.p2.x) - (this.p0.x + this.p1.x)) - this.Cx;
        this.Ax = this.p3.x - this.p0.x - this.Cx - this.Bx;
        this.Cy = 3f * ((this.p0.y + this.p1.y) - this.p0.y);
        this.By = 3f * ((this.p3.y + this.p2.y) - (this.p0.y + this.p1.y)) - this.Cy;
        this.Ay = this.p3.y - this.p0.y - this.Cy - this.By;

        this.Cz = 3f * ((this.p0.z + this.p1.z) - this.p0.z);
        this.Bz = 3f * ((this.p3.z + this.p2.z) - (this.p0.z + this.p1.z)) - this.Cz;
        this.Az = this.p3.z - this.p0.z - this.Cz - this.Bz;

    }
    // Check if p0, p1, p2 or p3 have change
    private void CheckConstant()
    {
        if (this.p0 != this.b0 || this.p1 != this.b1 || this.p2 != this.b2 || this.p3 != this.b3)
        {
            this.SetConstant();
            this.b0 = this.p0;
            this.b1 = this.p1;
            this.b2 = this.p2;
            this.b3 = this.p3;
        }
    }
}

public class Enemy : MonoBehaviour {

    public GameObject bullet_teki; // 弾のオブジェクト
    int frame;
    public Bezier myBezier;
    public Bezier5 myBezier9;
    private float t = 0f;
    private float t2 = 0f;
    public float Speed = 2f;

    public static int flg;
    double cnt;
    int cnt2;
    int e = 101;
    public bool zako;
    SpriteRenderer MainSpriteRenderer;
    public Sprite StandbySprite;
    public Sprite HoldSprite;
    public int h_flg = -1;
    int cnt3;
    void Start() {
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        myBezier = new Bezier(new Vector3(2f, 6f, 0f), new Vector3(1f, -5f, 0f), new Vector3(-3f, 3f, 0f), new Vector3(-5f, -1f, 0f));
       
        myBezier9 = new Bezier5(new Vector3(-5f, -1f, 0f), new Vector3(3f, -2f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.8f, 2.1f, 0f));
        //StartCoroutine(kougeki());
       

    }
   

      
    
    IEnumerator kougeki()
    {
            yield return new WaitForSeconds(23f);
        while (true)
        {
            zako = true;
            GetComponent<Animator>().SetBool("zako",zako);
            cnt2++;
            if (cnt2 == 100)
            {
                break ;
               
            }
           
        }
      
    }

    // Update is called once per frame
    void Update()
    {
        cnt3++;
        if (e4.cnt3 >= 20)
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

        if (flg == 0)//ベジエ曲線中間点まで
        {
            Vector3 vec = myBezier.GetPointAtTime(t);

            transform.position = vec;
            t += 0.01f;
            if (t > 1f)
            {
                t = 1f;
            }
            //中間点につくまでのフレームまで繰り返しフラグを切り替える
            cnt++;
            if (cnt == (e + 2 / 3))
            {
                flg = 1;
                cnt = 0;
            }
        }
        if (flg == 1)//ベジエ曲線中間点から定位置まで
        {
            cnt++;
            Vector3 vec2 = myBezier9.GetPointAtTime2(t2);

            transform.position = vec2;

            t2 += 0.01f;
            if (t2 > 1f)
            {
                t2 = 1f;
            }
            //定位置につくまでのフレームまで繰り返しフラグを切り替える
            if (cnt == 100)
            {
                flg = 2;
            }
        }
        if (e4.flg == 2)//定位置に着いた後、横移動
        {
            if (cnt2 < 100)
            {
                cnt2++;
                transform.position += new Vector3(0.04f, 0f, 0f) * Time.deltaTime * Speed;
                if (cnt2 == 100)
                {
                    cnt2 = 0;

                }
            }
            if (cnt2 < 180)
            {
                cnt2++;
                transform.position += new Vector3(-0.04f, 0f, 0f) * Time.deltaTime * Speed;
            }
            else 
            {
                cnt2 = 0;
                flg = 3;
               
            }
        }
        if (e4.flg == 3)
        {
            if (cnt2 < 180)
            {
                cnt2++;
                transform.position += new Vector3(0.04f, 0f, 0f) * Time.deltaTime * Speed;
            }
           else
            {
                cnt2 = 0;
                flg = 2;
               
            }
        }


        //弾の生成
        frame++;
        if (frame == 200)
        {
            Instantiate(bullet_teki, new Vector2(transform.position.x - 0.1f, transform.position.y), Quaternion.identity); // 敵の位置に弾を生成します
            frame = 0;
        }

    }
    
          
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.Find("SCORE").SendMessage("ScoreUp");//scriptSCOREのScoreUp関数呼び出し
        Destroy(this.gameObject);   //自分を消去する
       
    }
}
