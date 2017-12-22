using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public GameObject bulletPrefab; // 弾のオブジェクト
    public GameObject Galaga_BOSS_prefab;
    public GameObject Player_prefab2;
    public int Player_instantiate;//一回のみ複製するための変数
    public int bullet_frame2;//弾の発射間隔の制御変数

    void Start()
    {
        Player_instantiate = 0;
        bullet_frame2 = 0;
    }
    void Update()
    {
        bullet_frame2++;
        if (Player.dualflg == 1)
        {
            if (Input.GetKey(KeyCode.Space) && Player.bullet_count <= 1 && bullet_frame2 > 10)
            {
                Player.bullet_count++;
                Instantiate(bulletPrefab, new Vector2(transform.position.x - 0.021f, transform.position.y), Quaternion.identity); // プレイヤーの位置に弾を生成します
                bullet_frame2 = 0;
                Bullet.total_bullet++;
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += new Vector3(0.1f, 0);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += new Vector3(-0.1f, 0);
            }
            if (transform.position.x < -6.25f)
            {
                transform.position = new Vector3(-6.25f, transform.position.y, 0);  //移動制限（左）
            }
            if (transform.position.x > 6.25f)
            {
                transform.position = new Vector3(6.25f, transform.position.y, 0);       //移動制限（右）
            }
        }
        
        if(Player.dualflg == 2)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += new Vector3(0.1f, 0);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += new Vector3(-0.1f, 0);
            }
            if (transform.position.x < -6.25f)
            {
                transform.position = new Vector3(-6.25f, transform.position.y, 0);  //移動制限（左）
            }
            if (transform.position.x > 5.5f)
            {
                transform.position = new Vector3(5.50f, transform.position.y, 0);   //移動制限（右）
            }
            if (Input.GetKey(KeyCode.Space) && Player.bullet_count <= 3 && bullet_frame2 > 10) //弾数３以上は出ない
            {
                Player.bullet_count++;
                Instantiate(bulletPrefab, new Vector2(transform.position.x - 0.021f, transform.position.y), Quaternion.identity); // プレイヤーの位置に弾を生成します
                bullet_frame2 = 0;
                Bullet.total_bullet+=2;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (Player.dualflg == 2)
        {
            Destroy(this.gameObject);   //自分を消去する

            //Player.Player_zanki--;
            Player.dualflg = 0;
        }
    }
}