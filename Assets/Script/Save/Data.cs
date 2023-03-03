using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
public class Data
{
    public int gold;
    public int[] itemIndex = new int[6] { 0,0,0,0,0,0} ;//들고있는 아이템
    public Dictionary<ItemClass, bool[]> hasItems = new Dictionary<ItemClass, bool[]>();//가지고 있는 아이템
    public Dictionary<equipment, Equipment> hasEquipment = new Dictionary<equipment, Equipment>();//가지고 있는 장비
    public Dictionary<DungeonType, int> clearFloor = new Dictionary<DungeonType, int>();//클리어 한 던전의 층수
    public Data(bool isDebug) 
    {
        //장비
        hasEquipment.Add(equipment.body, new Equipment(0, new List<bool>() { true, false, false, false, false, false, false }));
        hasEquipment.Add(equipment.leftHand, new Equipment(0, new List<bool>() { true, false, false, false, false, false, false }));
        hasEquipment.Add(equipment.rightHand, new Equipment(0, new List<bool>() { true, false, false, false, false, false, false }));
        hasEquipment.Add(equipment.weapon, new Equipment(0, new List<bool>() { true, false, false, false, false, false, false }));
        //아이템
        hasItems.Add(ItemClass.portion, new bool[6] { true, true, true, true, true, true }); //기본템
        hasItems.Add(ItemClass.fruit, new bool[6] { false, false, false, false, false, false });
        //클리어 던전
        clearFloor.Add(DungeonType.redTower, 0);
        clearFloor.Add(DungeonType.orangeTower, 0);
        clearFloor.Add(DungeonType.yellowTower, 0);
        clearFloor.Add(DungeonType.greenTower, 0);
        clearFloor.Add(DungeonType.blueTower, 0);
        clearFloor.Add(DungeonType.purpleTower, 0);
        //디버그모드 앵간한거 들고있기
        if (isDebug)
        {
            gold = 9999;
            foreach (KeyValuePair<equipment, Equipment> entry in hasEquipment)//올장비
            {
                for (int i = 0; i < entry.Value.hasEquipment.Count; i++)
                {
                    entry.Value.hasEquipment[i] = true;
                }
            }
            foreach (KeyValuePair<ItemClass, bool[]> entry in hasItems)//올아이템
            {
                for (int i = 0; i < entry.Value.Length; i++)
                {
                    entry.Value[i] = true;
                }
            }
            for(int i=0;i< clearFloor.Count; i++)
            {
                clearFloor[clearFloor.Keys.ToList()[i]] = 1;
            }
        }
    }
}
