using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    UnitState playerStatus;
    Inventory playerInventory;
    IEnumerator coroutine;
    int turn = 0;
    int test;
    private void Start()
    {
        playerStatus = GameObject.FindWithTag("Player").GetComponent<UnitState>();
        playerInventory = Inventory.Instance;
        StartFight();
    }
    public void StartFight()
    {
        turn++;
        coroutine = Fight();
        StartCoroutine(coroutine);
    }
    IEnumerator Fight()
    {
        Debug.Log(EnemyManager.EnemyList.Count);
        Debug.Log(playerStatus.PlayerState);
        while (EnemyManager.EnemyList.Count != 0 && playerStatus.PlayerState != sangtae.Dead)
        {
            //playerStatus.PlayerDamaged(EnemyManager.EnemyList[0].TotalDamage());
            if(playerStatus.PlayerState == sangtae.Dead)
            {
                Debug.Log("패배");
                Destroy(playerStatus.gameObject);
                GameoverControl.instance.GameOverWithVictory(false);
                break;
            }
            // EnemyManager.EnemyList[0].PlayerDamaged(playerStatus.TotalDamage());

            if (EnemyManager.EnemyList[0].PlayerState == sangtae.Dead)
            {
                EnemyManager.RemoveEnemy();
                if(EnemyManager.EnemyList.Count == 0)
                {
                    Debug.Log("승리");
                    GameoverControl.instance.GameOverWithVictory(true);
                }
                break;
            }
            //playerInventory.Sp += turn + 1;
            yield return new WaitForSeconds(1f);
        }
        StopCoroutine(coroutine);
    }
}
