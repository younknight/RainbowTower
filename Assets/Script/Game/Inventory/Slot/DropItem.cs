using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DropItem : MonoBehaviour, IDropHandler
{
    [SerializeField] Sprite defaultItem;
    static DropItem instance;
    EquipmentSlot equipmentSlot;
    SlotManager slotManager;
    public static DropItem Instance { get => instance; set => instance = value; }
    void Awake()
    {
        if (instance == null) instance = this;
    }
    void Start()
    {
        equipmentSlot = EquipmentSlot.instance;
        slotManager = new SlotManager(equipmentSlot);
    }

    void IDropHandler.OnDrop(PointerEventData eventData)//드랍됬을때
    {
        if (eventData.pointerDrag != null)//들고 있는 녀석
        {
            Transform drageditem = eventData.pointerDrag.GetComponent<DragedItem>().PreviousParent;//현재 드래그하고 있는 아이템이 있던 슬롯
            Slot dragSlot = drageditem.GetComponent<Slot>();//들고있는 슬롯

            if (dragSlot.item != null)
            {
                DropSlotInItem(dragSlot);
            }
        }
    }
    public void DropSlotInItem(Slot slot)
    {
        if (slot.SlotType == SlotType.equipment)
        {
            slotManager.ActiveSlot(false, slot, slot);
            //Slot.Graph[slot.item.colorType].Active(false, slot.index);
            //slot.SetFrameColor(colorType.gray);
            //equipmentSlot.EndItem(slot.item, slot);
        }
        Inventory.Instance.GetSp(10);
        slot.item = null;
        slot.itemImage.sprite = null;
        slot.ClearSlot();
    }
}
