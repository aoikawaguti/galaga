using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy3_4 : MonoBehaviour {
    public Bezier myBezier9;
    public Bezier myBezier10;
    private float t = 0f;
    public int Speed = 5;
    int a;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        myBezier9 = new Bezier(new Vector3(-7f, -4f, 0f), new Vector3(-15f, 1f, 0f), new Vector3(-3f, -13f, 0f), new Vector3(-1.5f, 4.7f, 0f));
        Vector3 vec = myBezier9.GetPointAtTime(t);

        transform.position = vec;
        t += 0.01f;
        if (t > 1f)
        {
            t = 1f;
        }
        a = (int)(Time.time % 2);
        if (a == 0) transform.Translate(new Vector3(-0.5f, 0f, 0) * Time.deltaTime * Speed);
        else transform.Translate(new Vector3(0.5f, 0f, 0) * Time.deltaTime * Speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        Destroy(this.gameObject);   //自分を消去する
    }
}
