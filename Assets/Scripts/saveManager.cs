using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TigerForge;

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
        saveData.Add("Current_Hour", EnviroSky.instance.GameTime.Hours);
        saveData.Add("Current_Minute", EnviroSky.instance.GameTime.Minutes);

        saveData.Add("Current_Days", EnviroSky.instance.GameTime.Days);        
        saveData.Add("Current_Year", EnviroSky.instance.GameTime.Years);

        saveData.Save();
        Debug.Log("Game Data saved!");
    }
    public void LoadData()
    {
        if (saveData.Load())
        {   //Loading values from Save-File
            int currentHour = saveData.GetInt("Current_Hour");
            int currentMinute = saveData.GetInt("Current_Minute");            

            int currentDay = saveData.GetInt("Current_Days");            
            int current_Year = saveData.GetInt("Current_Year");

            //Feeding Values to Game

            EnviroSky.instance.SetTime(current_Year, currentDay, currentHour, currentMinute, 0);

            saveData.Dispose();
            Debug.Log("Loaded the followind Data. Time: " + currentHour + ":" + currentMinute + " ,Date: " + currentDay + "."  + current_Year);
            
        }
    }
}

