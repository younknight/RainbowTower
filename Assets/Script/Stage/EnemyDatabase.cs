using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDatabase : MonoBehaviour
{
    static List<GameObject> enemyList = new List<GameObject>();
    [SerializeField] FloorPrefap floorPrefap;
    public static List<GameObject> EnemyList { get => enemyList; }

    public void SetEnemyList()
    {
        enemyList.RemoveAll(x => true);
        foreach(GameObject enemy in floorPrefap.enemyList)
        {
            enemyList.Add(enemy);
        }
    }
}
