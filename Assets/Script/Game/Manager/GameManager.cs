using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnitState.status;
public class GameManager : MonoBehaviour
{
    UnitState playerStatus;
    IEnumerator coroutine;
    int turn = 0;
    private void Awake()
    {
        Instantiate(PlayerDatabase.Character, transform.position, Quaternion.identity);
    }
    private void Start()
    {
        playerStatus = GameObject.FindWithTag("Player").GetComponent<UnitState>();
        coroutine = Fight();
        StartCoroutine(coroutine);
    }
    IEnumerator Fight()
    {
        while (EnemyManager.EnemyList.Count != 0 && playerStatus.PlayerState != Dead)
        {
            playerStatus.PlayerDamaged(EnemyManager.EnemyList[0].TotalDamage());
            if(playerStatus.PlayerState == Dead)
            {
                Destroy(playerStatus.gameObject);
                GameoverControl.instance.GameOverWithVictory(false);
                break;
            }
            EnemyManager.EnemyList[0].PlayerDamaged(playerStatus.TotalDamage());
            if (EnemyManager.EnemyList[0].PlayerState == Dead)
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
