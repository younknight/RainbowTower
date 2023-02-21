using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponState { SearchTarget = 0, AttackToTarget }
public class UnitWeapon : MonoBehaviour
{
    [SerializeField] GameObject attackPrefap;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float attackRate = 1f;
    WeaponState weaponState = WeaponState.SearchTarget;
    public Transform attackTarget = null;
    UnitState thisUnit;
    bool isPlayer;
    private void Start()
    {
        if (gameObject.CompareTag("Player"))
        {
            isPlayer = true;
            //Debug.Log("player");
        }
        else isPlayer = false;
        thisUnit = GetComponent<UnitState>();
        ChangeState(WeaponState.SearchTarget);
    }
    public void ChangeState(WeaponState newState)
    {
        StopCoroutine(weaponState.ToString());
        weaponState = newState;
        StartCoroutine(weaponState.ToString());
    }
    public IEnumerator SearchTarget()
    {
        if (isPlayer && EnemyManager.EnemyList.Count != 0)
        {
            attackTarget = EnemyManager.EnemyList[0].transform;
        }
        else
        {
            if (!isPlayer && GameObject.FindWithTag("Player") != null)
            {
                attackTarget = GameObject.FindWithTag("Player").GetComponent<UnitState>().transform;
            }
        }
        if(attackTarget != null)
        {
            ChangeState(WeaponState.AttackToTarget);
        }
        yield return null;
    }
    IEnumerator AttackToTarget()
    {
        while (true)
        {
            if(attackTarget == null)
            {
                ChangeState(WeaponState.SearchTarget);
                break;
            }
            SpawnAttackTile();
            yield return new WaitForSeconds(attackRate);
        }
    }
    void SpawnAttackTile()
    {
        GameObject clone = Instantiate(attackPrefap, spawnPoint.position, Quaternion.identity);
        float damage = (float)thisUnit.TotalAttackDamage();
        clone.GetComponent<AttackTile>().Setup(attackTarget, damage , isPlayer);
    }
}
