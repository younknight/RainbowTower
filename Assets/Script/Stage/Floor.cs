using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Floor : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI floor;
    [SerializeField] EnemyListPrefap enemyListPrefap;
    public TextMeshProUGUI explain;//
    GameObject button;
    private void Awake()
    {
        var setting = GameObject.Find("setting");
        explain = setting.transform.Find("explain").GetChild(0).GetComponent<TextMeshProUGUI>();
        button = setting.transform.Find("GoGame").gameObject;
    }
    public void Setup(int height, EnemyListPrefap enemyListPrefap)
    {
        floor.text = (height + 1) + "F";
        this.enemyListPrefap = enemyListPrefap;
    }
    public void SetStage()
    {
        MapSelector.EnemyList.RemoveAll(x => true);
        foreach (GameObject enemy in enemyListPrefap.enemyList)
        {
            MapSelector.EnemyList.Add(enemy);
        }
        explain.text = enemyListPrefap.explain;
        button.SetActive(true);
    }
}
