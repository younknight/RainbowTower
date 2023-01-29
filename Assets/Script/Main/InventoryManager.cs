using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    [SerializeField] GameObject inventory;
    [SerializeField] GameObject itemBtn;
    int selectedItemNum = 0;
    int maxItemNum = 10;

    public GameObject Inventory { get => inventory; set => inventory = value; }
    public GameObject ItemBtn { get => itemBtn; set => itemBtn = value; }

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    public void AddItem()
    {
        if(selectedItemNum < maxItemNum)
        {
            Instantiate<GameObject>(ItemBtn, Inventory.transform);
        }
    }
}
