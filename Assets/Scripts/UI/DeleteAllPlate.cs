using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DeleteAllPlate : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private Canvas parentCanvas;
    private List<Listener> listListeners = new List<Listener>();
    public delegate void Listener();
    public void AddListener(Listener listener)
    {
        listListeners.Add(listener);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        listListeners.ForEach(listener => listener.Invoke());
        parentCanvas.enabled = false;
    }
}
