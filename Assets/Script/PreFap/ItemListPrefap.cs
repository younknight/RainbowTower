using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewItemList", menuName = "NewItemList/ItemList")]
public class ItemListPrefap : ScriptableObject
{
    public int index;
    public Item representImage;
    public List<Item> items;
}
