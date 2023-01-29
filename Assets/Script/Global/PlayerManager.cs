using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager
{
    public static Dictionary<equipment, Sprite> playerSprite = new Dictionary<equipment, Sprite>() {
        {equipment.body, null },
        {equipment.leftHand, null },
        {equipment.rightHand, null },
        {equipment.weapon, null },
    };
    public static Dictionary<equipment, ColorStatusPrefap> playerStatus = new Dictionary<equipment, ColorStatusPrefap>() {
        {equipment.body, null },
        {equipment.leftHand, null },
        {equipment.rightHand, null },
        {equipment.weapon, null },
    };
    public static List<Item> playerItem = new List<Item>();
    public static void ChangeSprite(equipment targetSprite, ColorStatusPrefap status)
    {
        playerSprite[targetSprite] = status.sprite;
        playerStatus[targetSprite] = status;
    }
}
