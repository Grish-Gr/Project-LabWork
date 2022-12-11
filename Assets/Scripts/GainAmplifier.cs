using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainAmplifier : ActionElement
{
    [SerializeField]
    private float MinGain;
    [SerializeField]
    private float MaxGain;
    [SerializeField]
    private float StepGain;
    private float currentGain;
    public float CurrentGain
    {
        get { return this.currentGain; }
        set 
        {
            this.currentGain = value;
            listListeners.ForEach(list => list.Invoke(value) );
        }
    }
    private List<Listener> listListeners = new List<Listener>();
    public delegate void Listener(float value);

    public void AddListener(Listener listener)
    {
        listListeners.Add(listener);
    }

    void Start()
    {
        currentGain = MinGain;
    }

    public override void UpValue()
    {
        CurrentGain += StepGain;
            if (CurrentGain > MaxGain)
                CurrentGain = MaxGain;
            else
                transform.Rotate(0, 0, 20f);
    }

    public override void DownValue()
    {
        CurrentGain -= StepGain;
            if (CurrentGain < MinGain)
                CurrentGain = MinGain;
            else
                transform.Rotate(0, 0, -20f);
    }
}
