using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager
{
    static Dictionary<equipment, EquipmentPrefap> playerEquipment = new Dictionary<equipment, EquipmentPrefap>() {
        {equipment.body, null },
        {equipment.leftHand, null },
        {equipment.rightHand, null },
        {equipment.weapon, null },
    };
    static List<Item> playerItem = new List<Item>();
    public static Dictionary<equipment, EquipmentPrefap> PlayerStatus { get => playerEquipment; }
    public static List<Item> PlayerItem { get => playerItem; }

    public static void ChangeEquipment(equipment targetSprite, EquipmentPrefap status)
    {
        playerEquipment[targetSprite] = status;
    }
}
