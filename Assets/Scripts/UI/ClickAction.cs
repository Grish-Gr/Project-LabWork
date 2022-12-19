using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickAction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    [SerializeField]
    private Material materialPointEnter;
    [SerializeField]
    private Material materialPointExit;
    [SerializeField]
    private Canvas menu;

    void Start()
    {
        menu.enabled = false;
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("FKAK:FL");
        this.GetComponent<Renderer>().material = materialPointEnter;
    }

    public void OnPointerExit(PointerEventData eventData)
	{
        Debug.Log("FJAKLJFKLAJLKF:FL");
		this.GetComponent<Renderer>().material = materialPointExit;
	}

    public void OnPointerDown(PointerEventData eventData)
    {
        menu.enabled = true;
    }
}
