using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerManager
{
    public static Dictionary<spriteType, Sprite> playerSprite = new Dictionary<spriteType, Sprite>() {
        {spriteType.body, null },
        {spriteType.leftHand, null },
        {spriteType.rightHand, null },
        {spriteType.weapon, null },
    };

    public static void ChangeSprite(spriteType targetSprite, Sprite value)
    {
        playerSprite[targetSprite] = value;
    }
}
