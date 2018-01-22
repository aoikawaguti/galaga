using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instance_4 : MonoBehaviour {
    //敵を格納
    public GameObject[] enemy_1;

    public int enemyCount;
   
    //アクティブ最大数
    public int maxEnemy = 8;
   

    // Use this for initialization
    void Start () {
        StartCoroutine(Exec());
    }
    IEnumerator Exec()
    {
        yield return new WaitForSeconds(14.0f);
        while (enemyCount < maxEnemy)
        {
            
            Generate();
            yield return new WaitForSeconds(0.09f);
        }
    }

    void Generate()
    {
       

            //敵を作成する
<<<<<<< HEAD
		Instantiate(enemy_1[enemyCount]);
		enemyCount++;
=======
            Instantiate(enemy_1[enemyCount]);
            enemyCount++;
>>>>>>> 3d2a31326eaee95d7d85533b5e4235d9bb07ca94
        
    }
    // Update is called once per frame
    void Update () {
		
	}
}
