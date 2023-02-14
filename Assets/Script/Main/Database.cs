using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{
    public static Database instance;
    [SerializeField] EqujpmentPrefap[] bodyPrefap;
    [SerializeField] EqujpmentPrefap[] leftPrefap;
    [SerializeField] EqujpmentPrefap[] rightPrefap;
    [SerializeField] EqujpmentPrefap[] weaponPrefap;
    [SerializeField] Item[] itemPrefap;
    Dictionary<equipment, EqujpmentPrefap[]> prefaps = new Dictionary<equipment, EqujpmentPrefap[]>();

    public Item[] ItemPrefap { get => itemPrefap; }

    private void Awake()
    {
        if (instance != null) Destroy(gameObject);
        instance = this;
        prefaps.Add(equipment.body, bodyPrefap);
        prefaps.Add(equipment.leftHand, leftPrefap);
        prefaps.Add(equipment.rightHand, rightPrefap);
        prefaps.Add(equipment.weapon, weaponPrefap);
    }
    public EqujpmentPrefap[] GetPrefaps(equipment target)
    {
        return prefaps[target];
    }
    public Item GetItemData(int index)
    {
        return itemPrefap[index];
    }
}
