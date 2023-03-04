using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PopupInventory : MonoBehaviour
{
    [SerializeField] GameObject contents;//생성될 위치
    [SerializeField] GameObject btnPrefap;//생성할 버튼
    List<ItemSelector> btnList = new List<ItemSelector>();//생성된 버튼 리스트
    List<ItemListPrefap> itemDatabase;
    Data playerData;
    // Start is called before the first frame update
    void Start()
    {
        playerData = DataManager.Data;
        itemDatabase = Database.instance.ItemPrefap;
        InitBtn(itemDatabase);
        gameObject.SetActive(false);
    }
    void InitBtn(List<ItemListPrefap> prefap)//버튼들 초기화하기
    {
        foreach(ItemListPrefap itemListPrefap in prefap)
        {
            foreach(Item item in itemListPrefap.items)
            {
                if(item.level == 0 && playerData.hasItems[item.itemClass][(int)item.colorType])
                {
                    AddBtn(item);
                }
            }
        }
    }
    public void AddBtn(Item item)
    {
        var newBtn = Instantiate<GameObject>(btnPrefap, contents.transform);
        ItemSelector itemSelector = newBtn.GetComponent<ItemSelector>();
        itemSelector.InitalizeButton(item);
        btnList.Add(itemSelector);
    }
    public void ActivatePopup()//껐다 켜기
    {
        colorType color = ButtonManager.SelectedBtn.GetComponent<ButtonManager>().Color;
       // Debug.Log(color);
        foreach(ItemSelector itemSelector in btnList)
        {
            if (itemSelector.Color == color) itemSelector.gameObject.SetActive(true);
            else itemSelector.gameObject.SetActive(false);
        }
    }
}
