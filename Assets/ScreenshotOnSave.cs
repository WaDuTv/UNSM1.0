using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenshotOnSave : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScreenShotOnSave()
    {
        //ScreenshotHandler.TakeScreenShot_Static(300,300);
        ScreenCapture.CaptureScreenshot("test");
    }
}
