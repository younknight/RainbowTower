using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment
{
    public int currentIndex;
    public List<bool> hasEquipment;

    public Equipment(int currentIndex, List<bool> hasEquipment)
    {
        this.currentIndex = currentIndex;
        this.hasEquipment = hasEquipment;
    }
}
