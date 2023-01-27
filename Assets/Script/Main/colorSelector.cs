using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSelector : MonoBehaviour
{
    public ColorStatusPrefap colorPrefap;

    public ColorStatusPrefap Color { get => colorPrefap; }

    public void Init(ColorStatusPrefap colorStatusPrefap)
    {
        colorPrefap = colorStatusPrefap;
        gameObject.transform.GetChild(0).GetComponent<Image>().sprite = colorPrefap.sprite;
    }
    public void ChangeColor()
    {
        PlayerManager.ChangeSprite(colorPrefap.spriteTarget, colorPrefap);
        

        DataManager.SetSpriteData(colorPrefap.spriteTarget, colorPrefap.index);//������ ����
        UIPopup.instance.ActivatePopup();
    }
}