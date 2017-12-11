using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_2 : MonoBehaviour {
    public Bezier myBezier5;
   
    private float t = 0f;
    public int Speed = 10;
    int a;
    int b;
    public int Speed2 = 10;
    void Start()
    {

        //StartCoroutine(modori());


        // Use this for initialization
    }
    /*IEnumerator modori()
    {
        idou();
        yield return null;
    }
    void idou()
    {
       
       b =(int)(Time.time % 2);
        if (b == 0) transform.Translate(new Vector3(0f, 10f, 0) * Time.deltaTime * Speed2);
        else transform.Translate(new Vector3(0f, -10f, 0) * Time.deltaTime * Speed2);
    }*/
    // Update is called once per frame

    void Update () {
        myBezier5 = new Bezier(new Vector3(4f, 5.5f, 0f), new Vector3(-13f, -2f, 0f), new Vector3(-1f, -13f, 0f), new Vector3(0.8f, 3.7f, 0f));
        Vector3 vec = myBezier5.GetPointAtTime(t);

            transform.position = vec;
          
            t += 0.01f;
            if (t > 1f)
            {
                t = 1f;
           
        }
        a = (int)(Time.time % 2);
        if (a == 0) transform.Translate(new Vector3(0.5f, 0f, 0) * Time.deltaTime * Speed);
        else transform.Translate(new Vector3(-0.5f, 0f, 0) * Time.deltaTime * Speed);
       
       // StartCoroutine(modori());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        Destroy(this.gameObject);   //自分を消去する
    }


}
