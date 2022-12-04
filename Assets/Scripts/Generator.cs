using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GainGenerator gain;
    public FrequencyGenerator frequency;

    public float GetCurrentGainGenerator() => gain.GetGain();
    public float GetCurrentFrequencyGenerator() => frequency.GetCurrentFrequency();
}
