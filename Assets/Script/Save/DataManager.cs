using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    PlayerData playerData = new PlayerData();
    static Data data;
    public static Data Data { get => data; }
    void Awake()
    {
        if (instance != null) Destroy(gameObject);
        instance = this;
        data = playerData.LoadJsonFile(playerData.FileName);
    }
    public static void SetSpriteData(spriteType target, int value)
    {
        data.playerSprites[target] = value;
    }
    public void Save()
    {
        playerData.SaveJsonFile(playerData.FileName, data);
    }
}
