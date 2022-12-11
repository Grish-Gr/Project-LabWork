using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainGenerator : ActionElement
{
    public float MinGain;
    public float MaxGain;
    public float StepGain;
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
        CurrentGain = MinGain;
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

/**
public class GainGenerator : ActionElement
{
    public float MinGain;
    public float MaxGain;
    public float StepGain;

    private List<Listener> listListeners = new List<Listener>();
    public delegate void Listener(float value);
    public float currentGain;

    void Start()
    {
        SetCurrentGain(MinGain);
    }
    /**
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            currentGain += StepGain;
            if (currentGain > MaxGain)
                currentGain = MaxGain;
            else
                transform.Rotate(0, 0, 20f);
            Debug.Log("Current Gain Generator: " + currentGain);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            currentGain -= StepGain;
            if (currentGain < MinGain)
                currentGain = MinGain;
            else
                transform.Rotate(0, 0, -20f);
            Debug.Log("Current Gain Generator: " + currentGain);
        }
    }
    

    public void AddListener(Listener listener)
    {
        listListeners.Add(listener);
    }

    public override void UpValue()
    {
        var value = currentGain + StepGain;
        if (currentGain > MaxGain)
            value = MaxGain;
        else
            transform.Rotate(0, 0, 20f);
        SetCurrentGain(value);
    }

    public override void DownValue()
    {
        var value = currentGain - StepGain;
        if (currentGain < MinGain)
            value = MinGain;
        else
            transform.Rotate(0, 0, -20f);
        SetCurrentGain(value);
    }

    public void SetCurrentGain(float value) 
    {
        listListeners.ForEach(list => list.Invoke(value) );
        currentGain = value;
    }
}
**/