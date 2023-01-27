using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
public class Data

{
    public Dictionary<spriteType, int> playerSprites = new Dictionary<spriteType, int>();
    public Data() { }
    public Data(bool isSet)
    {
        if (isSet)
        {
            playerSprites.Add(spriteType.body, 0);
            playerSprites.Add(spriteType.leftHand, 0);
            playerSprites.Add(spriteType.rightHand, 0);
            playerSprites.Add(spriteType.weapon, 0);
        }
    }
    public void PrintAll()
    {
        foreach(KeyValuePair<spriteType, int> entry in playerSprites)
        {
            Debug.Log(entry.Key + "/" + entry.Value);
        }
    }
}
