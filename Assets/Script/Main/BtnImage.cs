using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BtnImage : MonoBehaviour
{
    [SerializeField] Image portrait;
    public void ChangePortrait(Sprite sprite)
    {
        portrait.sprite = sprite;
    }
}
