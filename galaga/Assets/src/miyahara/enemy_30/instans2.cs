﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instans2 : MonoBehaviour {
    public GameObject[] enemy_3;
    //敵を格納

    //アクティブ最大数
    public int maxEnemy3 = 8;
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
         yield return new WaitForSeconds(2.0f);
            
        while (enemyCount < maxEnemy3)
        {
          
            
            yield return new WaitForSeconds(0.05f);
            Generate();
        }
    }
    void Generate()
    {
      

            //敵を作成する
           
		Instantiate(enemy_3[enemyCount]);
		enemyCount++;
        
    }
    void Gosa()
    {

    }
    // Update is called once per frame
    void Update () {
		
	}
}
