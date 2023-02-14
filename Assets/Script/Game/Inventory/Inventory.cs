using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    static Inventory instance;
    int sp = 50;
    [SerializeField] GameObject SlotsParent;
    Slot[] slots;

    public static Inventory Instance { get => instance; }
    public int Sp { get => sp; set => sp = value; }

    private void Awake()
    {
        if (instance == null) instance = this;
        slots = SlotsParent.GetComponentsInChildren<Slot>();
    }
    public void RandomAcquireItem()
    {
        int range = PlayerManager.PlayerItem.Count;
        int itemIndex = Random.Range(0, range);
        if(range != 0) AcquireItem(PlayerManager.PlayerItem[itemIndex]);
    }
    public void AcquireItem(Item _item)
    {
        if(sp >= 10)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].item == null)
                {
                    slots[i].AddItem(_item);
                    sp -= 10;
                    return;
                }
            }
        }
    }
}
