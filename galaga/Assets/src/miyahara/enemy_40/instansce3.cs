﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instansce3 : MonoBehaviour {
    public GameObject[] enemy_4;
    //敵を格納

    //アクティブ最大数
    public int maxEnemy4 = 8;
  
    public int enemyCount;
   

    // Use this for initialization
    void Start()
    {


        //周期的に実行したい場合はコルーチン
        StartCoroutine(Exec());

    }
    //敵を作成する
    IEnumerator Exec()
    {
        yield return new WaitForSeconds(9.0f);
        while (enemyCount < maxEnemy4)
        {
           
            Generate();
            yield return new WaitForSeconds(0.18f);

        }
    }
    void Generate()
    {
        

            //敵を作成する
           
<<<<<<< HEAD
		Instantiate(enemy_4[enemyCount]);
			enemyCount++;
=======
            Instantiate(enemy_4[enemyCount]);
            enemyCount++;
>>>>>>> 3d2a31326eaee95d7d85533b5e4235d9bb07ca94


        
    }
    // Update is called once per frame
    void Update () {
		
	}
}
