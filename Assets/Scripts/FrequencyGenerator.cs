using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrequencyGenerator : MonoBehaviour
{
    public const int MIN_FREQUENCY = 8000;
    public const int MAX_FREQUENCY = 10000;
    private int currentFrequency = MIN_FREQUENCY;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentFrequency += 50;
            if (currentFrequency > MAX_FREQUENCY)
                currentFrequency = MAX_FREQUENCY;
            else
                transform.Rotate(0f, 0f, +10f);
            Debug.Log("Current Frequency: " + currentFrequency);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            currentFrequency -= 50;
            if (currentFrequency < MIN_FREQUENCY)
                currentFrequency = MIN_FREQUENCY;
            else 
                transform.Rotate(0f, 0f, -10f);
            Debug.Log("Current Frequency: " + currentFrequency);
        }
    }

    public int GetCurrentFrequency() => currentFrequency;
}
