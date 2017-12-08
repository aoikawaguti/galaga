using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    //敵を格納
    public GameObject[] enemy_1;
    
    public int enemyCount;
    public int enemytype = 0;
    //アクティブ最大数
    public int maxEnemy = 4;
    public int ene = 1;
    public int Speed = 5;
    int a;

    // Use this for initialization
    void Start()
    {
        
        //周期的に実行したい場合はコルーチン
        StartCoroutine(Exec());
        StartCoroutine(kougeki());
    }
    //敵を作成する
    IEnumerator Exec()
    {
        while (enemyCount < maxEnemy)
        {
            Generate();
            yield return new WaitForSeconds(0.1f);//0.05
            Attack();
            //yield return new WaitForSeconds(8.0f);
           
        }
        
    }
    IEnumerator kougeki()
    {
       
        Attack();
        yield return null;

    }

    void Generate()
    {
       

            //敵を作成する
            if (enemytype % 2 == 0)
            {
			Instantiate(enemy_1[enemyCount++]);

            }
            else
            {
			Instantiate(enemy_1[enemytype++]);
            }
            //enemytype++;
       
    }
    void Attack()
    {
        
        a = (int)(Time.time % 2);
        if (a == 0) transform.Translate(new Vector3(0.1f, 0f, 0) * Time.deltaTime * Speed);
        else transform.Translate(new Vector3(-0.1f, 0f, 0) * Time.deltaTime * Speed);

    }
    // Update is called once per frameans
    void Update()
    {
        
    }

}
