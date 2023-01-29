using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{
    public static Database instance;
    [SerializeField] ColorStatusPrefap[] colorBodyPrefap;
    [SerializeField] ColorStatusPrefap[] colorLeftPrefap;
    [SerializeField] ColorStatusPrefap[] colorRightPrefap;
    [SerializeField] ColorStatusPrefap[] weaponPrefap;
    [SerializeField] Item[] itemPrefap;
    Dictionary<equipment, ColorStatusPrefap[]> prefaps = new Dictionary<equipment, ColorStatusPrefap[]>();

    public Item[] ItemPrefap { get => itemPrefap; }

    private void Awake()
    {
        if (instance != null) Destroy(gameObject);
        instance = this;
        prefaps.Add(equipment.body, colorBodyPrefap);
        prefaps.Add(equipment.leftHand, colorLeftPrefap);
        prefaps.Add(equipment.rightHand, colorRightPrefap);
        prefaps.Add(equipment.weapon, weaponPrefap);
    }
    public ColorStatusPrefap[] GetPrefaps(equipment target)
    {
        return prefaps[target];
    }
}
