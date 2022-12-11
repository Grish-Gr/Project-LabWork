using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AngleHorn : ActionElement
{
    [SerializeField]
    private Text textValueAngle; 
    private int currentAngle;
    public int CurrentAngle
    {
        get { return this.currentAngle; }
        set 
        {
            var angle = value < 0 ? 360 + value : value;
            angle = angle >= 360 ? angle - 360 : angle;
            this.currentAngle = angle;
            listListeners.ForEach(list => list.Invoke(angle) );
        }
    }
    private List<Listener> listListeners = new List<Listener>();
    public delegate void Listener(int angle);
    public void AddListener(Listener listener)
    {
        listListeners.Add(listener);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X)) { UpValue(); }
        if (Input.GetKeyDown(KeyCode.Z)) { DownValue(); }
    }

    public override void UpValue()
    {
        CurrentAngle += 5;
        textValueAngle.text = CurrentAngle.ToString();
        transform.Rotate(5f, 0f, 0f);
    }

    public override void DownValue()
    {
        CurrentAngle -= 5;
        textValueAngle.text = CurrentAngle.ToString();
        transform.Rotate(-5f, 0f, 0f);
    }
}
