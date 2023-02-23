using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ShopKeeper : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI keepersTalk;
    [SerializeField] Transform itemsParents;
    public ShopItemSlot[] shopItemSlots;//
    Data data;
    List<ItemListPrefap> itemListPrefaps = new List<ItemListPrefap>();
    void Start()
    {
        data = DataManager.Data;
        itemListPrefaps = Database.instance.ItemPrefap;
        shopItemSlots = itemsParents.GetComponentsInChildren<ShopItemSlot>();
        SetItem();
    }

    void SetItem()
    {
        foreach(ShopItemSlot slot in shopItemSlots)
        {
            int listIndex = Random.Range(0, itemListPrefaps.Count);
            int itemIndex = Random.Range(0, itemListPrefaps[listIndex].items.Count);
            slot.Setup(itemListPrefaps[listIndex].items[itemIndex]);
        }
    }
}
