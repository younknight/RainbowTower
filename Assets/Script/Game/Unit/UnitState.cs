using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnitState.state;
public class UnitState : MonoBehaviour
{
    [SerializeField] UnitPrefap thisCharacter;
    public enum status {
        None,
        Dead,
        Sleep
    }
    public enum state
    {
        hp,
        attackDamage,
        magic,
        critcalRate,
        critcalDamage
    }
    Dictionary<state, double> currentStatus = new Dictionary<state, double>();
    status playerState;

    public status PlayerState { get => playerState; }
    public UnitPrefap ThisCharacter { get => thisCharacter; }

    private void Awake()
    {
        currentStatus.Add(hp, ThisCharacter.hp);
        currentStatus.Add(attackDamage, ThisCharacter.attackDamage);
        currentStatus.Add(critcalRate, ThisCharacter.critcalRate);
        currentStatus.Add(critcalDamage, ThisCharacter.critcalDamage);

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
    public double GetStatus(state targetStatus)
    {
        return currentStatus[targetStatus];
    }
    public double TotalDamage()
    {
        if (Random.Range(0, 100) <= currentStatus[critcalRate])
        {
            return currentStatus[attackDamage] * ((currentStatus[critcalDamage] + 100) / 100);
        }
        return currentStatus[attackDamage];
    }
    public void PlayerDamaged(double value)
    {
        currentStatus[hp] -= value;
        if (currentStatus[hp] <= 0)
        {
            playerState = status.Dead;
        }
    }
}
