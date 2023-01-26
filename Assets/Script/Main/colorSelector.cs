using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class colorSelector : MonoBehaviour
{
    public ColorStatusPrefap color;

    public ColorStatusPrefap Color { get => color; }

    public void Init(ColorStatusPrefap colorStatusPrefap)
    {
        color = colorStatusPrefap;
        gameObject.transform.GetChild(0).GetComponent<Image>().sprite = Color.sprite;
    }
    public void ChangeColor()
    {
        PlayerManager.ChangeSprite(Color.spriteTarget, Color.sprite);
        UIPopup.instance.ActivatePopup();
    }
}