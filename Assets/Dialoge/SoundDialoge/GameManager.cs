using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float count;
    public float num;
    public float temp;
    public GameObject NextStep;
    // Start is called before the first frame update
    private void Start()
    {

    }

    public void ButClickPlus()
    {
        count=count+temp;
        Debug.Log(count);
        if (count == num)
        {
            NextStep.SetActive(true);
        }
        else
        {
            NextStep.SetActive(false);
        }
    }
    public void ButClickMinus()
    {
        count=count-temp;
        Debug.Log(count);
        if (count == num)
        {
            NextStep.SetActive(true);
        }
        else
        {
            NextStep.SetActive(false);
        }
    }
}
