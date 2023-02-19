using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PopupInventory : MonoBehaviour
{
    [SerializeField] GameObject contents;//생성될 위치
    [SerializeField] GameObject btnPrefap;//생성할 버튼
    [SerializeField] GameObject cancelBtn;//생성할 버튼
    List<GameObject> btnList = new List<GameObject>();//생성된 버튼 리스트
    List<ItemListPrefap> itemDatabase;
    Data playerData;
    // Start is called before the first frame update
    void Start()
    {
        playerData = DataManager.Data;
        itemDatabase = Database.instance.ItemPrefap;
        InitBtn(itemDatabase);
    }
    void InitBtn(List<ItemListPrefap> prefap)//버튼들 초기화하기
    {
        Instantiate<GameObject>(cancelBtn, contents.transform);
        foreach(ItemListPrefap itemListPrefap in prefap)
        {
            foreach(Item item in itemListPrefap.items)
            {
                if(item.level == 0)
                {
                    var newBtn = Instantiate<GameObject>(btnPrefap, contents.transform);
                    btnList.Add(newBtn);
                    newBtn.GetComponent<ItemSelector>().InitalizeButton(item);

                }
            }
        }
        //for (int i = 0; i < playerData.hasItem.Count; i++)
        //{
        //    if (playerData.hasItem[i] > 0)
        //    {
        //        var newBtn = Instantiate<GameObject>(btnPrefap, contents.transform);
        //        btnList.Add(newBtn);
        //        newBtn.GetComponent<ItemSelector>().InitalizeButton(prefap[i]);
        //    }
        //}
    }
}
