using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameSpeed : MonoBehaviour
{

    private static float pause;
    public static float normal;
    public static float ddouble;
    public static float ultra;

    public static float timeFactor;

    public static bool isPause;
    public static bool isnormal;
    public static bool isddouble;
    public static bool isultra;

    public void DetermineTimeFactor()
    {
        if(isPause == true)
        {
            timeFactor = 0;
        }
        if (isnormal == true)
        {
            timeFactor = 0;
        }
        if (isddouble == true)
        {
            timeFactor = 2;
        }
        if (isultra == true)
        {
            timeFactor = 10;
        }
    }

    public  void PauseSpeed()
    {
        Time.timeScale = 0f;
        isPause = true;
        isnormal = false;
        isddouble = false;
        isultra = false;
        Debug.Log("GameTime Paused");
    }
           
    public static void NormalSpeed()
    {
        Time.timeScale = 1f;
        isPause = false;
        isnormal = true;
        isddouble = false;
        isultra = false;
        Debug.Log("Time goes now at " + Time.timeScale + "x Speed");
    }

    public static void DoubleSpeed()
    {
        Time.timeScale = 2f;
        isPause = false;
        isnormal = false;
        isddouble = true;
        isultra = false;
        Debug.Log("Time goes now at " + Time.timeScale + "x Speed");
    }

    public static void UltraSpeed()
    {
        Time.timeScale = 10f;
        isPause = false;
        isnormal = false;
        isddouble = false;
        isultra = true;
        Debug.Log("Time goes now at " + Time.timeScale + "x Speed");
    }
}
