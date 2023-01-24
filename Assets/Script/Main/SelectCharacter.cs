using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SelectCharacter : MonoBehaviour
{
    [SerializeField] GameObject character;
    [SerializeField] Sprite portrait;
    private void Start()
    {
        Image image = transform.GetChild(0).GetComponent<Image>();
        image.sprite = portrait;
        if (PlayerDatabase.Character == null) PlayerDatabase.SetCharacter(character);
    }
    public void ChanageCharacter()
    {
        PlayerDatabase.SetCharacter(character);
        PlayerTitle.instance.SetImage(portrait);
    }
}
