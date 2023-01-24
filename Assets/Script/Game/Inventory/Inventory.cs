using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    static Inventory instance;
    [SerializeField] GameObject SlotsParent;
    Slot[] slots;

    public static Inventory Instance { get => instance; }

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
                return;
            }
        }
    }
}
