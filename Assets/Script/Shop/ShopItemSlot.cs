using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ShopItemSlot : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gold;
    [SerializeField] Image portrait;
    public Item item;//
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
        gold.text = "" + item.itemValue;
        portrait.sprite = item.sprite;
    }

    public void SetPopup()
    {
        popup.TogglePopup();
        popupShop.Setup(this);
    }
}
