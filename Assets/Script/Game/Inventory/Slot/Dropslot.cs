using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Dropslot : MonoBehaviour, IPointerEnterHandler, IDropHandler, IPointerExitHandler
{
    Image image;
    RectTransform rect;
    popupUnit popup;
    public GameObject item;//slot 밑에 있는 녀석//
    EquipmentSlot equipmentSlot;
    // Start is called before the first frame update
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
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        image.color = Color.yellow;
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        image.color = Color.white;
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
            Slot thisSlot = gameObject.GetComponent<Slot>();//떨굴 슬롯
            Slot dragSlot = dragleitem.GetComponent<Slot>();//들고있는 슬롯
            //각 슬롯의 아이템 변경
            item = transform.GetChild(0).gameObject;
            Dropslot dropslot = dragleitem.GetComponent<Dropslot>();
            dropslot.item = dragleitem.transform.GetChild(0).gameObject;
            Inventory.Instance.SwapSlot(thisSlot, dragSlot);
            //아이템 사용
            if (thisSlot.SlotType == SlotType.equipment && dragSlot.SlotType == SlotType.inventory)//인벤토리에서 장비창으로 떨굴때
            {
                //Debug.Log("1:인벤토리에서 장비창으로 떨굴때");
                if (thisSlot.item != null)
                {
                    Slot.Graph[colorType.red].Active(true, thisSlot.index);
                    equipmentSlot.UseItem(thisSlot);
                    //thisSlot.UseItem();
                    //ItemEffect.instance.UseItem(thisSlot.item, 0);
                }
                if (dragSlot.item != null)
                {
                    Slot.Graph[colorType.red].Active(false, thisSlot.index);
                    equipmentSlot.EndItem(dragSlot);
                    //dragSlot.EndItem();
                    //ItemEffect.instance.EndItem(dragSlot.item, 0);
                }
            }
            if (thisSlot.SlotType == SlotType.inventory && dragSlot.SlotType == SlotType.equipment)//장비창에서 인벤토리로 떨굴때
            {
                //Debug.Log("2:장비창에서 인벤토리로 떨굴때");
                if (thisSlot.item != null)
                {
                    //Debug.Log("장비에서 인벤 무공간");
                    //Debug.Log(thisSlot.item.itemName + "" + thisSlot.item.itemType.Length);
                    Slot.Graph[colorType.red].Active(false, dragSlot.index);
                    equipmentSlot.EndItem(thisSlot);
                    //thisSlot.EndItem();
                    //ItemEffect.instance.EndItem(thisSlot.item,0);
                }
                if (dragSlot.item != null)
                {
                    Slot.Graph[colorType.red].Active(true, dragSlot.index);
                    equipmentSlot.UseItem(dragSlot);
                    //dragSlot.UseItem();
                    //ItemEffect.instance.UseItem(dragSlot.item,0);
                }
            }
            if (thisSlot.SlotType == SlotType.equipment && dragSlot.SlotType == SlotType.equipment)//장비창에서 인벤토리로 떨굴때
            {
                if (dragSlot.item == null) Slot.Graph[colorType.red].Active(false, dragSlot.index);
                Slot.Graph[colorType.red].Active(true, thisSlot.index);
                if(thisSlot.item.linkType == linkType.single)equipmentSlot.UseItem(thisSlot);
            }

        }
    }

}
