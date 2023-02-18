using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public enum SlotType { inventory, equipment }
public class Slot : MonoBehaviour, IPointerClickHandler
{
    public Item item;
    public Image itemImage;
    public int index;
    [SerializeField] SlotType slotType;
    Popup popup;
    PopupItem popupItem;

    public int Index { get => index; set => index = value; }
    public SlotType SlotType { get => slotType; }

    void Awake()
    {
        GameObject PopupObj = GameObject.Find("PopupItem");
        popup = PopupObj.GetComponent<Popup>();
        popupItem = PopupObj.GetComponent<PopupItem>();
        itemImage = transform.GetChild(0).GetComponent<Image>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (item != null)
            {
                popup.TogglePopup();
                popupItem.Setup(item);
            }
        }
    }
    public void AddItem(Item _item)
    {
        item = _item;
        itemImage.sprite = item.sprite;
        SetColor(1);
    }
    public void ClearSlot()
    {
        item = null;
        itemImage.sprite = null;
        SetColor(0);
    }
    private void SetColor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }
}
