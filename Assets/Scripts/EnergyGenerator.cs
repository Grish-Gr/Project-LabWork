using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyGenerator : MonoBehaviour
{
    public MeshRenderer MeshButton;
    public Material MaterialIsOn;
    public Material MaterialIsOff;
    private bool isEnergy = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            isEnergy = false;
            MeshButton.material = MaterialIsOff;
            Debug.Log("Energy Off");
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            isEnergy = true;
            MeshButton.material = MaterialIsOn;
            Debug.Log("Energy On");
        }
    }

    public bool IsEnergy()
    {
        return isEnergy;
    }
}
