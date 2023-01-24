using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
public class ShowInformation : MonoBehaviour
{
    GameObject thisCharacter;
    UnitPrefap unitPrefap;
    Sprite portrait;
    //ÆË¾÷ Á¤º¸Ã¢
    [SerializeField] TextMeshProUGUI[] statusText = new TextMeshProUGUI[4];
    [SerializeField] TextMeshProUGUI explainText;
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] Image ThisCharacterPortrait;
    private void Start()
    {
        gameObject.SetActive(false);
    }
    public void ShowInfo()
    {
        gameObject.SetActive(true);
        thisCharacter = EventSystem.current.currentSelectedGameObject.GetComponent<SelectCharacter>().Character;
        portrait = EventSystem.current.currentSelectedGameObject.GetComponent<SelectCharacter>().Portrait;
        unitPrefap = thisCharacter.GetComponent<UnitState>().ThisCharacter;
        SetInformation();
    }
    void SetInformation()
    {
        ThisCharacterPortrait.sprite = portrait;
        statusText[0].text = "" + unitPrefap.hp;
        statusText[1].text = "" + unitPrefap.attackDamage;
        statusText[2].text = "" + unitPrefap.critcalRate;
        statusText[3].text = "" + unitPrefap.critcalDamage;
        explainText.text = unitPrefap.explain;
        nameText.text = unitPrefap.name;
    }
    public void SetCharacter()
    {
        PlayerDatabase.SetCharacter(thisCharacter);
        PlayerTitle.instance.SetImage(portrait);
    }
    public void EndInfo()
    {
        gameObject.SetActive(false);
    }
}
