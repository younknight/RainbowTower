using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
public class SpriteManager : MonoBehaviour
{
    Database colorDatabase;
    //ĳ���� ����â UI
    //�̹���
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
        }//���� �ʱ�ȭ
        colorDatabase = Database.instance;//�����ͺ��̽�
        playerData = DataManager.Data;
        //�̹��� �ʱ�ȭ
        ColorStatusPrefap prefap;
        foreach (KeyValuePair<equipment, Equipment> entry in playerData.equipment)
        {
            prefap = colorDatabase.GetPrefaps(entry.Key)[entry.Value.currentIndex];
            PlayerManager.ChangeSprite(entry.Key, prefap);
            btnImages[entry.Key].sprite = prefap.sprite;
        }
    }
}
