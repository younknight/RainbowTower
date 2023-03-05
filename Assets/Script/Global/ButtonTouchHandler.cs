using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonTouchHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public ScrollRect ParentSR;//

    private void Awake()
    {
        Debug.Log(transform.parent.parent.parent.parent.parent.parent.parent.parent.name);
        ParentSR = transform.parent.parent.parent.parent.parent.parent.parent.GetComponent<ScrollRect>();
    }

    public void OnBeginDrag(PointerEventData e)
    {
        Debug.Log("start");
        ParentSR.OnBeginDrag(e);
    }
    public void OnDrag(PointerEventData e)
    {
        Debug.Log("중");
        ParentSR.OnDrag(e);
    }
    public void OnEndDrag(PointerEventData e)
    {
        Debug.Log("end");
        ParentSR.OnEndDrag(e);
    }
}