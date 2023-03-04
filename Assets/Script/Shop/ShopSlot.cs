using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ShopSlot : MonoBehaviour
{
    [SerializeField] goodsType goodsType;
    [SerializeField] TextMeshProUGUI gold;
    [SerializeField] TextMeshProUGUI parts;
    [SerializeField] Image portrait;
    public Item item;//
    public EquipmentPrefap equipment;//
    Popup popup;
    PopupShop popupShop;
    private void Awake()
    {
        popup = GameObject.Find("Popup").GetComponent<Popup>();
        popupShop = GameObject.Find("Popup").GetComponent<PopupShop>();
    }
    public void Setup(Item item)
    {
        this.item = item;
        gold.text = "" + item.price;
        portrait.sprite = item.sprite;
    }
    public void SetupEquipment(EquipmentPrefap equipment)
    {
        this.equipment = equipment;
        gold.text = "" + equipment.price;
        parts.text = "" + equipment.spriteTarget.ToString();
        portrait.sprite = equipment.sprite;
    }
    public void Close()
    {
        gameObject.GetComponent<Button>().interactable = false;
    }
    public void SetPopup()
    {
        popup.TogglePopup();
        if (goodsType == goodsType.item) popupShop.SetupItem(this);
        if (goodsType == goodsType.equipment) popupShop.SetupEquip(this);
    }
}
