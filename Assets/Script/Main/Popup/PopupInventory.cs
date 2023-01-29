using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PopupInventory : MonoBehaviour
{
    [SerializeField] GameObject contents;//������ ��ġ
    [SerializeField] GameObject btnPrefap;//������ ��ư
    [SerializeField] GameObject cancelBtn;//������ ��ư
    List<GameObject> btnList = new List<GameObject>();//������ ��ư ����Ʈ
    Item[] itemDatabase;
    Data playerData;
    // Start is called before the first frame update
    void Start()
    {
        playerData = DataManager.Data;
        itemDatabase = Database.instance.ItemPrefap;
        InitBtn(itemDatabase);
    }
    void InitBtn(Item[] prefap)//��ư�� �ʱ�ȭ�ϱ�
    {
        if (playerData.hasItem.Count != itemDatabase.Length) throw new System.Exception("���ž� ���׳���");
        Instantiate<GameObject>(cancelBtn, contents.transform);
        for (int i = 0; i < playerData.hasItem.Count; i++)
        {
            if (playerData.hasItem[i] > 0)
            {
                var newBtn = Instantiate<GameObject>(btnPrefap, contents.transform);
                btnList.Add(newBtn);
                newBtn.GetComponent<ItemSelector>().InitalizeButton(prefap[i]);
            }
        }
    }
}
