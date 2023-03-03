using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Dropslot : MonoBehaviour, IDropHandler
{
    Image image;
    RectTransform rect;
    popupUnit popup;
    public GameObject item;//slot 밑에 있는 녀석//
    EquipmentSlot equipmentSlot;
    Color originColor;
    void Awake()
    {
        image = GetComponent<Image>();
        rect = GetComponent<RectTransform>();
        item = transform.GetChild(0).gameObject;
    }
    void Start()
    {
        equipmentSlot = EquipmentSlot.instance;
    }
    void IDropHandler.OnDrop(PointerEventData eventData)//드랍됬을때
    {
        if (eventData.pointerDrag != null)//들고 있는 녀석
        {
            Transform dragleitem = eventData.pointerDrag.GetComponent<DragedItem>().PreviousParent;//현재 드래그하고 있는 아이템이 있던 슬롯
            //부모 바꿔주기
            item.transform.SetParent(dragleitem);
            eventData.pointerDrag.transform.SetParent(transform);
            //위치를 각 부모에 맞게 변경하기
            item.GetComponent<RectTransform>().position = dragleitem.position;
            eventData.pointerDrag.GetComponent<RectTransform>().position = rect.position;
            //slot 초기화
            Slot thisSlot = gameObject.GetComponent<Slot>();//떨궈지는 슬롯
            Slot dragSlot = dragleitem.GetComponent<Slot>();//들고있는 슬롯
            //각 슬롯의 아이템 변경
            item = transform.GetChild(0).gameObject;
            Dropslot dropslot = dragleitem.GetComponent<Dropslot>();
            dropslot.item = dragleitem.transform.GetChild(0).gameObject;
            Inventory.Instance.SwapSlot(thisSlot, dragSlot);
            //아이템 사용
            if (thisSlot.SlotType == SlotType.equipment && dragSlot.SlotType == SlotType.inventory)//인벤토리에서 장비창으로 떨굴때
            {
                if (dragSlot.item != null)//스왑
                {
                    equipmentSlot.EndItem(dragSlot.item, thisSlot);
                    Slot.Graph[dragSlot.item.colorType].Active(false, thisSlot.index);
                }
                Slot.Graph[thisSlot.item.colorType].Active(true, thisSlot.index);
                thisSlot.SetFrameColor(thisSlot.item.colorType);
                equipmentSlot.UseItem(thisSlot);
            }
            if (thisSlot.SlotType == SlotType.inventory && dragSlot.SlotType == SlotType.equipment)//장비창에서 인벤토리로 떨굴때
            {
                dragSlot.SetFrameColor(colorType.gray);
                equipmentSlot.EndItem(thisSlot.item, dragSlot);
                Slot.Graph[thisSlot.item.colorType].Active(false, dragSlot.index);
                if (dragSlot.item != null)//스왑
                {
                    Slot.Graph[dragSlot.item.colorType].Active(true, dragSlot.index);
                    dragSlot.SetFrameColor(dragSlot.item.colorType);
                    equipmentSlot.UseItem(dragSlot);
                }
            }
            if (thisSlot.SlotType == SlotType.equipment && dragSlot.SlotType == SlotType.equipment)//장비창에서 장비창
            {
                if (dragSlot.item != null)//스왑
                {
                    Slot.Graph[thisSlot.item.colorType].Active(false, dragSlot.index);
                    equipmentSlot.EndItem(thisSlot.item, dragSlot);
                    Slot.Graph[dragSlot.item.colorType].Active(false, thisSlot.index);
                    equipmentSlot.EndItem(dragSlot.item, thisSlot);
                    Slot.Graph[dragSlot.item.colorType].Active(true, dragSlot.index);
                    equipmentSlot.UseItem(dragSlot);
                    Slot.Graph[thisSlot.item.colorType].Active(true, thisSlot.index);
                    equipmentSlot.UseItem(thisSlot);
                    thisSlot.SetFrameColor(thisSlot.item.colorType);
                    dragSlot.SetFrameColor(dragSlot.item.colorType);
                }
                else
                {
                    Slot.Graph[thisSlot.item.colorType].Active(false, dragSlot.index);
                    dragSlot.SetFrameColor(colorType.gray);
                    equipmentSlot.EndItem(thisSlot.item, dragSlot);
                    Slot.Graph[thisSlot.item.colorType].Active(true, thisSlot.index);
                    thisSlot.SetFrameColor(thisSlot.item.colorType);
                    equipmentSlot.UseItem(thisSlot);
                }
            }
        }
    }

}
