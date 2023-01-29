using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="NewItem", menuName = "NewItem/item")]
public class Item : ScriptableObject
{
    public status targetState;
    public ItemType itemType;
    public string itemName;
    public int itemIndex;
    public int duration;
    public double value;
    public Sprite sprite;
}
