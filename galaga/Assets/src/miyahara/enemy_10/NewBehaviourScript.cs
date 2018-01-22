using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    //敵を格納
   
    public GameObject[] enemy_1;

    public int enemyCount = 0;
   
    //アクティブ最大数
    public int maxEnemy = 4;
 
    public int Speed = 5;
    int a;
    public int n;

    
    // Use this for initialization
    void Start()
    {
        
        //周期的に実行したい場合はコルーチン
        StartCoroutine(Exec());
        //StartCoroutine(kougeki());
    }
    //敵を作成する
    IEnumerator Exec()
    {
        while (enemyCount < maxEnemy)
        {
            yield return new WaitForSeconds(0.1f);
            Generate();
            
           
           
           
        }
        
    }
    IEnumerator kougeki()
    {
       
        Attack();
        yield return new WaitForSeconds(10.0f);

       
    }

    void Generate()
    {
            //敵を作成する
<<<<<<< HEAD
            if (enemytype % 2 == 0)
            {
			Instantiate(enemy_1[enemyCount++]);

            }
            else
            {
			Instantiate(enemy_1[enemytype++]);
            }
            //enemytype++;
=======
          
           
        Instantiate(enemy_1[enemyCount]);
        enemyCount++;
>>>>>>> 3d2a31326eaee95d7d85533b5e4235d9bb07ca94
       
    }
    void Attack()
    {
       /* n = Random.Range(1, 5);
        switch (n)
        {
            case 1:
               
          
        }*/
        

    }
    // Update is called once per frameans
    void Update()
    {
       
    }

}
