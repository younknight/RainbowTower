using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    List<Item> startItem = new List<Item>();

    private void Start()
    {
        foreach (Item item in PlayerManager.PlayerItem)
        {
            this.startItem.Add(item);
        }
        for (int i = 0; i < startItem.Count; i++)
        {
            //Inventory.Instance.AcquireItem(startItem[i]);
        }
    }
}
