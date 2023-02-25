using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EquipmentSlot : MonoBehaviour
{
    [SerializeField] GameObject SlotsParent;
    public Slot[] slots = new Slot[16];//
    LinkCalculatter LinkCalculater;
    public static EquipmentSlot instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    void Start()
    {
        slots = SlotsParent.GetComponentsInChildren<Slot>();
        for (int i = 0; i < SlotsParent.transform.childCount; i++)
        {
            slots[i].Index = i;
        }
    }

}
