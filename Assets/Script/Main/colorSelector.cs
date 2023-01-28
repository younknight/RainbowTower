using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSelector : MonoBehaviour
{
    ColorStatusPrefap colorPrefap;//������ �ִ� ��������

    public ColorStatusPrefap Color { get => colorPrefap; }

    public void InitalizeButton(ColorStatusPrefap colorStatusPrefap)//��ư�� ������ �̹��� �ʱ�ȭ
    {
        colorPrefap = colorStatusPrefap;
        gameObject.transform.GetChild(0).GetComponent<Image>().sprite = colorPrefap.sprite;
    }
    public void ChangeColor()//���� �ٲٱ�
    {
        PlayerManager.ChangeSprite(colorPrefap.spriteTarget, colorPrefap); //�÷��̾� ��������
        StatusManager.instance.SetStatus(); //�������ͽ� ���� ǥ��
        DataManager.SetEquipmentData(colorPrefap.spriteTarget, colorPrefap.index);//������ ����
        Debug.Log("�۵���");
        PopupManager.instance.ActivatePopup();
    }
}