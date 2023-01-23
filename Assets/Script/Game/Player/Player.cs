using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    [SerializeField] PlayerPrefab ThisCharacter;
    List<Item> startItem = new List<Item>();
    UnitState playerStatus;

    private void Awake()
    {
        if (PlayerManager.character != null) ThisCharacter = PlayerManager.character;
    }
    private void Start()
    {
        foreach (Item item in ThisCharacter.startItem)
        {
            this.startItem.Add(item);
        }
        for (int i = 0; i < startItem.Count; i++)
        {
            Inventory.instance.AcquireItem(startItem[i]);
        }
    }
}
