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
    [SerializeField] List<Image> itemImage;
    Dictionary<equipment, Image> btnImages = new Dictionary<equipment, Image>();
    DataPlayer playerData;
    void Start()
    {
        if (keys.Length != values.Length) throw new SystemException("keyNum != vlaueNum");
        for (int i = 0; i < keys.Length; i++)
        {
            btnImages.Add(keys[i], values[i]);
        }//사전 초기화
        colorDatabase = Database.instance;//데이터베이스
        playerData = DataManager.DataPlayer;
        //이미지 초기화
        EquipmentPrefap prefap;
        foreach (KeyValuePair<equipment, Equipment> entry in playerData.hasEquipment)
        {
            prefap = colorDatabase.GetPrefaps(entry.Key)[entry.Value.currentIndex];
            PlayerManager.ChangeEquipment(entry.Key, prefap);
            btnImages[entry.Key].sprite = prefap.sprite;
        }
        int index = 0;
        foreach (int itemClass in playerData.itemIndex)
        {
            ItemListPrefap find = colorDatabase.ItemPrefap.Find(x => x.index == itemClass);
            itemImage[index].sprite = find.items[index].sprite;
            index++;
        }
    }
}