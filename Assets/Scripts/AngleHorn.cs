using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleHorn : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            transform.Rotate(5f, 0f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            transform.Rotate(-5f, 0f, 0f);
        }
    }

    public int GetCurrentAngle()
    {
        return Mathf.Abs((int)transform.eulerAngles.x);
    }
}
