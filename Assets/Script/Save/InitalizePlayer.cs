using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
public class InitalizePlayer : MonoBehaviour
{
    ColorDatabase colorDatabase;
    //캐릭터 선택창 UI
    [SerializeField] spriteType[] keys;
    [SerializeField] Image[] values;
    Dictionary<spriteType, Image> btnImages = new Dictionary<spriteType, Image>();
    void Start()
    {
        if (keys.Length != values.Length) throw new SystemException("keyNum != vlaueNum");
        for(int i = 0; i < keys.Length; i++)
        {
            btnImages.Add(keys[i], values[i]);
        }//사전 초기화
        colorDatabase = ColorDatabase.instance;//데이터베이스
        initalPlayer();
    }
    void initalPlayer()//이미지 초기화
    {
        ColorStatusPrefap prefap;
        foreach(KeyValuePair<spriteType, int> entry in DataManager.Data.playerSprites)
        {
            prefap = colorDatabase.GetPrefaps(entry.Key)[entry.Value];
            PlayerManager.ChangeSprite(entry.Key, prefap);
            btnImages[entry.Key].sprite = prefap.sprite;
        }
    }
}
