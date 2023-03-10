using System.Collections.Generic;
using UnityEngine;
using TMPro;
public enum goodsType
{
    equipment,
    item
}
public class ShopKeeper : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI keepersTalk;
    [SerializeField] Transform itemsParents;
    [SerializeField] Transform equipsParents;
    public ShopSlot[] shopItemSlots;//
    public ShopSlot[] shopEquipSlots;//
    TalkManager talkManager = new TalkManager();
    DataPlayer data;
    List<ItemListPrefap> itemListPrefaps = new List<ItemListPrefap>();

    static List<Item> items = new List<Item>();
    static List<EquipmentPrefap> equipments = new List<EquipmentPrefap>();

    public static List<Item> Items { get => items; set => items = value; }
    public static List<EquipmentPrefap> Equipments { get => equipments; set => equipments = value; }

    void Start()
    {
        data = DataManager.DataPlayer;
        shopItemSlots = itemsParents.GetComponentsInChildren<ShopSlot>();
        shopEquipSlots = equipsParents.GetComponentsInChildren<ShopSlot>();
        //아이템
        itemListPrefaps = Database.instance.ItemPrefap;
        items.RemoveAll(x => true);
        foreach (ItemListPrefap itemListPrefap in itemListPrefaps)
        {
            for(int i=0;i< itemListPrefap.items.Count;i++)
            {
                if (!data.hasItems[itemListPrefap.itemClass][i]) items.Add(itemListPrefap.items[i]);
            }
        }
        //장비
        equipments.RemoveAll(x => true);
        List<EquipmentPrefap> equipmentPrefaps;
        equipmentPrefaps = Database.instance.GetPrefaps(equipment.body);
        for (int i = 0; i < equipmentPrefaps.Count; i++)
        {
            if (!data.hasEquipment[equipment.body].hasEquipment[i]) equipments.Add(equipmentPrefaps[i]);

        }
        equipmentPrefaps = Database.instance.GetPrefaps(equipment.leftHand);
        for (int i = 0; i < equipmentPrefaps.Count; i++)
        {
            if (!data.hasEquipment[equipment.leftHand].hasEquipment[i]) equipments.Add(equipmentPrefaps[i]);

        }
        equipmentPrefaps = Database.instance.GetPrefaps(equipment.rightHand);
        for (int i = 0; i < equipmentPrefaps.Count; i++)
        {
            if (!data.hasEquipment[equipment.rightHand].hasEquipment[i]) equipments.Add(equipmentPrefaps[i]);

        }
        equipmentPrefaps = Database.instance.GetPrefaps(equipment.weapon);
        for (int i = 0; i < equipmentPrefaps.Count; i++)
        {
            if (!data.hasEquipment[equipment.weapon].hasEquipment[i]) equipments.Add(equipmentPrefaps[i]);

        }
        SetItem();
        SetEquip();
    }

    void SetItem()
    {
        List<Item> copyItemList = items;  
        foreach(ShopSlot slot in shopItemSlots)
        {
            if(copyItemList.Count == 0)
            {
                slot.gameObject.SetActive(false);
                continue;
            }
            int itemIndex = Random.Range(0, copyItemList.Count);
            slot.Setup(copyItemList[itemIndex]);
            copyItemList.RemoveAt(itemIndex);
        }
    }
    void SetEquip()
    {
        List<EquipmentPrefap> copyEquipList = equipments;
        foreach (ShopSlot slot in shopEquipSlots)
        {
            if (copyEquipList.Count == 0)
            {
                slot.gameObject.SetActive(false);
                continue;
            }
            int equipIndex = Random.Range(0, copyEquipList.Count);
            slot.SetupEquipment(copyEquipList[equipIndex]);
            copyEquipList.RemoveAt(equipIndex);
        }

    }
    public void ChangeText(int index)
    {
        keepersTalk.text = talkManager.TalkData[index].GetTalk();
    }
}
