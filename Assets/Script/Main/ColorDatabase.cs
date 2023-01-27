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
    Dictionary<spriteType, ColorStatusPrefap[]> prefaps = new Dictionary<spriteType, ColorStatusPrefap[]>();
    private void Awake()
    {
        if (instance != null) Destroy(gameObject);
        instance = this;
        prefaps.Add(spriteType.body, colorBodyPrefap);
        prefaps.Add(spriteType.leftHand, colorLeftPrefap);
        prefaps.Add(spriteType.rightHand, colorRightPrefap);
        prefaps.Add(spriteType.weapon, weaponPrefap);
    }
    public ColorStatusPrefap[] GetPrefaps(spriteType target)
    {
        return prefaps[target];
    }
}
