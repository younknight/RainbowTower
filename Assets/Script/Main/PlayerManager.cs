using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerManager
{
    //public static PlayerManager instance;
    public static PlayerPrefab character;
    //private void Awake()
    //{
    //    if (instance != null) Destroy(gameObject);
    //    instance = this;
    //}
    public static void SetCharacter(PlayerPrefab Character)
    {
        character = Character;
    }
}
