using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class EnemyCountControl : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    public int totalEnemy;//
    public int currentEnemy;//
    public Slider EnemyCountbar;//
    bool isSetup = false;
    private void Update()
    {
        if (isSetup)
        {
            if ((float)currentEnemy / totalEnemy <= 1)
            {
                EnemyCountbar.value = 1 - ((float)currentEnemy / totalEnemy);
            }
            else
            {
                EnemyCountbar.value = 0f;
            }
            currentEnemy = EnemyManager.EnemyList.Count;
            text.text = "" + currentEnemy + "/" + totalEnemy;
        }
    }
    public void Setup()
    {
        EnemyCountbar = gameObject.GetComponent<Slider>();
        totalEnemy = EnemyManager.EnemyList.Count;
        currentEnemy = totalEnemy;
        isSetup = true;
    }
}
