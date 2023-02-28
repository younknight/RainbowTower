using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//public class UsedItem
//{
//    public Item item;
//    public int link;
//    public int index;

//    public UsedItem(Slot slot)
//    {
//        this.item = slot.item;
//        slot.LinkedItemNum = Slot.Graph[colorType.red].BFS(slot.index);
//        this.link = slot.LinkedItemNum;
//        this.index = slot.index;
//    }
//}
public class EquipmentSlot : MonoBehaviour
{
    [SerializeField] GameObject SlotsParent;
    public Slot[] slots = new Slot[16];//
    public static EquipmentSlot instance;

    Dictionary<colorType, List<Slot>> usedItemList = new Dictionary<colorType, List<Slot>>();

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    void Start()
    {
        slots = SlotsParent.GetComponentsInChildren<Slot>();
        for (int i = 0; i < SlotsParent.transform.childCount; i++)
        {
            slots[i].Index = i;
        }
        usedItemList.Add(colorType.red, new List<Slot>());
        usedItemList.Add(colorType.orange, new List<Slot>());
        usedItemList.Add(colorType.yellow, new List<Slot>());
        usedItemList.Add(colorType.green, new List<Slot>());
        usedItemList.Add(colorType.blue, new List<Slot>());
        usedItemList.Add(colorType.purple, new List<Slot>());
    }
    public void Test()
    {
        Debug.Log("test:");
        foreach(Slot slot in slots)
        {
            Debug.Log(slot.index+"/"+slot.LinkedItemNum);
        }
    }
    public void UseItem(Slot itemSlot)
    {
        usedItemList[itemSlot.item.colorType].Add(itemSlot);
        for (int index = 0; index < itemSlot.item.itemType.Length; index++)
        {
            ItemEffect.instance.UseItem(index, itemSlot.item, itemSlot.LinkedItemNum);
        }
        ResetItem();
    }
    public void EndItem(Item item, Slot previousSlot)
    {
        for (int index = 0; index < item.itemType.Length; index++)
        {
            ItemEffect.instance.EndItem(index, item, previousSlot.LinkedItemNum);
        }
        usedItemList[item.colorType].Remove(previousSlot);//아마 여기
        if (Slot.Graph[item.colorType].IsActive(previousSlot.index)) previousSlot.LinkedItemNum = Slot.Graph[item.colorType].BFS(previousSlot.index);
        else previousSlot.LinkedItemNum = 1;
        ResetItem();
    }
    public void ResetItem()
    {
        //제거
        foreach (KeyValuePair<colorType, List<Slot>> entry in usedItemList)
        {
            foreach (Slot slot in entry.Value)
            {
                for (int index = 0; index < slot.item.itemType.Length; index++)
                {
                    if (slot.item.itemType[index] != ItemType.Heal) ItemEffect.instance.EndItem(index, slot.item, slot.LinkedItemNum);
                }
            }
        }
        //정리
        foreach (KeyValuePair<colorType, List<Slot>> entry in usedItemList)
        {
            foreach (Slot slot in entry.Value)
            {
                slot.LinkedItemNum = Slot.Graph[entry.Key].BFS(slot.index);
            }
        }
        //사용
        foreach (KeyValuePair<colorType, List<Slot>> entry in usedItemList)
        {
            foreach (Slot slot in entry.Value)
            {
                for (int index = 0; index < slot.item.itemType.Length; index++)
                {
                    if (slot.item.itemType[index] != ItemType.Heal) ItemEffect.instance.UseItem(index, slot.item, slot.LinkedItemNum);
                }
            }
        }
    }
}
