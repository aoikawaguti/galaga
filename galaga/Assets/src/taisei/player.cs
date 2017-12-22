using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public GameObject bulletPrefab; // 弾のオブジェクト
	public GameObject Square;
	public static int count;
	public static int dualflg;
	int frame;

	void Start () {
		dualflg = 0;	//0　操作可能　１　操作不能　2　dual状態
		frame = 0;
	}
	void Update () {
		　　
		if (dualflg == 1) {		//捕まった状態
			transform.Rotate (new Vector2(180,0));
			transform.position = Square.transform.position;
		}
		if(dualflg == 0){		//捕まってない状態
		frame ++;
		if(Input.GetKey(KeyCode.Space) && count <= 1 && frame > 10)	//弾数３以上は出ない
		{
			count++;
			Instantiate(bulletPrefab,new Vector2(transform.position.x-0.021f,transform.position.y),Quaternion.identity); // プレイヤーの位置に弾を生成します
			frame = 0;
		}

		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.position += new Vector3 (0.1f, 0);
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.position += new Vector3 (-0.1f, 0);
		}
		if (transform.position.x < -6.25f) {
			transform.position = new Vector3 (-6.25f, transform.position.y, 0);	//移動制限（左）
		}
		if (transform.position.x > 6.25f) {
			transform.position = new Vector3 (6.25f, transform.position.y, 0);		//移動制限（右）
			}
		}
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        Destroy(this.gameObject);   //自分を消去する
    }
}