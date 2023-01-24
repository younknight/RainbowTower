using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerDatabase
{
    static GameObject character;

    public static GameObject Character { get => character; }

    public static void SetCharacter(GameObject Character)
    {
        character = Character;
    }
}
