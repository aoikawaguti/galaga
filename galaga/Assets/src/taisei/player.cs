using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public GameObject bulletPrefab;
	public GameObject Galaga_BOSS_prefab;//BOSS敵
    public Animator anim;
    public GameObject Player_prefab;
    public GameObject Player_prefab2;//Player複製したものを制御するためのobj
    public static int bullet_count;
    public static int total_bullet;
    public static int dualflg;
    public static int Player_zanki;
    public int bullet_frame;
    public int Player_instantiate;
    public int Player_idou;
    public int Player_flg;
    public int Player_tuibi;
    public static int animframe;
    void Start () {
        Player_prefab2 = GameObject.FindWithTag("Player");
        bullet_count = 0;//弾の制限変数
        total_bullet = 0;//リザルトで出す弾の総数
        dualflg = 0;	 //0　操作可能　１　操作不能　2　dual状態
        Player_zanki = 3;//プレイヤーの残機
        bullet_frame = 0;       //弾の発射間隔
        Player_instantiate = 0;//1回のみ複製するため
        Player_idou = 0;
        Player_flg = 0;
        Player_tuibi = 0;
        animframe = 0;
    }
	void Update () {
        
        //Debug.Log(dualflg);
        Debug.Log(Bullet.total_bullet);
        bullet_frame++;

		if(dualflg == 0){       //捕まってない状態
            Player_idou = 0;
		if(Input.GetKey(KeyCode.Space) && bullet_count <= 1 && bullet_frame > 10)	//弾数３以上は出ない、かつframeが10以上なら発射
		{
			bullet_count++;
			Instantiate(bulletPrefab,new Vector2(transform.position.x-0.021f,transform.position.y),Quaternion.identity); // プレイヤーの位置に弾生成
			bullet_frame = 0;
            Bullet.total_bullet++;
		}
        //移動関連//
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

        if (dualflg == 1){  //捕まった状態	
            if (Player_instantiate == 0){//一回のみ複製
                Player_prefab2 = Instantiate(Player_prefab) as GameObject;//複製したものをGameObjectとして制御
                Player_instantiate = 1;
            }
            if (Galaga_BOSS_prefab.transform.position.y < transform.position.y) {
                Player_tuibi = 1;
            }
            if (Player_tuibi == 1)
            {
                transform.position = new Vector2(Galaga_BOSS_prefab.transform.position.x + 0.08f, Galaga_BOSS_prefab.transform.position.y + 0.8f);//BOSS敵追従
            }
        }

        if (dualflg == 2)
        {   //DualFighter状態
            animframe++;
            Player_tuibi = 0;
            anim.SetBool("Bool", false);
            Player_instantiate = 0;
            Player_flg = 1;
            if (Player_idou == 0 && animframe > 100)
            {
                transform.position = new Vector2(Player_prefab2.transform.position.x + 0.7f, Player_prefab2.transform.position.y);//Player追従
                Player_idou = 1;
            }
            if (animframe > 100)
            {
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    transform.position += new Vector3(0.1f, 0);
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    transform.position += new Vector3(-0.1f, 0);
                }
                if (transform.position.x < -5.50f)
                {
                    transform.position = new Vector3(-5.50f, transform.position.y, 0);  //移動制限（左）
                }
                if (transform.position.x > 6.25f)
                {
                    transform.position = new Vector3(6.25f, transform.position.y, 0);       //移動制限（右）
                }
                if (Input.GetKey(KeyCode.Space) && bullet_count <= 3 && bullet_frame > 10)
                {
                    bullet_count++;
                    Instantiate(bulletPrefab, new Vector2(transform.position.x - 0.021f, transform.position.y), Quaternion.identity); // プレイヤーの位置に弾を生成します
                    bullet_frame = 0;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)//要修正
    {
        if (other.gameObject.tag == "beam" && dualflg == 0)//beamに当たったら捕まった状態に。
        {
            dualflg = 1;
            anim.SetBool("Bool", true);
        }
        if (dualflg == 2)
        {
            transform.position = new Vector2(Player_prefab2.transform.position.x, Player_prefab2.transform.position.y);
            Destroy(Player_prefab2);
			animframe = 0;
            dualflg = 0;
        }
    }
}