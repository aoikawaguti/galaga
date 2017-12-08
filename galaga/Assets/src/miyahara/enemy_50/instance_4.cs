using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instance_4 : MonoBehaviour {
    //敵を格納
    public GameObject[] enemy_1;

    public int enemyCount;
    public int enemytype = 0;
    //アクティブ最大数
    public int maxEnemy = 8;
    public int ene = 1;

    // Use this for initialization
    void Start () {
        StartCoroutine(Exec());
    }
    IEnumerator Exec()
    {
        yield return new WaitForSeconds(6.0f);
        while (enemyCount < maxEnemy)
        {
            
            Generate();
            yield return new WaitForSeconds(0.05f);
        }
    }

    void Generate()
    {
       

            //敵を作成する
		Instantiate(enemy_1[enemyCount]);
		enemyCount++;
        
    }
    // Update is called once per frame
    void Update () {
		
	}
}
