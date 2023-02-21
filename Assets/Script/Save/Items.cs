using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public int currentIndex;
    public List<bool> hasEquipment;

    public Items(int currentIndex, List<bool> hasEquipment)
    {
        this.currentIndex = currentIndex;
        this.hasEquipment = hasEquipment;
    }
}
