using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Bezier5 : System.Object
{
    public Vector3 p4;
    public Vector3 p5;
    public Vector3 p6;
    public Vector3 p7;

    public float ti2 = 0f;

    private Vector3 b4 = Vector3.zero;
    private Vector3 b5 = Vector3.zero;
    private Vector3 b6 = Vector3.zero;
    private Vector3 b7 = Vector3.zero;

    private float Dx;
    private float Dy;
    private float Dz;

    private float Fx;
    private float Fy;
    private float Fz;

    private float Gx;
    private float Gy;
    private float Gz;

    public Bezier5(Vector3 v4, Vector3 v5, Vector3 v6, Vector3 v7)
    {
        this.p4 = v4;
        this.p5 = v5;
        this.p6 = v6;
        this.p7 = v7;

    }
    public Vector3 GetPointAtTime2(float t)
    {
        this.CheckConstant2();
        float t2 = t * t;
        float t3 = t * t * t;
        float x2 = this.Dx * t3 + this.Fx * t2 + this.Gx * t + p4.x;
        float y2 = this.Dy * t3 + this.Fy * t2 + this.Gy * t + p4.y;
        float z2 = this.Dz * t3 + this.Fz * t2 + this.Gz * t + p4.z;

        return new Vector3(x2, y2, z2);
    }
    private void SetConstant2()
    {
        this.Gx = 3f * ((this.p4.x + this.p5.x) - this.p4.x);
        this.Fx = 3f * ((this.p7.x + this.p6.x) - (this.p4.x + this.p5.x)) - this.Gx;
        this.Dx = this.p7.x - this.p4.x - this.Gx - this.Fx;
        this.Gy = 3f * ((this.p4.y + this.p5.y) - this.p4.y);
        this.Fy = 3f * ((this.p7.y + this.p6.y) - (this.p4.y + this.p5.y)) - this.Gy;
        this.Dy = this.p7.y - this.p4.y - this.Gy - this.Fy;

        this.Gz = 3f * ((this.p4.z + this.p5.z) - this.p4.z);
        this.Fz = 3f * ((this.p7.z + this.p6.z) - (this.p4.z + this.p5.z)) - this.Gz;
        this.Dz = this.p7.z - this.p4.z - this.Gz - this.Fz;
    }
    private void CheckConstant2()
    {
        if (this.p4 != this.b4 || this.p5 != this.b5 || this.p6 != this.b6 || this.p7 != this.b7)
        {
            this.SetConstant2();
            this.b4 = this.p4;
            this.b5 = this.p5;
            this.b6 = this.p6;
            this.b7 = this.p7;
        }
    }
}
public class enemy2_4 : MonoBehaviour {
    public Bezier myBezier8;
    public Bezier5 myBezier9;
    private float t = 0f;
    private float t2 = 0f;
    public int Speed = 5;
    int a;
    int flg;
    double cnt;
    int e = 101;
    public GameObject bullet_teki; // 弾のオブジェクト
    int frame;
    // Use this for initialization
    void Start () {
        myBezier8 = new Bezier(new Vector3(-2f, 6f, 0f), new Vector3(-1f, -5f, 0f), new Vector3(4f, 4f, 0f), new Vector3(5f, -1f, 0f));
        //StartCoroutine(Exec2());
        myBezier9 = new Bezier5(new Vector3(5f, -1f, 0f), new Vector3(-4f, -4f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0.8f, 2.9f, 0f));
      
       
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

    }
    void Generate2()
    {
        
            transform.Translate(0f, 7f, 0f);
       
    }*/
   
    // Update is called once per frame
    void Update () {
        if (flg == 0)
        {
            Vector3 vec = myBezier8.GetPointAtTime(t);

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
