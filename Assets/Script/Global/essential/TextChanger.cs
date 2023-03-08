using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextChanger
{
    public string ExplainChangeInGame(Item item, Slot slot)
    {
        string str = item.explain;
        for (int index = 0; index < item.itemType.Length; index++)
        {
            //Debug.Log(index);
            str = str.Replace("@Cool" + (index + 1), "<color=red>" + item.coolTime[index] + "</color>");
            str = str.Replace("@Value" + (index + 1), "<color=red>" + item.value[index] + "</color>");
            str = str.Replace("@Link", "<color=blue>" + Slot.Graph[item.colorType].BFS(slot.index) + "</color>");
        }
        return str;
    }
    public string ExplainChangeInShop(Item item)
    {
        string str = item.explain;
        for (int index = 0; index < item.itemType.Length; index++)
        {
            //Debug.Log(index);
            str = str.Replace("@Cool" + (index + 1), "<color=red>" + item.coolTime[index] + "</color>");
            str = str.Replace("@Value" + (index + 1), "<color=red>" + item.value[index] + "</color>");
            str = str.Replace("@Link", "<color=blue>" +"Link"+ "</color>");
        }
        return str;
    }
}
