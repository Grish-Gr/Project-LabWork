using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AddMetalPlate : MonoBehaviour
{
    [SerializeField]
    private Button buttonAddPlate;
    [SerializeField]
    private Canvas parentCanvas;
    [SerializeField]
    private Canvas menuPlate;

    [SerializeField]
    private Text textLength;
    
    [SerializeField]
    private Text textWidth;
    
    [SerializeField]
    private Text textThick;

    private List<Listener> listListeners = new List<Listener>();
    public delegate void Listener(double length, double width, double thick);
    public void AddListener(Listener listener)
    {
        listListeners.Add(listener);
    }

    void Start()
    {
        buttonAddPlate.onClick.AddListener(delegate {
            listListeners.ForEach(listener => listener.Invoke(
                Convert.ToDouble(textLength.text),
                Convert.ToDouble(textWidth.text),
                Convert.ToDouble(textThick.text)
            ));
            parentCanvas.enabled = false;
            menuPlate.enabled = false;
        });
    }
}
