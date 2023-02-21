using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDatabase : MonoBehaviour
{
    static List<GameObject> enemyList = new List<GameObject>();
    [SerializeField] EnemyListPrefap thisEnemyList;
    public static List<GameObject> EnemyList { get => enemyList; }

    public void SetEnemyList()
    {
        enemyList.RemoveAll(x => true);
        foreach(GameObject enemy in thisEnemyList.enemyList)
        {
            enemyList.Add(enemy);
        }
    }
}
