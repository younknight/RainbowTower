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
    public Item item;//
    public ShopItemSlot slot;
    Data data;
    Popup popup;
    // Start is called before the first frame update
    void Start()
    {
        popup = gameObject.GetComponent<Popup>();
        data = DataManager.Data;
        gameObject.SetActive(false);
    }
    public void Setup(ShopItemSlot slot)
    {
        this.item = slot.item;
        string str = "";
        for (int index = 0; index < item.itemType.Length; index++)
        {
            str = item.explain.Replace("@Cool" + (index + 1), "<color=red>" + item.coolTime[index] + "</color>");
            str = str.Replace("@Value" + (index + 1), "<color=red>" + item.value[index] + "</color>");
        }
        explain.text = str;
        itemName.text = item.itemName;
        gold.text = "" + item.itemValue;
        portrait.sprite = item.sprite;
        shopKeeper.ChangeText(2);
    }
    public void ClosePopup()
    {
        popup.ClosePopup();
        shopKeeper.ChangeText(3);
    }
    public void BuyThisItem()
    {
        if (data.gold >= item.itemValue)
        {
            data.hasItems[item.itemClass][(int)item.colorType] = true;
            DataManager.instance.Save();
            data.gold -= item.itemValue;
            shopKeeper.ChangeText(1);
            popup.ClosePopup();
        }
    }
}
