using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickOperationAction : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private Canvas settingMenu;

    void Start()
    {
        settingMenu.enabled = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            settingMenu.enabled = true;
        }
    }
}
