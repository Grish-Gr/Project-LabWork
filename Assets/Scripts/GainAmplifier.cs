using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainAmplifier : MonoBehaviour
{
    public float MinGain;
    public float MaxGain;
    public float StepGain;
    private float currentGain;

    void Start()
    {
        currentGain = MinGain;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            currentGain += StepGain;
            if (currentGain > MaxGain)
                currentGain = MaxGain;
            else
                transform.Rotate(0, 0, 20f);
            Debug.Log("Current Gain Amplifier: " + currentGain);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            currentGain -= StepGain;
            if (currentGain < MinGain)
                currentGain = MinGain;
            else
                transform.Rotate(0, 0, -20f);
            Debug.Log("Current Gain Amplifier: " + currentGain);
        }
    }

    public float GetGain()
    {
        return currentGain;
    }
}
