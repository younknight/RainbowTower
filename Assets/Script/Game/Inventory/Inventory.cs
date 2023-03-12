using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Inventory : MonoBehaviour
{
    static Inventory instance;
    int sp = 150;
    [SerializeField] TextMeshProUGUI spText;
    [SerializeField] Transform SlotsParent;
    public Slot[] slots = new Slot[16];
    SlotManager slotManager;
    public static Inventory Instance { get => instance; }
    public int Sp { get => sp; }

    private void Awake()
    {
        if (instance == null) instance = this;
        slots = SlotsParent.GetComponentsInChildren<Slot>();
        for (int i = 0; i < SlotsParent.transform.childCount; i++)
        {
            slots[i].Index = i;
        }
        spText.text = "" + sp;
    }
    private void Start()
    {
        slotManager = new SlotManager(EquipmentSlot.instance);
    }
    public void GetSp(int value)
    {
        sp += value;
        spText.text = "" + sp;
    }
    public void RandomAcquireItem()
    {
        int range = PlayerManager.PlayerItem.Count;
        int itemIndex = Random.Range(0, range);
        if (range != 0)
        {
            if (sp >= 10)
            {
                AcquireItem(itemIndex);
                sp -= 10;
                spText.text = "" + sp;
            }
        }
    }
    public void AcquireItem(int index)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == null)
            {
                slots[i].AddItem(PlayerManager.PlayerItem[index]);
                slotManager.ActiveSlot(true, slots[i], slots[i]);
                break;
            }
        }
    }
    public void SwapSlot(Slot currentItem, Slot previousItem)
    {
        Item item = currentItem.item;
        Image image = currentItem.itemImage;
        currentItem.item = previousItem.item;
        currentItem.itemImage = previousItem.itemImage;
        previousItem.item = item;
        previousItem.itemImage = image;
    }
}
