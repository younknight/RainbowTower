using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    UnitPrefap ThisCharacter;
    List<Item> startItem = new List<Item>();

    private void Start()
    {
        ThisCharacter = gameObject.GetComponent<UnitState>().ThisCharacter;
        foreach (Item item in ThisCharacter.startItem)
        {
            this.startItem.Add(item);
        }
        for (int i = 0; i < startItem.Count; i++)
        {
            Inventory.Instance.AcquireItem(startItem[i]);
        }
    }
}
