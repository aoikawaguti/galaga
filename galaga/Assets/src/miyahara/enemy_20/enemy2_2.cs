using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2_2 : MonoBehaviour {
    public Bezier myBezier6;
    private float t = 0f;
    public GameObject player;
    public int Speed = 10;
    int a;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        myBezier6 = new Bezier(new Vector3(4f, 5.5f, 0f), new Vector3(-15f, -2f, 0f), new Vector3(-1f, -14f, 0f), new Vector3(0f, 3.7f, 0f));
        Vector3 pos = myBezier6.GetPointAtTime(t);

        transform.position = pos;
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
