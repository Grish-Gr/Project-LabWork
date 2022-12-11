using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Generator : MonoBehaviour
{
    public GainGenerator gain;
    public FrequencyGenerator frequency;
    [SerializeField]
    private Text textValueGain;
    [SerializeField]
    private Text textValueFrequency; 
    private List<Listener> listListeners = new List<Listener>();
    public delegate void Listener(float gain, int frequency);
    public void AddListener(Listener listener)
    {
        listListeners.Add(listener);
    }

    void Start()
    {
        gain.AddListener(val => {
            textValueGain.text = val.ToString();
            listListeners.ForEach(listener => 
                listener.Invoke(val, frequency.CurrentFrequency)
            );
            Debug.Log(val);
        });
        frequency.AddListener(val => {
            textValueFrequency.text = val.ToString();
            listListeners.ForEach(listener => 
                listener.Invoke(gain.CurrentGain, val)
            );
            Debug.Log(val);
        });
    }

    internal void AddListener(Action<object, object> value)
    {
        throw new NotImplementedException();
    }
}
