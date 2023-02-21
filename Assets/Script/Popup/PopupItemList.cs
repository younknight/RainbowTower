using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PopupItemList : MonoBehaviour
{
    [SerializeField] Image[] images;

    private void Start()
    {
        //훗날 예외 추가해줘
        for(int i = 0; i< PlayerManager.PlayerItem.Count; i++)
        {
            Item item = PlayerManager.PlayerItem[i];
            images[(int)item.colorType].sprite = PlayerManager.PlayerItem[i].sprite;
        }
        gameObject.SetActive(false);
    }
}
