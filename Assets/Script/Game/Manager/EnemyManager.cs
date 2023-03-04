using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    static List<UnitState> enemyList = new List<UnitState>();
    public static EnemyManager instance;
    [SerializeField] GameObject defaultEnemy;
    [SerializeField] GameObject enemyHpSlider;
    HpControl enemyHp;
    FloorPrefap floorPrefap;
    public static List<UnitState> EnemyList { get => enemyList; }
    public FloorPrefap FloorPrefap { get => floorPrefap; }

    //public static EnemyManager Instance => instance;

    private void Awake()
    {
        if (instance == null) instance = this;
        if (MapSelector.FloorPrefap != null)
        {
            floorPrefap = MapSelector.FloorPrefap;
            enemyList.RemoveAll(x => true);
            foreach (GameObject enemyPrefap in floorPrefap.enemyList)
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
    private void Start()
    {
        enemyHp = enemyHpSlider.GetComponent<HpControl>();
        enemyHp.Setup(enemyList[0].GetComponent<UnitState>());
    }
    public void RemoveEnemy()//적 제거
    {
        //드랍
        Inventory.Instance.GetSp(enemyList[0].ThisCharacter.dropSpRate);
        DataManager.instance.AddGold(enemyList[0].ThisCharacter.dropGold);
        //제거
        Destroy(enemyList[0].gameObject);
        enemyList.RemoveAt(0);
        if (enemyList.Count != 0)
        {
            enemyList[0].gameObject.SetActive(true);
            enemyHp.Setup(enemyList[0].GetComponent<UnitState>());
        }
    }
}
