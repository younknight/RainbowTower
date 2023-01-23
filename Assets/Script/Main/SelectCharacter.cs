using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SelectCharacter : MonoBehaviour
{
    [SerializeField] PlayerPrefab character;
    [SerializeField] Sprite portrait;
    private void Start()
    {
        //if (PlayerManager.character == null) PlayerManager.character = character;
        Image image = transform.GetChild(0).GetComponent<Image>();
        image.sprite = portrait;
    }
    public void ChanageCharacter()
    {
        PlayerManager.SetCharacter(character);
        PlayerTitle.instance.SetImage(portrait);
    }
}
