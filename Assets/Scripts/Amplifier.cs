using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Amplifier : MonoBehaviour
{
    [SerializeField]
    private Generator generator;
    [SerializeField]
    private GainAmplifier gain;
    [SerializeField]
    private AngleHorn horn;
    [SerializeField]
    private Text textValueGain;
    [SerializeField]
    private Text textValueSignal;
    private static float MIN_VALUE_SIGNAL = 0.0f;
    private static float MAX_VALUE_SIGNAL = 100.0f;
    private double simpleSignal;
    private double SimpleSignal
    {
        get { return this.simpleSignal; }
        set 
        {
            if (value < MIN_VALUE_SIGNAL)
                this.simpleSignal = MIN_VALUE_SIGNAL;
            else if (value > MAX_VALUE_SIGNAL)
                this.simpleSignal = MAX_VALUE_SIGNAL;
            else 
                this.simpleSignal = value;
        }
    }


    void Start()
    {
        gain.AddListener(gain => {
            Debug.Log(gain);
            textValueGain.text = gain.ToString();
            ShowCurrentValueSignal();
            Debug.Log(gain);
        });
        generator.AddListener(listener: (gainGenerator, frequencyGenerator) => {
            ShowCurrentValueSignal();
        });
        horn.AddListener(angle => {
            ShowCurrentValueSignal();
        });
    }
    
    public void ShowCurrentValueSignal()
    {
        // For value signal without metall/plastic plate 
        // gainGenerator * gainAmpifilier * cos(AngleHorn)^2 =
        SimpleSignal = Math.Round(
            Math.Pow(Math.Cos((horn.CurrentAngle / 180.0) * Math.PI), 2) * gain.CurrentGain * generator.gain.CurrentGain,
            2);
        textValueSignal.text = SimpleSignal.ToString();
    }
}
