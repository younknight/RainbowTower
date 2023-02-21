using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
public class Data
{
    
    public Dictionary<equipment, Equipment> equipment = new Dictionary<equipment, Equipment>()
    {
        { global::equipment.body, new Equipment(0, new List<bool>(){ true, false, false, false, false, false, false })},
        { global::equipment.leftHand, new Equipment(0, new List<bool>(){ true, false, false, false, false, false, false })},
        { global::equipment.rightHand, new Equipment(0, new List<bool>(){ true, false, false, false, false, false, false })},
        { global::equipment.weapon, new Equipment(0, new List<bool>(){ true, false, false, false, false, false, false })}
    };
    public Dictionary<colorType, int> hasColor = new Dictionary<colorType, int>()
    {
        { colorType.red, 0 },
        { colorType.orange, 0 },
        { colorType.yellow, 0 },
        { colorType.green, 0 },
        { colorType.blue, 0 },
        { colorType.purple, 0 }
    };
    public int[] itemIndex = new int[6] { 0,0,0,0,0,0} ;//들고있는 아이템
    public Dictionary<ItemClass, bool[]> hasItems = new Dictionary<ItemClass, bool[]>()//가지고 있는 아이템
    {
        {ItemClass.portion, new bool[6]{ true, true, true, true, true, true } }
    };
    public Data(bool isDebug) 
    {
        if (isDebug)
        {
            foreach(KeyValuePair<equipment, Equipment> entry in equipment)
            {
                for(int i=0;i< entry.Value.hasEquipment.Count; i++)
                {
                    entry.Value.hasEquipment[i] = true;
                }
            }
        }
    }
}
