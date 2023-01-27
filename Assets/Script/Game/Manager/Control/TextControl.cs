using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextControl : MonoBehaviour
{
    UnitState playerStatus;
    [SerializeField] TextMeshProUGUI[] PlayerText = new TextMeshProUGUI[4];
    [SerializeField] TextMeshProUGUI[] EnemyText = new TextMeshProUGUI[4];

    private void Start()
    {
        playerStatus = GameObject.FindWithTag("Player").GetComponent<UnitState>();
    }
    void Update()
    {
        PlayerText[0].text = "" + playerStatus.GetStatus(status.hp);
        PlayerText[1].text = "" + playerStatus.GetStatus(status.attackDamage);
        PlayerText[2].text = "" + playerStatus.GetStatus(status.criticalRate)/ 100;
        PlayerText[3].text = "" + (playerStatus.GetStatus(status.criticalDamage) + 100) / 100;
        if(EnemyManager.EnemyList.Count != 0)
        {
            EnemyText[0].text = "" + EnemyManager.EnemyList[0].GetStatus(status.hp);
            EnemyText[1].text = "" + EnemyManager.EnemyList[0].GetStatus(status.attackDamage);
            return;
        }
    }
}
