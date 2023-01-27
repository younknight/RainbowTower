using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
public class InitalizePlayer : MonoBehaviour
{
    ColorDatabase colorDatabase;
    //ĳ���� ����â UI
    [SerializeField] spriteType[] keys;
    [SerializeField] Image[] values;
    Dictionary<spriteType, Image> btnImages = new Dictionary<spriteType, Image>();
    void Start()
    {
        if (keys.Length != values.Length) throw new SystemException("keyNum != vlaueNum");
        for(int i = 0; i < keys.Length; i++)
        {
            btnImages.Add(keys[i], values[i]);
        }//���� �ʱ�ȭ
        colorDatabase = ColorDatabase.instance;//�����ͺ��̽�
        initalPlayer();
    }
    void initalPlayer()//�̹��� �ʱ�ȭ
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
