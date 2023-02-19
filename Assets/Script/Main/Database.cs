using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{
    public static Database instance;
    [SerializeField] List<EquipmentPrefap> bodyPrefap;
    [SerializeField] List<EquipmentPrefap> leftPrefap;
    [SerializeField] List<EquipmentPrefap> rightPrefap;
    [SerializeField] List<EquipmentPrefap> weaponPrefap;
    [SerializeField] List<ItemListPrefap> itemPrefap;
    Dictionary<equipment, List<EquipmentPrefap>> prefaps = new Dictionary<equipment, List<EquipmentPrefap>>();

    public List<ItemListPrefap> ItemPrefap { get => itemPrefap; }

    private void Awake()
    {
        if (instance != null) Destroy(gameObject);
        instance = this;
        prefaps.Add(equipment.body, bodyPrefap);
        prefaps.Add(equipment.leftHand, leftPrefap);
        prefaps.Add(equipment.rightHand, rightPrefap);
        prefaps.Add(equipment.weapon, weaponPrefap);
        //foreach(Item item in itemPrefap.FindAll(x => x.itemClass == ItemClass.portion))
        //{
        //    Debug.Log(item.itemName);
        //}
    }
    public List<EquipmentPrefap> GetPrefaps(equipment target)
    {
        return prefaps[target];
    }
}
