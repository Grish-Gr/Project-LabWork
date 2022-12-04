using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amplifier : MonoBehaviour
{
    public Generator generator;
    public GainAmplifier gain;
    public AngleHorn horn;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Current Signal = " + getValueSignal());
        }
    }
    
    public float getValueSignal()
    {
        // Формула для установки, где нет пластин в рупоре
        var simpleSignal = Mathf.Acos((horn.GetCurrentAngle() / 360) * 2 * Mathf.PI);
        simpleSignal = simpleSignal * simpleSignal * generator.GetCurrentGainGenerator() * gain.GetGain();
        return simpleSignal;
    }
}
