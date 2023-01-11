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
    [SerializeField]
    private AddMetalPlate metalPlate;
    [SerializeField]
    private AddDialecticPlate dialecticPlate;
    [SerializeField]
    private DeleteAllPlate deleteAllPlate;
    private TypeValueSignal currentTypeValueSignal = TypeValueSignal.WITHOUT_PLATE;
    private (double length, double width, double thick) currentSizePLate;
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
        metalPlate.AddListener(listener: (double length, double width, double thick) => {
            currentSizePLate = (length, width, thick);
            currentTypeValueSignal = TypeValueSignal.WITH_METAL_PLATE;
            ShowCurrentValueSignal();
        });
        dialecticPlate.AddListener(listener: (double length, double width, double thick) => {
            currentSizePLate = (length, width, thick);
            currentTypeValueSignal = TypeValueSignal.WITH_DIALECTRIC_PLATE;
            ShowCurrentValueSignal();
        });
        deleteAllPlate.AddListener(delegate {
            currentTypeValueSignal = TypeValueSignal.WITHOUT_PLATE;
            ShowCurrentValueSignal();
        });
    }
    
    public void ShowCurrentValueSignal()
    {
        switch (currentTypeValueSignal){
            case TypeValueSignal.WITHOUT_PLATE: {
                // For value signal without metall/plastic plate 
                // gainGenerator * gainAmpifilier * cos(AngleHorn)^2 =
                SimpleSignal = Math.Round(
                    Math.Pow(Math.Cos((horn.CurrentAngle / 180.0) * Math.PI), 2) * gain.CurrentGain * generator.gain.CurrentGain,
                    2);
                textValueSignal.text = SimpleSignal.ToString();
            }
            break;
            case TypeValueSignal.WITH_METAL_PLATE: {
                
            }
            break;
            case TypeValueSignal.WITH_DIALECTRIC_PLATE: {

            }
            break;
        }
    }

    enum TypeValueSignal
    {
        WITH_METAL_PLATE,
        WITH_DIALECTRIC_PLATE,
        WITHOUT_PLATE
    }
}
