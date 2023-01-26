using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprite : MonoBehaviour
{
    [SerializeField] List<spriteType> keys = new List<spriteType>();
    [SerializeField] List<SpriteRenderer> values = new List<SpriteRenderer>();
    Dictionary<spriteType, SpriteRenderer> playerSprite = new Dictionary<spriteType, SpriteRenderer>();
    private void Start()
    {
        if (keys.Count != values.Count) throw new System.Exception("keys.Count != values.Count");
        for(int i = 0; i< keys.Count; i++)
        {
            playerSprite.Add(keys[i], values[i]);
        }
        foreach(KeyValuePair<spriteType, Sprite> entry in PlayerManager.playerSprite)
        {
            if (entry.Value != null) playerSprite[entry.Key].sprite = entry.Value;
        }
    }
}
