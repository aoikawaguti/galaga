using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public static int total_bullet;
	// Use this for initialization
	void Start () {
        
	}

	// Update is called once per frame
	void Update () {
		transform.Translate (0, 0.3f, 0);	//0.3ずつ上に飛ぶ

		if (transform.position.y > 6) {
<<<<<<< HEAD
            Player.bullet_count--;
=======
			player.count--;					//弾のカウントを減らす
>>>>>>> 3d2a31326eaee95d7d85533b5e4235d9bb07ca94
			Destroy (this.gameObject);		//弾を消す
		}
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		Destroy(this.gameObject);   //自分を消去する
		Player.bullet_count--;
	}
} 
