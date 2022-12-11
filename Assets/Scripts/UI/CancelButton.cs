using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CancelButton : MonoBehaviour, IPointerDownHandler
{
    public Canvas parentCanvas;

    public void OnPointerDown(PointerEventData eventData)
    {
        parentCanvas.enabled = false;
    }
}
