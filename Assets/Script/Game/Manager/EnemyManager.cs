using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] enemyListPrefap;
    public static List<UnitState> enemyList = new List<UnitState>();
    private void Awake()
    {
        for (int i = 0; i < enemyListPrefap.Length; i++)
        {
            GameObject enemy = Instantiate(enemyListPrefap[i], this.transform.position, Quaternion.identity);
            enemyList.Add(enemy.GetComponent<UnitState>());
            if(i != 0)
            {
                enemy.SetActive(false);
            }
        }
    }
    public static void RemoveEnemy()
    {
        EnemyCountControl.instance.DeleteCount(enemyList.Count - 1);
        Destroy(enemyList[0].gameObject);
        enemyList.RemoveAt(0);
        if(enemyList.Count != 0) enemyList[0].gameObject.SetActive(true);
        
    }
}
