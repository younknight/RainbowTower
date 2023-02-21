using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
public class StatusManager: MonoBehaviour
{
    //캐릭터 스테이터스 초기화 매니저
    static StatusManager instance;
    //텍스트
    [SerializeField] status[] key;
    [SerializeField] TextMeshProUGUI[] valueText;//text
    [SerializeField] UnitPrefap defaultPrefap;
    [SerializeField] Transform inventory;
    ButtonManager[] buttonManagers = new ButtonManager[6];
    Dictionary<status, double> defaultStatus = new Dictionary<status, double>();
    Dictionary<status, TextMeshProUGUI> textList = new Dictionary<status, TextMeshProUGUI>();
    Data playerData;
    Database colorDatabase;

    public static StatusManager Instance { get => instance;  }

    private void Awake()
    {
        if (instance != null) Destroy(gameObject);
        instance = this;
        colorDatabase = Database.instance;//데이터베이스
        playerData = DataManager.Data;
    }
    private void Start()
    {
        if (key.Length != valueText.Length) throw new System.Exception("keyNum != valueNum");
        for(int i = 0; i < key.Length; i++)
        {
            textList.Add(key[i], valueText[i]);
        }
        defaultStatus.Add(status.hp, defaultPrefap.hp);
        defaultStatus.Add(status.attackDamage, defaultPrefap.attackDamage);
        defaultStatus.Add(status.criticalDamage, defaultPrefap.criticalDamage);
        defaultStatus.Add(status.criticalRate, defaultPrefap.criticalRate);
        defaultStatus.Add(status.defence, defaultPrefap.defence);
        SetStatus();
        buttonManagers = inventory.GetComponentsInChildren<ButtonManager>();
        int index = 0;
        //Debug.Log(PlayerManager.PlayerItem.Count);
        foreach (Item item in PlayerManager.PlayerItem)
        {
           // Debug.Log(buttonManagers[index].gameObject.name + "  " + item.name);
            buttonManagers[index].item = item;
            index++;
        }
    }

    public void SetStatus()
    {
        Dictionary<status, double> plusStatus = new Dictionary<status, double>() {
            { status.hp, 0 },
            { status.attackDamage, 0 },
            { status.criticalRate, 0 },
            { status.criticalDamage, 0 },
            { status.defence, 0 },
        };
        foreach (KeyValuePair<equipment, EquipmentPrefap> entry in PlayerManager.PlayerStatus)
        {
            plusStatus[status.hp] += entry.Value.hp;
            plusStatus[status.attackDamage] += entry.Value.attackDamage;
            plusStatus[status.criticalRate] += entry.Value.criticalRate;
            plusStatus[status.criticalDamage] += entry.Value.criticalDamage;
            plusStatus[status.defence] += entry.Value.defence;
        }
        foreach (KeyValuePair<status, TextMeshProUGUI> entry in textList)
        {
            entry.Value.text = "" + (defaultStatus[entry.Key] + plusStatus[entry.Key]);
        }
        int index = 0;
        PlayerManager.PlayerItem.RemoveAll(x=>true);
        foreach(int itemClass in playerData.itemIndex)
        {
            ItemListPrefap find = colorDatabase.ItemPrefap.Find(x => x.index == itemClass);
            PlayerManager.PlayerItem.Add(find.items[index]);
            index++;
        }
    }
}
