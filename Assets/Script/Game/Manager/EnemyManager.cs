using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    static List<UnitState> enemyList = new List<UnitState>();
    [SerializeField] GameObject defaultEnemy;
    public static List<UnitState> EnemyList { get => enemyList; }

    private void Awake()
    {
        if(EnemyDatabase.EnemyList.Count != 0)
        {

            foreach (GameObject enemyPrefap in EnemyDatabase.EnemyList)
            {
                GameObject enemy = Instantiate(enemyPrefap, this.transform.position, Quaternion.identity);
                enemy.SetActive(false);
                enemyList.Add(enemy.GetComponent<UnitState>());
            }
            enemyList[0].gameObject.SetActive(true);
        }
        else
        {
            GameObject enemy = Instantiate(defaultEnemy, this.transform.position, Quaternion.identity);
            enemyList.Add(enemy.GetComponent<UnitState>());
        }
    }
    private void Update()
    {
        if(enemyList.Count == 0)
        {
            //Time.timeScale = 0;
            GameoverControl.instance.GameOverWithVictory(true);
        }
    }
    public static void RemoveEnemy()//적 제거
    {
        //EnemyCountControl.instance.DeleteCount(EnemyList.Count - 1);
        Destroy(EnemyList[0].gameObject);
        enemyList.RemoveAt(0);
        if(enemyList.Count != 0) enemyList[0].gameObject.SetActive(true);
    }
}
