using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Storage : MonoBehaviour
{
    [SerializeField] SnapScroll scrollRect;
    [SerializeField] Image logo;
    [SerializeField] Sprite equipmentLogo;
    [SerializeField] Sprite itemLogo;
    [SerializeField] Image button;
    [SerializeField] GameObject itemContents;//생성될 위치
    [SerializeField] GameObject itmeBtnPrefap;//생성할 버튼
    [SerializeField] GameObject equipmentContents;//생성될 위치
    [SerializeField] GameObject equipmentBtnPrefap;//생성할 버튼
    List<ItemListPrefap> itemDatabase;
    bool isItem = true;
    Data playerData;
    private void Start()
    {
        playerData = DataManager.Data;
        itemDatabase = Database.instance.ItemPrefap;
        InitItemBtn(itemDatabase);
        InitEquipBtn(Database.instance.GetPrefaps(equipment.body), equipment.body);
        InitEquipBtn(Database.instance.GetPrefaps(equipment.leftHand), equipment.leftHand);
        InitEquipBtn(Database.instance.GetPrefaps(equipment.rightHand), equipment.rightHand);
        InitEquipBtn(Database.instance.GetPrefaps(equipment.weapon), equipment.weapon);
    }
    void InitItemBtn(List<ItemListPrefap> prefap)//버튼들 초기화하기
    {
        foreach (ItemListPrefap itemListPrefap in prefap)
        {
            foreach (Item item in itemListPrefap.items)
            {
                if (item.level == 0 && playerData.hasItems[item.itemClass][(int)item.colorType])
                {
                    AddItemBtn(item);
                }
            }
        }
    }
    public void AddItemBtn(Item item)
    {
        var newBtn = Instantiate<GameObject>(itmeBtnPrefap, itemContents.transform);
        ItemSelector itemSelector = newBtn.GetComponent<ItemSelector>();
        StorageSlot storage = newBtn.GetComponent<StorageSlot>();
        storage.IsItem = true;
        itemSelector.InitalizeButton(item);
    }
    void InitEquipBtn(List<EquipmentPrefap> prefap, equipment equipment)//버튼들 초기화하기
    {
        List<GameObject> btnList = new List<GameObject>();
        for (int i = 0; i < playerData.hasEquipment[equipment].hasEquipment.Count; i++)
        {
            if (playerData.hasEquipment[equipment].hasEquipment[i])
            {
                var newBtn = Instantiate<GameObject>(equipmentBtnPrefap, equipmentContents.transform);
                StorageSlot storage = newBtn.GetComponent<StorageSlot>();
                storage.IsItem = false;
                btnList.Add(newBtn);
                newBtn.GetComponent<EquipmentSelector>().InitalizeButton(prefap[i]);
            }
        }
    }
    public void AddEquipBtn(EquipmentPrefap equipment)
    {
        var newBtn = Instantiate<GameObject>(equipmentBtnPrefap, equipmentContents.transform);
        newBtn.GetComponent<EquipmentSelector>().InitalizeButton(equipment);
    }
    public void Scroll()
    {
        if (isItem)
        {
            scrollRect.NextSnap(0);
            logo.sprite = equipmentLogo;
        }
        else
        {
            logo.sprite = itemLogo;
            scrollRect.PreviousSnap(0);
        }
        Swap();
        isItem = !isItem;
    }
    void Swap()
    {
        Vector3 buttonLocalScale = button.gameObject.transform.localScale;
        buttonLocalScale.y *= -1;
        button.gameObject.transform.localScale = buttonLocalScale;
        Vector3 positionLogo = logo.gameObject.transform.localPosition;
        Vector3 positionbutton = button.gameObject.transform.localPosition;
        positionbutton.x = logo.gameObject.transform.localPosition.x;
        positionbutton.y = logo.gameObject.transform.localPosition.y;
        positionLogo.x = button.gameObject.transform.localPosition.x;
        positionLogo.y = button.gameObject.transform.localPosition.y;
        logo.gameObject.transform.localPosition = positionLogo;
        button.gameObject.transform.localPosition = positionbutton;
    }
}
