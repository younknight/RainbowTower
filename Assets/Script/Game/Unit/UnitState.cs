using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UnitState : MonoBehaviour
{
    [SerializeField] UnitPrefap thisCharacter;
    Dictionary<status, double> currentStatus = new Dictionary<status, double>();
    sangtae playerState;

    public sangtae PlayerState { get => playerState; }
    public UnitPrefap ThisCharacter { get => thisCharacter; }

    private void Awake()
    {
        currentStatus.Add(status.hp, ThisCharacter.hp);
        currentStatus.Add(status.attackDamage, ThisCharacter.attackDamage);
        currentStatus.Add(status.criticalRate, ThisCharacter.critcalRate);
        currentStatus.Add(status.criticalDamage, ThisCharacter.critcalDamage);

    }
    public void InitStatus(Dictionary<spriteType, ColorStatusPrefap> playerStatus)
    {
        foreach(KeyValuePair<spriteType, ColorStatusPrefap> entry in playerStatus)
        {
            currentStatus[status.hp] += entry.Value.hp;
            currentStatus[status.attackDamage] += entry.Value.attackDamage;
            currentStatus[status.criticalRate] += entry.Value.criticalRate;
            currentStatus[status.criticalDamage] += entry.Value.criticalDamage;
        }
    }
    public IEnumerator TemporaryChangeStatus(Item item, bool isBuff)
    {
        ActivatebyItemType(item, isBuff);
        yield return new WaitForSeconds(item.duration);
        ActivatebyItemType(item, !isBuff);
    }
    void ActivatebyItemType(Item item, bool isBuff)
    {
        double status = currentStatus[item.targetState];
        currentStatus[item.targetState] = isBuff ? status + item.value : status - item.value;
    }
    public double GetStatus(status targetStatus)
    {
        return currentStatus[targetStatus];
    }
    public double TotalDamage()
    {
        if (Random.Range(0, 100) <= currentStatus[status.criticalRate])
        {
            return currentStatus[status.attackDamage] * ((currentStatus[status.criticalDamage] + 100) / 100);
        }
        return currentStatus[status.attackDamage];
    }
    public void PlayerDamaged(double value)
    {
        currentStatus[status.hp] -= value;
        if (currentStatus[status.hp] <= 0)
        {
            playerState = sangtae.Dead;
        }
    }

    public void PrintStatus()
    {
        foreach(KeyValuePair<status, double> entry in currentStatus)
        {
            Debug.Log(entry.Key + "/" + entry.Value);
        }
    }
}
