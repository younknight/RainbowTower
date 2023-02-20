using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DropItem : MonoBehaviour, IDropHandler
{
    [SerializeField] Sprite defaultItem;
    void IDropHandler.OnDrop(PointerEventData eventData)//드랍됬을때
    {
        if (eventData.pointerDrag != null)//들고 있는 녀석
        {
            Transform drageditem = eventData.pointerDrag.GetComponent<DragedItem>().PreviousParent;//현재 드래그하고 있는 아이템이 있던 슬롯
            Slot dragSlot = drageditem.GetComponent<Slot>();//들고있는 슬롯

            if (dragSlot.item != null)
            {
                Inventory.Instance.GetSp(10);
                dragSlot.item = null;
                dragSlot.itemImage.sprite = defaultItem;
                dragSlot.ClearSlot();
            }
        }
    }
}
