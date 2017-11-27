using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e58 : MonoBehaviour {
    public Bezier myBezier;

    private float t = 0f;
    public int Speed = 5;
    int a;
    // Use this for initialization
    void Start () {
        myBezier = new Bezier(new Vector3(-4f, 5.5f, 0f), new Vector3(15f, 2f, 0f), new Vector3(-5f, -13f, 0f), new Vector3(3.2f, 1.3f, 0f));

    }

    // Update is called once per frame
    void Update () {
        Vector3 vec = myBezier.GetPointAtTime(t);

        transform.position = vec;
      

        t += 0.01f;
        if (t > 1f)
        {
            t = 1f;
        }
        a = (int)(Time.time % 2);
        if (a == 0) transform.Translate(new Vector3(0.5f, 0f, 0) * Time.deltaTime * Speed);
        else transform.Translate(new Vector3(-0.5f, 0f, 0) * Time.deltaTime * Speed);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        Destroy(this.gameObject);   //自分を消去する
    }
}
