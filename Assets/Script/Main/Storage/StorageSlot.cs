using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageSlot : MonoBehaviour
{
    [SerializeField] Popup popup;
    PopupStorage popupStorage;
    [SerializeField] bool isItem;

    public bool IsItem { get => isItem; set => isItem = value; }

    void Awake()
    {
        Transform popupParent = GameObject.Find("storage").transform;
        popup = popupParent.Find("PopupStorage").GetComponent<Popup>();
        popupStorage = popupParent.Find("PopupStorage").GetComponent<PopupStorage>();
    }
    public void OpenPopup()
    {
        popup.OpenPopup();
        if (isItem) popupStorage.Item = gameObject.GetComponent<ItemSelector>().itemPrefap;
        else popupStorage.EquipmentPrefap = gameObject.GetComponent<EquipmentSelector>().EquipmentPrefap;
        popupStorage.Setup(IsItem);
    }
}
