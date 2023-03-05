using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class UnitState : MonoBehaviour
{
    [SerializeField] UnitPrefap thisCharacter;
    Popup popup;
    popupUnit popupUnit;
    Dictionary<status, double> currentStatus = new Dictionary<status, double>();
    sangtae playerState;
    public sangtae PlayerState { get => playerState; }
    public UnitPrefap ThisCharacter { get => thisCharacter; }
    public Dictionary<status, double> CurrentStatus => currentStatus;
    private void Awake()
    {
        currentStatus.Add(status.hp, ThisCharacter.hp);
        currentStatus.Add(status.attackDamage, ThisCharacter.attackDamage);
        currentStatus.Add(status.criticalRate, ThisCharacter.criticalRate);
        currentStatus.Add(status.criticalDamage, ThisCharacter.criticalDamage);
        currentStatus.Add(status.defence, ThisCharacter.defence);
        GameObject PopupObj = GameObject.Find("PopupUnit");//팝업
        popup = PopupObj.GetComponent<Popup>();
        popupUnit = PopupObj.GetComponent<popupUnit>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.transform.gameObject == gameObject)
                {
                    popup.TogglePopup();
                    popupUnit.Setup(this);
                }
            }
        }
    }
    public void InitStatus(Dictionary<equipment, EquipmentPrefap> playerStatus)
    {
        foreach(KeyValuePair<equipment, EquipmentPrefap> entry in playerStatus)
        {
            currentStatus[status.hp] += entry.Value.hp;
            currentStatus[status.attackDamage] += entry.Value.attackDamage;
            currentStatus[status.criticalRate] += entry.Value.criticalRate;
            currentStatus[status.criticalDamage] += entry.Value.criticalDamage;
            currentStatus[status.defence] += entry.Value.defence;
        }
    }
    public void StatusChange(status targrtStatus, float value, bool isBuff)
    {
        double status = currentStatus[targrtStatus];
        currentStatus[targrtStatus] = isBuff ? status + value : status - value;
    }
    public double GetStatus(status targetStatus)
    {
        return currentStatus[targetStatus];
    }
    public double TotalAttackDamage()
    {
        if (Random.Range(0, 100) <= currentStatus[status.criticalRate])
        {
            return currentStatus[status.attackDamage] * ((currentStatus[status.criticalDamage] + 100) / 100);
        }
        return currentStatus[status.attackDamage];
    }
    public void PlayerDamaged(double value)
    {
        if(value - currentStatus[status.defence] > 0)
        {
            currentStatus[status.hp] -= value - currentStatus[status.defence];
        }
        else
        {
            currentStatus[status.hp] -= 1;
        }
        if (currentStatus[status.hp] <= 0)
        {
            playerState = sangtae.Dead;
            //Debug.Log(gameObject.tag);
            if (gameObject.CompareTag("Player"))
            {
                //Time.timeScale = 0;
                if (EnemyManager.EnemyList.Count != 0)
                {
                    Debug.Log("패배");
                    GameoverControl.instance.GameOverWithVictory(false);
                    Destroy(gameObject);
                    return;
                }
            }
            else if (gameObject.CompareTag("Enemy"))
            {
                if(EnemyManager.EnemyList.Count > 0)
                {
                    EnemyManager.instance.RemoveEnemy();
                }
                if (EnemyManager.EnemyList.Count == 0)
                {
                    Debug.Log("승리");
                }
            }
        }
    }
    public void Heal(float value)
    {
       // Debug.Log("Healed");
        currentStatus[status.hp] += value;
    }
    public void PrintStatus()
    {
        foreach(KeyValuePair<status, double> entry in currentStatus)
        {
            Debug.Log(entry.Key + "/" + entry.Value);
        }
    }
}
