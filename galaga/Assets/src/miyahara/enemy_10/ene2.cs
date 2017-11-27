using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ene2 : MonoBehaviour {
    public Bezier myBezier2;
    private float t = 0f;
    public int Speed = 5;
    int a;


    // Use this for initialization
    void Start () {
       
      
       
    }
    
    // Update is called once per frame
    void Update () {
        myBezier2 = new Bezier(new Vector3(-4.0f, 6.0f, 0f), new Vector3(13f, 2f, 0f), new Vector3(1f, -13f, 0f), new Vector3(0f, 2.1f, 0f));
        Vector3 vec = myBezier2.GetPointAtTime(t);
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
