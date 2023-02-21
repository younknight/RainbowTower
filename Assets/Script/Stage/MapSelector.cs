using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class MapSelector : MonoBehaviour
{
    [SerializeField] List<EnemyListPrefap> thisEnemyList;
    Popup popupTower;
    Popup popupHome;
    PopupSelectMap popupSelectMap;
    static List<GameObject> enemyList = new List<GameObject>();
    public static List<GameObject> EnemyList { get => enemyList; set => enemyList = value; }

    private void Awake()
    {
        var popup = GameObject.Find("Popup");
        var popupT = popup.transform.GetChild(0);
        popupTower = popupT.GetComponent<Popup>();
        popupSelectMap = popupT.GetComponent<PopupSelectMap>();
        popupHome = popup.transform.GetChild(1).GetComponent<Popup>();
    }
    public void SetEnemyList()
    {
        //enemyList.RemoveAll(x => true);
        //foreach (GameObject enemy in thisEnemyList.enemyList)
        //{
        //    enemyList.Add(enemy);
        //}
    }
    public void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (transform.name == "Home")
            {
                popupHome.TogglePopup();
                return;
            }
            if (thisEnemyList != null)
            {
                popupSelectMap.Setup(thisEnemyList,gameObject.name);
                popupTower.TogglePopup();
                SetEnemyList();
                //SceneManager.LoadScene("Game");
            }
        }
    }
}
