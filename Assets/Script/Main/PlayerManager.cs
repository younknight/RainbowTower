using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager
{
    public static Dictionary<spriteType, Sprite> playerSprite = new Dictionary<spriteType, Sprite>() {
        {spriteType.body, null },
        {spriteType.leftHand, null },
        {spriteType.rightHand, null },
        {spriteType.weapon, null },
    };
    public static Dictionary<spriteType, ColorStatusPrefap> playerStatus = new Dictionary<spriteType, ColorStatusPrefap>() {
        {spriteType.body, null },
        {spriteType.leftHand, null },
        {spriteType.rightHand, null },
        {spriteType.weapon, null },
    };
    public static void ChangeSprite(spriteType targetSprite, ColorStatusPrefap status)
    {
        playerSprite[targetSprite] = status.sprite;
        playerStatus[targetSprite] = status;
    }
}
