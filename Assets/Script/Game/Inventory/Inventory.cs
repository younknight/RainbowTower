using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inventory : MonoBehaviour
{
    static Inventory instance;
    int sp = 50;
    [SerializeField] GameObject SlotsParent;
    public Slot[] slots = new Slot[12];

    public static Inventory Instance { get => instance; }
    public int Sp { get => sp; set => sp = value; }

    private void Awake()
    {
        if (instance == null) instance = this;
        //slots = SlotsParent.GetComponentsInChildren<Slot>();
    }
    private void Start()
    {
        slots = SlotsParent.GetComponentsInChildren<Slot>();
        for (int i = 0; i < SlotsParent.transform.childCount; i++)
        {
            //slots[i] = SlotsParent.transform.GetChild(i).transform.GetChild(0).transform.GetComponent<Slot>();
            slots[i].Index = i;
        }
    }
    public void RandomAcquireItem()
    {
        int range = PlayerManager.PlayerItem.Count;
        int itemIndex = Random.Range(0, range);
        if(range != 0) AcquireItem(PlayerManager.PlayerItem[itemIndex]);
    }
    public void AcquireItem(Item _item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == null)
            {
                slots[i].AddItem(_item);
                return;
            }
        }
    }
    public void SwapSlot(Slot currentItem, Slot previousItem)
    {
        //int tmp = previousItem.Index;
        //slots[previousItem.Index] = slots[currentItem.Index];
        //previousItem.Index = currentItem.Index;
        //slots[currentItem.Index] = slots[tmp];
        //currentItem.Index = tmp; 
        Item item = currentItem.item;
        Image image = currentItem.itemImage;
        currentItem.item = previousItem.item;
        currentItem.itemImage = previousItem.itemImage;
        previousItem.item = item;
        previousItem.itemImage = image;
    }
}
