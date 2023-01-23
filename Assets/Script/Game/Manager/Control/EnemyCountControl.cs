using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCountControl : MonoBehaviour
{
    [SerializeField] GameObject GaugePrefab;
    List<GameObject> Gauge = new List<GameObject>();
    public static EnemyCountControl instance;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    void Start()
    {
        for (int i = 0; i < EnemyManager.enemyList.Count; i++)
        {
            GameObject newGauge = Instantiate(GaugePrefab, Vector3.zero, Quaternion.identity, this.transform);
            Gauge.Add(newGauge);
        }
    }
    public void DeleteCount(int count)
    {
        Gauge[count].SetActive(false);
    }
}
