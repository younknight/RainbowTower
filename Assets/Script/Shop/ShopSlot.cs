using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.U2D;
public class ShopSlot : MonoBehaviour
{
    [SerializeField] SpriteAtlas partsImage;
    [SerializeField] goodsType goodsType;
    [SerializeField] TextMeshProUGUI gold;
    [SerializeField] TextMeshProUGUI paint;
    [SerializeField] Image parts;
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
        gold.text = "" + item.priceGold;
        portrait.sprite = item.sprite;
    }
    public void SetupEquipment(EquipmentPrefap equipment)
    {
        this.equipment = equipment;
        gold.text = "" + equipment.priceGold;
        paint.text = "" + equipment.pricePaint;
        portrait.sprite = equipment.sprite;
        SetImage(equipment.spriteTarget);
    }
    void SetImage(equipment equipment)
    {
        switch (equipment)
        {
            case equipment.rightHand:
                parts.sprite = partsImage.GetSprite("selector");
                break;
            case equipment.leftHand:
                parts.sprite = partsImage.GetSprite("selector");
                parts.transform.localScale = new Vector3(-1f, 1f, 1f);
                break;
            case equipment.body:
                parts.sprite = partsImage.GetSprite("helmat");
                break;
            case equipment.weapon:
                parts.sprite = partsImage.GetSprite("battle");
                break;
        }
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
