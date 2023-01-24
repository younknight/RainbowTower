using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    static List<UnitState> enemyList = new List<UnitState>();

    public static List<UnitState> EnemyList { get => enemyList; }

    private void Awake()
    {
        foreach(GameObject enemyPrefap in EnemyDatabase.EnemyList)
        {
            GameObject enemy = Instantiate(enemyPrefap, this.transform.position, Quaternion.identity);
            enemy.SetActive(false);
            enemyList.Add(enemy.GetComponent<UnitState>());
        }
        enemyList[0].gameObject.SetActive(true);
    }
    public static void RemoveEnemy()//Àû Á¦°Å
    {
        EnemyCountControl.instance.DeleteCount(EnemyList.Count - 1);
        Destroy(EnemyList[0].gameObject);
        enemyList.RemoveAt(0);
        if(enemyList.Count != 0) enemyList[0].gameObject.SetActive(true);
    }
}
