using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instans_1 : MonoBehaviour {
   
    public GameObject[] enemy_2;
    //敵を格納
  
   
    //アクティブ最大数
    public int maxEnemy2 = 4;
    
   
    public int enemyCount;
   
   
    // Use this for initialization
    void Start () {

       
        //周期的に実行したい場合はコルーチン
        StartCoroutine(Exec());
       
    }
    //敵を作成する
    IEnumerator Exec()
    {
        while (enemyCount < maxEnemy2)
        {
            yield return new WaitForSeconds(0.1f);
            Generate();
           
        }
    }
    void Generate()
    {
                //敵を作成する
                Instantiate(enemy_2[enemyCount]);
            enemyCount++;
                
    }
   
    
    // Update is called once per frame
    void Update()
    {
       
    }
   
}
