using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TigerForge;
using TMPro;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class saveManager : MonoBehaviour
{
    private static saveManager instance;

    private GameObject shopSystem;

    public List<SavableObject> SavableObjects { get; private set; }

    public static saveManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<saveManager>();
            }
            return instance;
        }

    }

    EasyFileSave saveData;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        SavableObjects = new List<SavableObject>();
    }

    // Start is called before the first frame update
    void Start()
    {
        saveData = new EasyFileSave("save_file");
    }


    private void Update()
    {
        QuickSave();
        QuickLoad();

        //Debug.Log(GameObject.Find("Money").GetComponent<TextMeshProUGUI>().text);

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

        //Save Money
        saveData.Add("Money", shopSystem.GetComponent<ShopScript>().bankamount);


        saveData.Save();
        Debug.Log("Game Data saved!");

        //BELOW: Save Objects-Loop

        PlayerPrefs.SetInt(Application.loadedLevel.ToString(), SavableObjects.Count);

        for (int i = 0; i < SavableObjects.Count; i++)
        {
            SavableObjects[i].Save(i);
        }
    }
    public void LoadData()
    {
        if (saveData.Load())
        {   //Loading values from Save-File            

            //Load Time& Date
            int currentHour = saveData.GetInt("Current_Hour");
            int currentMinute = saveData.GetInt("Current_Minute");            

            int currentDay = saveData.GetInt("Current_Days");            
            int current_Year = saveData.GetInt("Current_Year");

            //Load Camera Position & Rotation
            Vector3 cameraPosition = saveData.GetUnityVector3("Camera_Position");
            Quaternion cameraRotation = saveData.GetUnityQuaternion("Camera_Rotation");

            //Load Money
            int currentMoney = saveData.GetInt("Money");

            //Feeding Values to Game
            
            EnviroSky.instance.SetTime(current_Year, currentDay, currentHour, currentMinute, 0);
            Time.timeScale = 0f;

            GameObject.Find("MainCameraRig").GetComponent<CameraController>().newPosition = cameraPosition;
            GameObject.Find("MainCameraRig").GetComponent<CameraController>().newRotation = cameraRotation;

            shopSystem = GameObject.Find("ShopManager");
            shopSystem.GetComponent<ShopScript>().bankamount = currentMoney;
            
            saveData.Dispose();

            //BELOW: Load Objects-Loop

            foreach (SavableObject obj in SavableObjects)
            {
                if(obj != null)
                {
                    Destroy(obj.gameObject);
                }
            }

            SavableObjects.Clear();

            int objectCount = PlayerPrefs.GetInt(Application.loadedLevel.ToString());

            for (int i = 0; i < objectCount; i++)
            {
                string[] value = PlayerPrefs.GetString(Application.loadedLevel +"-"+ i.ToString()).Split('_');
                GameObject tmp = null;
                switch (value[0]) //Add different Object Types here too
                {
                    case "Plant":
                       tmp = Instantiate(Resources.Load("Plant") as GameObject);
                        break;
                        
                }

                if(tmp != null)
                {
                    tmp.GetComponent<SavableObject>().Load(value);
                }                                                
            }
        }
        if(saveData.Load() == false)
        {
            Debug.Log("No saved Data");
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

    public Vector3 StringToVector(string value)
    {
        value = value.Trim(new char[] {'(',')'});        
        value = value.Replace(" ", "");       
        string[] pos = value.Split(',');        
        return new Vector3(float.Parse(pos[0])/10f, float.Parse(pos[1]) / 10f, float.Parse(pos[2]) / 10f);        
    }

    public Quaternion StringToQuaternion(string value)
    {
        value = value.Trim(new char[] { '(', ')' });        
        value = value.Replace(" ", "");        
        string[] pos = value.Split(',');
        return new Quaternion(float.Parse(pos[0]) / 10f, float.Parse(pos[1]) / 10f, float.Parse(pos[2]) / 10f, float.Parse(pos[3]) / 10f);
    }
}

