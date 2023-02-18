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
    public void InitStatus(Dictionary<equipment, EqujpmentPrefap> playerStatus)
    {
        foreach(KeyValuePair<equipment, EqujpmentPrefap> entry in playerStatus)
        {
            currentStatus[status.hp] += entry.Value.hp;
            currentStatus[status.attackDamage] += entry.Value.attackDamage;
            currentStatus[status.criticalRate] += entry.Value.criticalRate;
            currentStatus[status.criticalDamage] += entry.Value.criticalDamage;
        }
    }
    public void StatusChange(Item item, bool isBuff)
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
                    GameoverControl.instance.GameOverWithVictory(true);
                }
            }
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
