using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PopupSelectMap : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI towerName;
    [SerializeField] TextMeshProUGUI explain;
    [SerializeField] Transform floorFarent;
    [SerializeField] GameObject gameStart;
    [SerializeField] List<EnemyListPrefap> thisEnemyList;
    public int height;
    Floor[] floors;
    // Start is called before the first frame update
    void Start()
    {
        floors = floorFarent.transform.GetComponentsInChildren<Floor>();
        gameObject.SetActive(false);
    }
    public void Setup(List<EnemyListPrefap> enemyListPrefaps, string name)
    {
        thisEnemyList = enemyListPrefaps;
        height = thisEnemyList.Count;
        for (int i = 0; i < floors.Length; i++)
        {
            floors[i].gameObject.SetActive(false);
            if (i < height)
            {
                floors[i].gameObject.SetActive(true);
                floors[i].Setup(i, enemyListPrefaps[i]);
            }
        }
        gameStart.SetActive(false);
        towerName.text = name;
        explain.text = "";
    }
}
