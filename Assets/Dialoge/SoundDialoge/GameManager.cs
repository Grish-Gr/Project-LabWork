using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int count;
    public int num;
    public GameObject NextStep;
    // Start is called before the first frame update
    private void Start()
    {

    }

    public void ButClick()
    {
        count++;
        Debug.Log(count);
        if (count % num == 0)
        {
            NextStep.SetActive(!NextStep.activeSelf);
        }
    }
}
