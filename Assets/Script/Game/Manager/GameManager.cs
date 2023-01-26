using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    UnitState playerStatus;
    IEnumerator coroutine;
    int turn = 0;
    private void Start()
    {
        playerStatus = GameObject.FindWithTag("Player").GetComponent<UnitState>();
        coroutine = Fight();
        StartCoroutine(coroutine);
    }
    IEnumerator Fight()
    {
        while (EnemyManager.EnemyList.Count != 0 && playerStatus.PlayerState != santae.Dead)
        {
            playerStatus.PlayerDamaged(EnemyManager.EnemyList[0].TotalDamage());
            if(playerStatus.PlayerState == santae.Dead)
            {
                Destroy(playerStatus.gameObject);
                GameoverControl.instance.GameOverWithVictory(false);
                break;
            }
            EnemyManager.EnemyList[0].PlayerDamaged(playerStatus.TotalDamage());
            if (EnemyManager.EnemyList[0].PlayerState == santae.Dead)
            {
                EnemyManager.RemoveEnemy();
                if(EnemyManager.EnemyList.Count == 0)
                {
                    GameoverControl.instance.GameOverWithVictory(true);
                    break;
                }
            }
            turn++;
            yield return new WaitForSeconds(1f);
        }
        StopCoroutine(coroutine);
    }
}
