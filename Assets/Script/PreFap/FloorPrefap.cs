using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewFloor", menuName = "NewFloor/Floor")]
public class FloorPrefap : ScriptableObject
{
    public int height;
    public DungeonType dungeonType;
    public List<GameObject> enemyList = new List<GameObject>();
    public Sprite portrait;
    public string explain;
}
