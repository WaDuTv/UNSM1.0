using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TigerForge;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization;


public class saveManager : MonoBehaviour
{
    private static saveManager instance;

    private GameObject shopSystem;
    private GameObject companyManager;

    public GameObject languageCanvas;
    public GameObject languageDropdown;


    public List<SavableObject> SavableObjects { get; private set; }

    public static saveManager Instance { get; private set; }

    EasyFileSave saveData;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        //DontDestroyOnLoad(this);
        SavableObjects = new List<SavableObject>();

        saveData = new EasyFileSave("save_file");
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

    public void SaveLanguage()
    {
        saveData.Add("game_language", GameObject.Find("LanguageDropdown").GetComponent<TMP_Dropdown>().value);
        saveData.Save();
        Debug.Log("Language Setting Saved: " + GameObject.Find("LanguageDropdown").GetComponent<TMP_Dropdown>().value + " @ "+saveData.GetFileName());        
    }

    //public void LoadLanguage()
    //{
    //    if (saveData.Load())
    //    {
    //        int currentLanguage = saveData.GetInt("game_language");
            
    //        Debug.Log("Loaded Language" + currentLanguage);
    //    }


    //}

    public void SaveData()
    {
        //Save Company-Start-Values and Difficulty
        companyManager = GameObject.Find("CompanyManager");
        saveData.Add("Player_Name", companyManager.GetComponent<CompanyManager>().playerName);
        saveData.Add("Company_Name", companyManager.GetComponent<CompanyManager>().companyName);
        saveData.Add("Home_Country", companyManager.GetComponent<CompanyManager>().country);
        saveData.Add("Set_Difficulty", companyManager.GetComponent<CompanyManager>().difficulty);

        //Save Date & Time
        saveData.Add("Current_Hour", EnviroSky.instance.GameTime.Hours);
        saveData.Add("Current_Minute", EnviroSky.instance.GameTime.Minutes);

        saveData.Add("Current_Days", EnviroSky.instance.GameTime.Days);        
        saveData.Add("Current_Year", EnviroSky.instance.GameTime.Years);

        //Save CameraPosition
        saveData.Add("Camera_Position", GameObject.Find("MainCameraRig").transform.position);
        saveData.Add("Camera_Rotation", GameObject.Find("MainCameraRig").transform.rotation);

        //Save Money
        shopSystem = GameObject.Find("ShopManager");
        saveData.Add("Money", shopSystem.GetComponent<ShopScript>().bankamount);
       

        saveData.Save();
        Debug.Log("Game Data saved to: " + saveData.GetFileName());

        //BELOW: Save Objects-Loop

        PlayerPrefs.SetInt("ObjectCount", SavableObjects.Count);

        for (int i = 0; i < SavableObjects.Count; i++)
        {
            SavableObjects[i].Save(i);
            Debug.Log("Saved" + SavableObjects[i].GetComponent<SpecificObject>().cost);
        }
    }
    public void LoadData()
    {
        if (saveData.Load())
        {   //Loading values from Save-File

            //Load Company-Values & Difficulty
            string playerName = saveData.GetString("Player_Name");
            string companyName = saveData.GetString("Company_Name");
            int setCountry = saveData.GetInt("Home_Country");
            int setDifficulty = saveData.GetInt("Set_Difficulty");

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
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                Scene scene = SceneManager.GetSceneAt(i);
                if ((scene.name == "Main"))
                {
                    companyManager = GameObject.Find("CompanyManager");
                    companyManager.GetComponent<CompanyManager>().playerName = playerName;
                    companyManager.GetComponent<CompanyManager>().companyName = companyName;
                    companyManager.GetComponent<CompanyManager>().country = setCountry;

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
                        if (obj != null)
                        {
                            Destroy(obj.gameObject);
                        }
                    }

                    SavableObjects.Clear();

                    int objectCount = PlayerPrefs.GetInt("ObjectCount");

                    for (int o = 0; o < objectCount; o++)
                    {
                        string[] value = PlayerPrefs.GetString(o.ToString()).Split('_');
                        GameObject tmp = null;
                        switch (value[0]) //Add different Object Types here too
                        {

                            case "Plant":
                                tmp = Instantiate(Resources.Load("Plant") as GameObject);
                                Debug.Log(tmp.name);
                                break;
                            case "PlantBig":
                                tmp = Instantiate(Resources.Load("Plant_big") as GameObject);
                                Debug.Log(tmp.name);
                                break;
                        }

                        if (tmp != null)
                        {
                            tmp.GetComponent<SavableObject>().Load(value);
                        }
                    }
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

    public void DisposeData()
    {
        
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
        value = value.Trim(new char[] {'(', ')'});        
        value = value.Replace(" ", "");        
        string[] pos = value.Split(',');
        return new Quaternion(float.Parse(pos[0]) / 10f, float.Parse(pos[1]) / 10f, float.Parse(pos[2]) / 10f, float.Parse(pos[3]) / 10f);
    }
}

