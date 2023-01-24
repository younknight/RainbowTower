using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewEnemyList", menuName = "NewEnemyList/EnemyList")]
public class EnemyListPrefap : ScriptableObject
{
    public List<GameObject> enemyList = new List<GameObject>();
}
