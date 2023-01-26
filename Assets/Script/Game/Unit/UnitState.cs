using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UnitState : MonoBehaviour
{
    [SerializeField] UnitPrefap thisCharacter;

    Dictionary<status, double> currentStatus = new Dictionary<status, double>();
    santae playerState;

    public santae PlayerState { get => playerState; }
    public UnitPrefap ThisCharacter { get => thisCharacter; }

    private void Awake()
    {
        currentStatus.Add(status.hp, ThisCharacter.hp);
        currentStatus.Add(status.attackDamage, ThisCharacter.attackDamage);
        currentStatus.Add(status.critcalRate, ThisCharacter.critcalRate);
        currentStatus.Add(status.critcalDamage, ThisCharacter.critcalDamage);

    }
    public IEnumerator ChangeStatus(Item item, bool isBuff)
    {
        activatebyItemType(item, isBuff);
        yield return new WaitForSeconds(item.duration);
        activatebyItemType(item, !isBuff);
    }
    void activatebyItemType(Item item, bool isBuff)
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
        if (Random.Range(0, 100) <= currentStatus[status.critcalRate])
        {
            return currentStatus[status.attackDamage] * ((currentStatus[status.critcalDamage] + 100) / 100);
        }
        return currentStatus[status.attackDamage];
    }
    public void PlayerDamaged(double value)
    {
        currentStatus[status.hp] -= value;
        if (currentStatus[status.hp] <= 0)
        {
            playerState = santae.Dead;
        }
    }
}
