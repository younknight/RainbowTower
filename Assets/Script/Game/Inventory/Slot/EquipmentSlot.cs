using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EquipmentSlot : MonoBehaviour
{
    [SerializeField] GameObject SlotsParent;
    public Slot[] slots = new Slot[9];
    void Start()
    {
        slots = SlotsParent.GetComponentsInChildren<Slot>();
        for (int i = 0; i < SlotsParent.transform.childCount; i++)
        {
            //slots[i] = SlotsParent.transform.GetChild(i).transform.GetChild(0).transform.GetComponent<Slot>();
            slots[i].Index = i;
        }
    }
}
