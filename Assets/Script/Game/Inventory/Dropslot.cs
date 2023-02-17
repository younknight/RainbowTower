using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Dropslot : MonoBehaviour, IPointerEnterHandler, IDropHandler, IPointerExitHandler
{
    Image image;
    RectTransform rect;
    public GameObject item;//slot 밑에 있는 녀석
    // Start is called before the first frame update
    void Awake()
    {
        image = GetComponent<Image>();
        rect = GetComponent<RectTransform>();
        item = transform.GetChild(0).gameObject;
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
        if(eventData.pointerDrag != null)//들고 있는 녀석
        {
            Transform dragleitem = eventData.pointerDrag.GetComponent<Dragleitem>().PreviousParent;//현재 드래그하고 있는 아이템이 있던 슬롯
            //부모 바꿔주기
            item.transform.SetParent(dragleitem);
            eventData.pointerDrag.transform.SetParent(transform);
            //위치를 각 부모에 맞게 변경하기
            item.GetComponent<RectTransform>().position = dragleitem.position;
            eventData.pointerDrag.GetComponent<RectTransform>().position = rect.position;
            //slots 인덱스 스왑
            Inventory.Instance.SwapSlot(gameObject.GetComponent<Slot>(), dragleitem.GetComponent<Slot>());
            //각 슬롯의 아이템 변경
            item = transform.GetChild(0).gameObject;
            Dropslot dropslot = dragleitem.GetComponent<Dropslot>();
            dropslot.item = dragleitem.transform.GetChild(0).gameObject;
        }
    }

}
