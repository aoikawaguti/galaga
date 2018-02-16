using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Bezier10 : System.Object
{
    public Vector3 p8;
    public Vector3 p9;
    public Vector3 p10;
    public Vector3 p11;

    public float ti2 = 0f;

    private Vector3 b8 = Vector3.zero;
    private Vector3 b9 = Vector3.zero;
    private Vector3 b10 = Vector3.zero;
    private Vector3 b11 = Vector3.zero;

    private float Hx;
    private float Hy;
    private float Hz;

    private float Ix;
    private float Iy;
    private float Iz;

    private float Jx;
    private float Jy;
    private float Jz;

    public Bezier10(Vector3 v8, Vector3 v9, Vector3 v10, Vector3 v11)
    {
        this.p8 = v8;
        this.p9 = v9;
        this.p10 = v10;
        this.p11 = v11;

    }
    public Vector3 GetPointAtTime3(float t)
    {
        this.CheckConstant3();
        float t2 = t * t;
        float t3 = t * t * t;
        float x2 = this.Hx * t3 + this.Ix * t2 + this.Jx * t + p8.x;
        float y2 = this.Hy * t3 + this.Iy * t2 + this.Jy * t + p8.y;
        float z2 = this.Hz * t3 + this.Iz * t2 + this.Jz * t + p8.z;

        return new Vector3(x2, y2, z2);
    }
    private void SetConstant3()
    {
        this.Jx = 3f * ((this.p8.x + this.p9.x) - this.p8.x);
        this.Ix = 3f * ((this.p11.x + this.p10.x) - (this.p8.x + this.p9.x)) - this.Jx;
        this.Hx = this.p11.x - this.p8.x - this.Jx - this.Ix;
        this.Jy = 3f * ((this.p8.y + this.p9.y) - this.p8.y);
        this.Iy = 3f * ((this.p11.y + this.p10.y) - (this.p8.y + this.p9.y)) - this.Jy;
        this.Hy = this.p11.y - this.p8.y - this.Jy - this.Iy;

        this.Jz = 3f * ((this.p8.z + this.p9.z) - this.p8.z);
        this.Iz = 3f * ((this.p11.z + this.p10.z) - (this.p8.z + this.p9.z)) - this.Jz;
        this.Hz = this.p11.z - this.p8.z - this.Jz - this.Iz;
    }
    private void CheckConstant3()
    {
        if (this.p8 != this.b8 || this.p9 != this.b9 || this.p10 != this.b10 || this.p11 != this.b11)
        {
            this.SetConstant3();
            this.b8 = this.p8;
            this.b9 = this.p9;
            this.b10 = this.p10;
            this.b11 = this.p11;
        }
    }
}
    //401 アルファベット　数字ともに地続きに制約
public class enemy3_1 : MonoBehaviour {
    public enemy3_4 enemy3_4;
    public Bezier myBezier9;
    public Bezier5 myBezier10;
    public Bezier10 myBezier11;
    private float t = 0f;
    private float t2 = 0f;
    public int Speed = 1;
    int flg = 0;
    double cnt;
    double e = 101;
    int a;
    int cnt2;
    SpriteRenderer MainSpriteRenderer;
    public Sprite StandbySprite;
    public Sprite HoldSprite;
    public int h_flg = -1;
    int cnt3;
    // Use this for initialization
    void Start () {
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        myBezier9 = new Bezier(new Vector3(-6.5f, -5.5f, 0f), new Vector3(11.5f, 6f, 0f), new Vector3(-0.9f, 5f, 0f), new Vector3(-5f, -0.5f, 0f));
        myBezier10 = new Bezier5(new Vector3(-5f, -0.5f, 0f), new Vector3(2f, -4f, 0f), new Vector3(0.4f, -1.5f, 0f), new Vector3(-1.4f, 4.5f, 0f));

        //StartCoroutine(Exec2());
     
    }
    /*IEnumerator Exec2()
    {
        
        yield return new WaitForSeconds(1.79f);
         while (true)
         {
      
            Vector3 vec2 = myBezier11.GetPointAtTime3(t2);

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
        cnt3++;
        if (enemy3_8.cnt3 >= 20)
        {
            h_flg *= -1;
            cnt3 = 0;
        }

        if (h_flg == 1)
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
            cnt++;
            if (cnt == (e+2/3))
            {
                flg = 1;
                cnt = 0;
            }
        }
        if (flg == 1)
        {
            cnt++;
            Vector3 vec2 = myBezier10.GetPointAtTime2(t2);

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

        if (enemy3_8.flg == 2)//定位置に着いた後、横移動
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
        if (enemy3_8.flg == 3)
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

