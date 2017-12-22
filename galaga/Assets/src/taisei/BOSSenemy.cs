using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSSenemy : MonoBehaviour {
	public GameObject Galaga_OBJ_effect_prefab;
	public static int beamcount;
	public static int animflg;
	public static int instantiate;
	// Use this for initialization
	void Start () {
		beamcount = 0;
		instantiate = 0;
	}
	
	// Update is called once per frame
	void Update () {
			transform.Translate (0, -0.1f, 0);
		if (beamcount >= 2 && transform.position.y < -2.5f) {
            if (instantiate == 0)
            {
                    Instantiate(Galaga_OBJ_effect_prefab, new Vector2(transform.position.x + 0.1f, transform.position.y - 0.3f), Quaternion.identity);
                    instantiate = 1;
            }
            transform.position = new Vector2(transform.position.x, -2.5f);
            if (beam.beamflg == 1) {
				beamcount = 0;
				instantiate = 0;
				beam.beamflg = 0;
			}
		}
        
        if (transform.position.y < -6) {
			transform.position = new Vector3 (transform.position.x,6, 0);
			beamcount++;
		}
	}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "bullet")
        {
            if (Player.dualflg == 1)
            {
                
                Player.dualflg = 2;
            }
            //Destroy(this.gameObject);
        }
    }
}
