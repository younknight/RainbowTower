using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int itemNum = 0;
    public static Inventory instance;
    [SerializeField]
    GameObject SlotsParent;
    Slot[] slots;
    private void Awake()
    {
        if (instance == null) instance = this;
        slots = SlotsParent.GetComponentsInChildren<Slot>();
    }
    public void AcquireItem(Item _item)
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if(slots[i].item == null)
            {
                slots[i].AddItem(_item);
                itemNum++;
                return;
            }
        }
    }
}
