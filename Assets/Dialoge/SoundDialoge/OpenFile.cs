using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class OpenFile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void clickPDF()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "laba.pdf");
        System.Diagnostics.Process.Start(filePath);
    }
}
