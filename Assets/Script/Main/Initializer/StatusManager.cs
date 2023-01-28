using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
public class StatusManager: MonoBehaviour
{
    public static StatusManager instance;
    //≈ÿΩ∫∆Æ
    [SerializeField] status[] key;
    [SerializeField] TextMeshProUGUI[] valueText;//text
    [SerializeField] UnitPrefap defaultPrefap;
    Dictionary<status, double> defaultStatus = new Dictionary<status, double>();
    Dictionary<status, TextMeshProUGUI> textList = new Dictionary<status, TextMeshProUGUI>();
    private void Awake()
    {
        if (instance != null) Destroy(gameObject);
        instance = this;
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
        SetStatus();
    }

    public void SetStatus()
    {
        Dictionary<status, double> plusStatus = new Dictionary<status, double>() {
            { status.hp, 0 },
            { status.attackDamage, 0 },
            { status.criticalRate, 0 },
            { status.criticalDamage, 0 },
        };
        foreach (KeyValuePair<equipment, ColorStatusPrefap> entry in PlayerManager.playerStatus)
        {
            plusStatus[status.hp] += entry.Value.hp;
            plusStatus[status.attackDamage] += entry.Value.attackDamage;
            plusStatus[status.criticalRate] += entry.Value.criticalRate;
            plusStatus[status.criticalDamage] += entry.Value.criticalDamage;
        }
        foreach (KeyValuePair<status, TextMeshProUGUI> entry in textList)
        {
            entry.Value.text = "" + (defaultStatus[entry.Key] + plusStatus[entry.Key]);
        }
    }
}
