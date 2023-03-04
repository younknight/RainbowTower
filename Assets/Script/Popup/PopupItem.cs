using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PopupItem : MonoBehaviour
{
    [SerializeField] Popup popup;
    [SerializeField] TextMeshProUGUI itemOfName;
    [SerializeField] TextMeshProUGUI explain;
    [SerializeField] TextMeshProUGUI enforce;
    [SerializeField] TextMeshProUGUI cost;
    [SerializeField] Image portrait;
    Slot slot;
    Item item;
    TextChanger textChanger = new TextChanger(); 
    public Slot Slot { get => slot; set => slot = value; }
    private void Start()
    {
        gameObject.SetActive(false);
    }
    public void Setup(Slot slot)
    {
        this.slot = slot;
        this.item = slot.item;
        itemOfName.text = item.itemName;
        explain.text = textChanger.ExplainChangeInGame(item, slot);
        enforce.text = "" + item.enforce;
        cost.text = "" + item.cost;
        portrait.sprite = item.sprite;
    }
    public void EnforceItem()
    {
        if (Inventory.Instance.Sp >= item.cost)
        {
            if (Random.Range(0, 100) <= item.enforce)//성공
            {
                if (slot.SlotType == SlotType.equipment)
                {
                    for (int index = 0; index < item.itemType.Length; index++)
                    {
                        ItemEffect.instance.EndItem(index, item, slot.LinkedItemNum);
                    }
                    slot.AddItem(item.nextItem);
                    for (int index = 0; index < item.nextItem.itemType.Length; index++)
                    {
                        ItemEffect.instance.UseItem(index, item.nextItem, slot.LinkedItemNum);
                    }
                }
                else slot.AddItem(item.nextItem);
                Setup(slot);
            }
            else//실패
            {
                if (Random.Range(0, 100) <= item.destroyed)//파괴
                {
                    if (slot.SlotType == SlotType.equipment)
                    {
                        Slot.Graph[item.colorType].Active(false, slot.index);
                        for (int index = 0; index < item.itemType.Length; index++)
                        {
                            ItemEffect.instance.EndItem(index, item, slot.LinkedItemNum);
                        }
                    }
                    slot.ClearSlot();
                    popup.ClosePopup();
                }
            }
            Inventory.Instance.GetSp(-(item.cost));
        }
    }
}
