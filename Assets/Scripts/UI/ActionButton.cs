using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ActionButton : MonoBehaviour, IPointerDownHandler
{
    public ActionElement actionElement;
    public bool isUpValue = true;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isUpValue)
            actionElement.UpValue();
        else
            actionElement.DownValue();
    }
}
