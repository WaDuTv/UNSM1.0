using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TigerForge;
using UnityEngine.InputSystem;

public class saveManager : MonoBehaviour
{
    EasyFileSave saveData;    

    // Start is called before the first frame update
    void Start()
    {
        saveData = new EasyFileSave("save_file");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveData()
    {
        //Save Date & Time
        saveData.Add("Current_Hour", EnviroSky.instance.GameTime.Hours);
        saveData.Add("Current_Minute", EnviroSky.instance.GameTime.Minutes);

        saveData.Add("Current_Days", EnviroSky.instance.GameTime.Days);        
        saveData.Add("Current_Year", EnviroSky.instance.GameTime.Years);

        //Save CameraPosition
        saveData.Add("Camera_Position", GameObject.Find("MainCameraRig").transform.position);
        saveData.Add("Camera_Rotation", GameObject.Find("MainCameraRig").transform.rotation);



        saveData.Save();
        Debug.Log("Game Data saved!");
    }
    public void LoadData()
    {
        if (saveData.Load())
        {   //Loading values from Save-File

            //Load Tame& Date
            int currentHour = saveData.GetInt("Current_Hour");
            int currentMinute = saveData.GetInt("Current_Minute");            

            int currentDay = saveData.GetInt("Current_Days");            
            int current_Year = saveData.GetInt("Current_Year");

            //Load Camera Position & Rotation
            Vector3 cameraPosition = saveData.GetUnityVector3("Camera_Position");
            Quaternion cameraRotation = saveData.GetUnityQuaternion("Camera_Rotation");

            //Feeding Values to Game

            EnviroSky.instance.SetTime(current_Year, currentDay, currentHour, currentMinute, 0);
            Time.timeScale = 0f;

            GameObject.Find("MainCameraRig").GetComponent<CameraController>().newPosition = cameraPosition;
            GameObject.Find("MainCameraRig").GetComponent<CameraController>().newRotation = cameraRotation;
            


            saveData.Dispose();
            Debug.Log("Loaded the followind Data. Time: " + currentHour + ":" + currentMinute + " ,Date: " + currentDay + "."  + current_Year);
            
        }
    }

    public void QuickSave()
    {
        if (Input.GetKey(KeyCode.F5))
        {
            SaveData();
        }
    }

    public void QuickLoad()
    {
        if (Input.GetKey(KeyCode.F6))
        {
            LoadData();
        }
    }
}

