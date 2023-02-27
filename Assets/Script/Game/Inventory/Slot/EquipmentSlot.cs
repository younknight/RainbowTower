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
        usedItemList[colorType.red].Add(itemSlot);
        ItemEffect.instance.UseItem(itemSlot.item, itemSlot.LinkedItemNum);
        ResetItem();
    }
    public void EndItem(Item item, Slot previousSlot)
    {
        Debug.Log(previousSlot.index+"el" + previousSlot.LinkedItemNum);
        ItemEffect.instance.EndItem(item, previousSlot.LinkedItemNum);
        usedItemList[colorType.red].Remove(previousSlot);
        if (Slot.Graph[colorType.red].IsActive(previousSlot.index)) previousSlot.LinkedItemNum = Slot.Graph[colorType.red].BFS(previousSlot.index);
        else previousSlot.LinkedItemNum = 1;
       ResetItem();
    }
    public void ResetItem()
    {
        foreach (KeyValuePair<colorType, List<Slot>> entry in usedItemList)
        {
            foreach (Slot slot in entry.Value)
            {
                Debug.Log("s"+ slot.item.itemName + "/"+ slot.index+ "/"+ slot.LinkedItemNum);
            }
        }
        //제거
        foreach (KeyValuePair<colorType, List<Slot>> entry in usedItemList)
        {
            foreach (Slot slot in entry.Value)
            {
                ItemEffect.instance.EndItem(slot.item, slot.LinkedItemNum);
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
                ItemEffect.instance.UseItem(slot.item, slot.LinkedItemNum);
            }
        }
    }
}
