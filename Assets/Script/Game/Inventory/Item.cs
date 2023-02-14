using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="NewItem", menuName = "NewItem/item")]
public class Item : ScriptableObject
{
    public status targetState;
    public ItemType itemType;
    public Sprite sprite;
    public string itemName;
    public string explain;
    public int itemIndex;
    public int duration;
    public double value;
}
