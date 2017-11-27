using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instansce3 : MonoBehaviour {
    public GameObject[] enemy_4;
    //敵を格納

    //アクティブ最大数
    public int maxEnemy4 = 8;
    public int ene = 1;

    public int enemyCount;
    public int enemytype = 0;

    // Use this for initialization
    void Start()
    {


        //周期的に実行したい場合はコルーチン
        StartCoroutine(Exec());

    }
    //敵を作成する
    IEnumerator Exec()
    {
        yield return new WaitForSeconds(4.0f);
        while (enemyCount < maxEnemy4)
        {
           
            Generate();
            yield return new WaitForSeconds(0.05f);

        }
    }
    void Generate()
    {
        

            //敵を作成する
           
            Instantiate(enemy_4[enemytype]);
            enemytype++;


        
    }
    // Update is called once per frame
    void Update () {
		
	}
}
