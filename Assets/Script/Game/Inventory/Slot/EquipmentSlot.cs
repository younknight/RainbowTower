using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EquipmentSlot : MonoBehaviour
{
    [SerializeField] GameObject SlotsParent;
    public Slot[] slots = new Slot[16];//
    public static EquipmentSlot instance;

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
    }
    public void UseItem(Slot slot)
    {
        if (slot.item.linkType == linkType.single)
        {
            slot.LinkedItemNum = Slot.Graph[colorType.red].BFS(slot.index);

            ItemEffect.instance.UseItem(slot.item, slot.LinkedItemNum);
            ResetItem();
            return;
        }
        ItemEffect.instance.UseItem(slot.item, 0);
    }
    void UseLinkedItem(Slot slot)
    {
       // Debug.Log(slot.item.itemName +"index = " + slot.index);
        slot.LinkedItemNum = Slot.Graph[colorType.red].BFS(slot.index);

        ItemEffect.instance.UseItem(slot.item, slot.LinkedItemNum);
    }
    void EndLinkedItem(Slot slot)
    {
        ItemEffect.instance.EndItem(slot.item, slot.LinkedItemNum);
    }
    private void ResetItem()
    {
        List<bool> isActive = new List<bool>();
        isActive = Slot.Graph[colorType.red].IsActive();
        for (int i = 0; i < isActive.Count; i++)
        {
            if (isActive[i])
            {
                EndLinkedItem(slots[i]);
            }
        }
        for (int i = 0; i < isActive.Count; i++)
        {
            if (isActive[i])
            {
                UseLinkedItem(slots[i]);
            }
        }
    }
    public void EndItem(Slot slot)
    {
        int plus = 0;
        if (slot.item.linkType == linkType.single)
        {
            if (slot.LinkedItemNum != 1) plus = 1;
            Debug.Log("P:" + plus);
            ItemEffect.instance.EndItem(slot.item, slot.LinkedItemNum + plus);

            ResetItem();

            return;
        }
        ItemEffect.instance.EndItem(slot.item, 0);
    }
}
