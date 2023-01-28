using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorDatabase : MonoBehaviour
{
    public static ColorDatabase instance;
    [SerializeField] ColorStatusPrefap[] colorBodyPrefap;
    [SerializeField] ColorStatusPrefap[] colorLeftPrefap;
    [SerializeField] ColorStatusPrefap[] colorRightPrefap;
    [SerializeField] ColorStatusPrefap[] weaponPrefap;
    Dictionary<equipment, ColorStatusPrefap[]> prefaps = new Dictionary<equipment, ColorStatusPrefap[]>();
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
