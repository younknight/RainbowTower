using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnitState.status;
public class TurnManager : MonoBehaviour
{
    public static TurnManager instance;
    UnitState playerStatus;
    IEnumerator coroutine;
    int turn = 0;

    public int Turn { get => turn; set => turn = value; }

    private void Awake()
    {
        if (instance == null) instance = this;
        playerStatus = GameObject.FindWithTag("Player").GetComponent<UnitState>();
    }
    private void Start()
    {
        coroutine = Fight();
        StartCoroutine(coroutine);
    }
    IEnumerator Fight()
    {
        while (EnemyManager.enemyList.Count != 0 && playerStatus.PlayerState != Dead)
        {
            playerStatus.PlayerDamaged(EnemyManager.enemyList[0].TotalDamage());
            if(playerStatus.PlayerState == UnitState.status.Dead)
            {
                Destroy(playerStatus.gameObject);
                GameOverManager.instance.GameOverWithVictory(false);
                break;
            }
            EnemyManager.enemyList[0].PlayerDamaged(playerStatus.TotalDamage());
            if (EnemyManager.enemyList[0].PlayerState == UnitState.status.Dead)
            {
                EnemyManager.RemoveEnemy();
                if(EnemyManager.enemyList.Count == 0)
                {
                    GameOverManager.instance.GameOverWithVictory(true);
                    break;
                }
            }
            Turn++;
            yield return new WaitForSeconds(1f);
        }
        StopCoroutine(coroutine);
    }
}
