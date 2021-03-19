using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenshotHandler : MonoBehaviour
{
    private static ScreenshotHandler instance;

    public Camera myCamera;
    private bool takeScreenshotOnNextFrame;

    public SaveLoadManager slm;

    private void Awake()
    {        
        instance = this;
        myCamera = Camera.main;
        System.IO.Directory.CreateDirectory(Application.persistentDataPath + "/Screens4save");
    }

    private void OnPostRender()
    {
        if(takeScreenshotOnNextFrame)
        {            
            takeScreenshotOnNextFrame = false;
            RenderTexture renderTexture = myCamera.targetTexture;

            Texture2D renderResult = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
            Rect rect = new Rect(0, 0, renderTexture.width, renderTexture.height);
            renderResult.ReadPixels(rect, 0, 0);

            byte[] byteArray = renderResult.EncodeToPNG();
            System.IO.File.WriteAllBytes(Application.persistentDataPath + "/Screens4save/"+ slm.GetComponent<SaveLoadManager>().saveName.text + ".png", byteArray);
            Debug.Log("Saved Screenshot");

            RenderTexture.ReleaseTemporary(renderTexture);
            myCamera.targetTexture = null;
        }
    }
    private void TakeScreenshot(int width, int height)
    {
        myCamera.targetTexture = RenderTexture.GetTemporary(width, height, 16);
        takeScreenshotOnNextFrame = true;
    }

    public static void TakeScreenShot_Static (int width, int height)
    {
        instance.TakeScreenshot(width, height);
    }
}
