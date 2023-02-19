using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
public class SpriteManager : MonoBehaviour
{
    //캐릭터 이미지 초기화 매니저
    Database colorDatabase;
    //캐릭터 선택창 UI
    //이미지
    [SerializeField] equipment[] keys;
    [SerializeField] Image[] values;
    Dictionary<equipment, Image> btnImages = new Dictionary<equipment, Image>();
    Data playerData;
    void Awake()
    {
        if (keys.Length != values.Length) throw new SystemException("keyNum != vlaueNum");
        for (int i = 0; i < keys.Length; i++)
        {
            btnImages.Add(keys[i], values[i]);
        }//사전 초기화
        colorDatabase = Database.instance;//데이터베이스
        playerData = DataManager.Data;
        //이미지 초기화
        EquipmentPrefap prefap;
        foreach (KeyValuePair<equipment, Equipment> entry in playerData.equipment)
        {
            prefap = colorDatabase.GetPrefaps(entry.Key)[entry.Value.currentIndex];
            PlayerManager.ChangeEquipment(entry.Key, prefap);
            btnImages[entry.Key].sprite = prefap.sprite;
        }
    }
}
