using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnitState.state;
public class TextManager : MonoBehaviour
{
    UnitState playerStatus;
    [SerializeField] TextMeshProUGUI[] PlayerText = new TextMeshProUGUI[4];
    [SerializeField] TextMeshProUGUI[] EnemyText = new TextMeshProUGUI[4];

    private void Awake()
    {
        playerStatus = GameObject.FindWithTag("Player").GetComponent<UnitState>();
    }
    void Update()
    {
        PlayerText[0].text = "" + playerStatus.GetStatus(hp);
        PlayerText[1].text = "" + playerStatus.GetStatus(attackDamage);
        PlayerText[2].text = "" + playerStatus.GetStatus(critcalRate)/ 100;
        PlayerText[3].text = "" + (playerStatus.GetStatus(critcalDamage) + 100) / 100;
        if(EnemyManager.enemyList.Count != 0)
        {
            EnemyText[0].text = "" + EnemyManager.enemyList[0].GetStatus(hp);
            EnemyText[1].text = "" + EnemyManager.enemyList[0].GetStatus(attackDamage);
            EnemyText[3].text = "" + TurnManager.instance.Turn;//테스트용
            return;
        }
    }
}
