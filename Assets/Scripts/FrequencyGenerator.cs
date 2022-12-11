using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrequencyGenerator : ActionElement
{
    public const int MIN_FREQUENCY = 8000;
    public const int MAX_FREQUENCY = 10000;
    [SerializeField]
    private int stepFrequency = 10;
    private int currentFrequency;
    public int CurrentFrequency
    {
        get { return this.currentFrequency; }
        set 
        { 
            this.currentFrequency = value;
            listListeners.ForEach(listener => listener.Invoke(value) );
        }
    }
    private List<Listener> listListeners = new List<Listener>();
    public delegate void Listener(int value);

    public void AddListener(Listener listener)
    {
        listListeners.Add(listener);
    }

    void Start()
    {
        CurrentFrequency =  MIN_FREQUENCY;
    }

    public override void UpValue()
    {
        CurrentFrequency += stepFrequency;
            if (CurrentFrequency > MAX_FREQUENCY)
                CurrentFrequency = MAX_FREQUENCY;
            else
                transform.Rotate(0f, 0f, +10f);
    }

    public override void DownValue()
    {
        CurrentFrequency -= stepFrequency;
            if (CurrentFrequency < MIN_FREQUENCY)
                CurrentFrequency = MIN_FREQUENCY;
            else 
                transform.Rotate(0f, 0f, -10f);
    }
}
