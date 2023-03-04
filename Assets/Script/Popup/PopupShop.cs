using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PopupShop : MonoBehaviour
{
    [SerializeField] ShopKeeper shopKeeper;
    [SerializeField] TextMeshProUGUI itemName;
    [SerializeField] TextMeshProUGUI gold;
    [SerializeField] TextMeshProUGUI explain;
    [SerializeField] Image portrait;
    [SerializeField] GameObject purItem;
    [SerializeField] GameObject purEquip;
    public Item item;//
    public EquipmentPrefap equipment;//
    public ShopSlot slot;
    Data data;
    Popup popup;
    TextChanger textChanger = new TextChanger();
    PopupInventory popupInventory;
    PopupEquipment popupEquipment;
    // Start is called before the first frame update
    private void Awake()
    {

        popupInventory = GameObject.Find("InventoryPopup").GetComponent<PopupInventory>();
        popupEquipment = GameObject.Find("EquipmentPopup").GetComponent<PopupEquipment>();
    }
    void Start()
    {
        popup = gameObject.GetComponent<Popup>();
        data = DataManager.Data;
        gameObject.SetActive(false);
    }
    public void SetupItem(ShopSlot slot)
    {
        purEquip.SetActive(false);
        purItem.SetActive(true);
        this.slot = slot;
        this.item = slot.item;
        explain.text = textChanger.ExplainChangeInShop(item); ;
        itemName.text = item.itemName;
        gold.text = "" + item.price;
        portrait.sprite = item.sprite;
        shopKeeper.ChangeText(2);
    }
    public void SetupEquip(ShopSlot slot)
    {
        purEquip.SetActive(true);
        purItem.SetActive(false);
        this.slot = slot;
        this.equipment = slot.equipment;
        explain.text = equipment.explain;
        itemName.text = equipment.name;
        gold.text = "" + equipment.price;
        portrait.sprite = equipment.sprite;
        shopKeeper.ChangeText(2);
    }
    public void ClosePopup()
    {
        popup.ClosePopup();
        shopKeeper.ChangeText(3);
    }
    public void BuyThisItem()
    {
        if (data.gold >= item.price)
        {
            data.hasItems[item.itemClass][(int)item.colorType] = true;
            DataManager.instance.Save();
            data.gold -= item.price;
            shopKeeper.ChangeText(1);
            slot.Close();
            popup.ClosePopup();
            popupInventory.AddBtn(item);
            ShopKeeper.Items.Remove(item);
            return;
        }
        shopKeeper.ChangeText(4);
        popup.ClosePopup();
    }
    public void BuyThisEquip()
    {
        if (data.gold >= equipment.price)
        {
            data.hasEquipment[equipment.spriteTarget].hasEquipment[equipment.index] = true;
            DataManager.instance.Save();
            data.gold -= equipment.price;
            shopKeeper.ChangeText(1);
            slot.Close();
            popup.ClosePopup();
            popupEquipment.AddEquip(equipment);
            ShopKeeper.Equipments.Remove(equipment);
            return;
        }
        shopKeeper.ChangeText(4);
        popup.ClosePopup();
    }
}
