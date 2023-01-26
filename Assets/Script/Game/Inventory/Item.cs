using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="NewItem", menuName = "NewItem/item")]
public class Item : ScriptableObject
{
    public status targetState;
    public ItemType itemType;
    public int itemLevel;
    public int duration;
    public double value;
    public Sprite itemImage;
}
