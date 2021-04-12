using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TigerForge;
using TMPro;
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

    public TMP_InputField saveName;

    public GameObject HiredStaffContainer;

    public GameObject activeProjectsContainer;
    public GameObject myFinishedGamesContainer;


    public GameObject workerPrefab;
    public Transform workerPrefabParent;

    public GameObject projectsPrefab;
    public Transform activeProjectsParent;
    public Transform finishedProjectsParent;

    public List<SavableObject> SavableObjects { get; private set; }
    public List<string> hiredWorkers;
    public List<string> activeProjectsList;
    public List<string> finishedProjectsList;

    public static saveManager Instance { get; private set; }

    public EasyFileSave saveData;

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

        //saveData = new EasyFileSave("save_file");
    }

    // Start is called before the first frame update
    void Start()
    {
        
        //saveData = new EasyFileSave("save_file");
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


    public void SaveData()
    {
        if(GameObject.FindGameObjectWithTag("SaveNameInputField").GetComponent<TMP_InputField>() != null)
        { 
        saveName = GameObject.FindGameObjectWithTag("SaveNameInputField").GetComponent<TMP_InputField>();
        }
        saveData = new EasyFileSave(saveName.text);

        //Save latest Savefile Name
        saveData.Add("latestSaveName", saveName.text);

        //Save Company-Start-Values and Difficulty
        companyManager = GameObject.Find("CompanyManager");
        if (companyManager != null)
        {
            saveData.Add("Player_Name", companyManager.GetComponent<CompanyManager>().playerName);
            saveData.Add("Company_Name", companyManager.GetComponent<CompanyManager>().companyName);
            saveData.Add("Home_Country", companyManager.GetComponent<CompanyManager>().country);
            saveData.Add("Set_Difficulty", companyManager.GetComponent<CompanyManager>().difficulty);
        }

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

        //Save Hired Staff and Status/Stats
        HiredStaffContainer = GameObject.Find("CompanyStaff");
        hiredWorkers = new List<string>();        
        Transform[] workers = HiredStaffContainer.GetComponentsInChildren<Transform>();        

        foreach (Transform worker in workers)
        {
            StaffHandler sh = worker.gameObject.GetComponent<StaffHandler>();
            if (worker != null && worker.gameObject != null && worker.gameObject != HiredStaffContainer)
            {
                Debug.Log(worker);
                saveData.Add("Worker CharacterPrefab_" + sh.firstName + "_" + sh.lastName, sh.workerModelprefabIndex);
                saveData.Add("Worker CharacterPrefabMaterial_" + sh.firstName + "_" + sh.lastName, sh.workerMaterialIndex);

                saveData.Add("Worker First Name_"+ sh.firstName+"_"+sh.lastName, sh.firstName);
                saveData.Add("Worker Last Name_" + sh.firstName + "_" + sh.lastName, sh.lastName);
                saveData.Add("Worker Profession_" + sh.firstName + "_" + sh.lastName, sh.workerProfession);

                saveData.Add("Worker ID_" + sh.firstName + "_" + sh.lastName, sh.workerID);
                saveData.Add("Worker IDIsSet_" + sh.firstName + "_" + sh.lastName, sh.workerIDSet);

                saveData.Add("Worker Stat Programming_" + sh.firstName + "_" + sh.lastName, sh.workerStatProgramming);
                saveData.Add("Worker Stat Sound_" + sh.firstName + "_" + sh.lastName, sh.workerStatSound);
                saveData.Add("Worker Stat Graphics_" + sh.firstName + "_" + sh.lastName, sh.workerStatGraphics);
                saveData.Add("Worker Stat Design_" + sh.firstName + "_" + sh.lastName, sh.workerStatDesign);

                saveData.Add("Worker assigned Project_" + sh.firstName + "_" + sh.lastName, sh.assignedProjectName);
                saveData.Add("Worker is available_" + sh.firstName + "_" + sh.lastName, sh.isAvailable);
                saveData.Add("Worker is asigned_" + sh.firstName + "_" + sh.lastName, sh.isAssignedToProject);                

                hiredWorkers.Add(sh.firstName + "_" + sh.lastName);
            }

            
        }

        saveData.Add("HiredWorkersList", hiredWorkers);

        //Save current active Projects
        activeProjectsContainer = GameObject.Find("CurrentActiveProjects");
        Transform[] activeProjects = activeProjectsContainer.GetComponentsInChildren<Transform>();

        foreach (Transform activeProject in activeProjects)
        {
            if (activeProject != null && activeProject.gameObject != null && activeProject.gameObject != activeProjectsContainer)
            {
                var gameName = activeProject.gameObject.GetComponent<ProjectInDevelopment>().projectName;
                var gameDetails = activeProject.gameObject.GetComponent<ProjectInDevelopment>();

                saveData.Add("ActiveGame_Name_" + gameName, gameName);
                saveData.Add("ActiveGame_MainGenre_" + gameName, gameDetails.mainGenre);
                saveData.Add("ActiveGame_SubGenre_" + gameName, gameDetails.subGenre);
                saveData.Add("ActiveGame_Theme_" + gameName, gameDetails.Theme);
                saveData.Add("ActiveGame_Gamesize_" + gameName, gameDetails.gameSize);
                saveData.Add("ActiveGame_TargetAudience_" + gameName, gameDetails.targetAudience);

                saveData.Add("ActiveGame_setGraphics_" + gameName, gameDetails.setGraphics);
                saveData.Add("ActiveGame_setSound_" + gameName, gameDetails.setSound);
                saveData.Add("ActiveGame_setGameplay_" + gameName, gameDetails.setGameplay);
                saveData.Add("ActiveGame_setContent_" + gameName, gameDetails.setContent);
                saveData.Add("ActiveGame_setControls_" + gameName, gameDetails.setControls);

                saveData.Add("ActiveGame_setPrice_" + gameName, gameDetails.setPrice);
                saveData.Add("ActiveGame_DefaultPrice_" + gameName, gameDetails.defaultPrice);

                saveData.Add("ActiveGame_setDevelopmentTime_" + gameName, gameDetails.setDevelopmentTime);

                saveData.Add("ActiveGame_optimumGraphics_" + gameName, gameDetails.optimumGraphics);
                saveData.Add("ActiveGame_optimumSound_" + gameName, gameDetails.optimumSound);
                saveData.Add("ActiveGame_optimumGameplay_" + gameName, gameDetails.optimumGameplay);
                saveData.Add("ActiveGame_optimumContent_" + gameName, gameDetails.optimumContent);
                saveData.Add("ActiveGame_optimumControls_" + gameName, gameDetails.optimumControls);

                saveData.Add("ActiveGame_optimumDevlopmentTime_" + gameName, gameDetails.optimumDevelopmentTime);

                saveData.Add("ActiveGame_StartDay_" + gameName, gameDetails.startDay);
                saveData.Add("ActiveGame_StartYear_" + gameName, gameDetails.startYear);

                saveData.Add("ActiveGame_EndDay_" + gameName, gameDetails.endDay);
                saveData.Add("ActiveGame_EndYear_" + gameName, gameDetails.endYear);

                saveData.Add("ActiveGame_SendAwayDay_" + gameName, gameDetails.sendAwayDay);
                saveData.Add("ActiveGame_SendAwayYear_" + gameName, gameDetails.sendAwayYear);

                saveData.Add("ActiveGame_ReviewDay_" + gameName, gameDetails.reviewDay);
                saveData.Add("ActiveGame_ReviewYear_" + gameName, gameDetails.reviewYear);

                saveData.Add("ActiveGame_isFinished_" + gameName, gameDetails.isFinished);
                saveData.Add("ActiveGame_isRated_" + gameName, gameDetails.isRated);
                saveData.Add("ActiveGame_hasBennSent_" + gameName, gameDetails.hasBeenSent);

                saveData.Add("ActiveGame_AssignedStaffList_" + gameName, gameDetails.assignedStaff);

                activeProjectsList.Add(gameName);
            }
        }

        saveData.Add("ActiveGamesList", activeProjectsList);

        //Save my finished Games
        myFinishedGamesContainer = GameObject.Find("MyFinishedGames");
        Transform[] finishedGames = myFinishedGamesContainer.GetComponentsInChildren<Transform>();

        foreach (Transform finishedGame in finishedGames)
        {
            if (finishedGame != null && finishedGame.gameObject != null && finishedGame.gameObject != myFinishedGamesContainer)
            {
                var gameName = finishedGame.gameObject.GetComponent<ProjectInDevelopment>().projectName;
                var gameDetails = finishedGame.gameObject.GetComponent<ProjectInDevelopment>();
                var scoreDetails = finishedGame.gameObject.GetComponent<CalculateGameScore>();

                saveData.Add("FinishedGame_Name_" + gameName, gameName);
                saveData.Add("FinishedGame_MainGenre_" + gameName, gameDetails.mainGenre);
                saveData.Add("FinishedGame_SubGenre_" + gameName, gameDetails.subGenre);
                saveData.Add("FinishedGame_Theme_" + gameName, gameDetails.Theme);
                saveData.Add("FinishedGame_Gamesize_" + gameName, gameDetails.gameSize);
                saveData.Add("FinishedGame_TargetAudience_" + gameName, gameDetails.targetAudience);

                saveData.Add("FinishedGame_setGraphics_" + gameName, gameDetails.setGraphics);
                saveData.Add("FinishedGame_setSound_" + gameName, gameDetails.setSound);
                saveData.Add("FinishedGame_setGameplay_" + gameName, gameDetails.setGameplay);
                saveData.Add("FinishedGame_setContent_" + gameName, gameDetails.setContent);
                saveData.Add("FinishedGame_setControls_" + gameName, gameDetails.setControls);

                saveData.Add("FinishedGame_setPrice_" + gameName, gameDetails.setPrice);
                saveData.Add("FinishedGame_DefaultPrice_" + gameName, gameDetails.defaultPrice);

                saveData.Add("FinishedGame_setDevelopmentTime_" + gameName, gameDetails.setDevelopmentTime);

                saveData.Add("FinishedGame_optimumGraphics_" + gameName, gameDetails.optimumGraphics);
                saveData.Add("FinishedGame_optimumSound_" + gameName, gameDetails.optimumSound);
                saveData.Add("FinishedGame_optimumGameplay_" + gameName, gameDetails.optimumGameplay);
                saveData.Add("FinishedGame_optimumContent_" + gameName, gameDetails.optimumContent);
                saveData.Add("FinishedGame_optimumControls_" + gameName, gameDetails.optimumControls);

                saveData.Add("FinishedGame_optimumDevlopmentTime_" + gameName, gameDetails.optimumDevelopmentTime);

                saveData.Add("FinishedGame_StartDay_" + gameName, gameDetails.startDay);
                saveData.Add("FinishedGame_StartYear_" + gameName, gameDetails.startYear);

                saveData.Add("FinishedGame_EndDay_" + gameName, gameDetails.endDay);
                saveData.Add("FinishedGame_EndYear_" + gameName, gameDetails.endYear);

                saveData.Add("FinishedGame_SendAwayDay_" + gameName, gameDetails.sendAwayDay);
                saveData.Add("FinishedGame_SendAwayYear_" + gameName, gameDetails.sendAwayYear);

                saveData.Add("FinishedGame_ReviewDay_" + gameName, gameDetails.reviewDay);
                saveData.Add("FinishedGame_ReviewYear_" + gameName, gameDetails.reviewYear);

                saveData.Add("FinishedGame_isFinished_" + gameName, gameDetails.isFinished);
                saveData.Add("FinishedGame_isRated_" + gameName, gameDetails.isRated);
                saveData.Add("FinishedGame_hasBennSent_" + gameName, gameDetails.hasBeenSent);

                saveData.Add("FinishedGame_AssignedStaffList_" + gameName, gameDetails.assignedStaff);
                
                saveData.Add("FinishedGame_TotalAmountOfStaff_" + gameName, scoreDetails.totalAmountoffStaffMembers);
                
                saveData.Add("FinishedGame_staffTotalProgramming_" + gameName, scoreDetails.staffTotalProgramming);
                saveData.Add("FinishedGame_staffTotalSound_" + gameName, scoreDetails.staffTotalSound);
                saveData.Add("FinishedGame_staffTotalGraphics_" + gameName, scoreDetails.staffTotalGraphics);
                saveData.Add("FinishedGame_staffTotalDesign_" + gameName, scoreDetails.staffTotalDesign);

                saveData.Add("FinishedGame_staffAverageProgramming_" + gameName, scoreDetails.staffAverageProgramming);
                saveData.Add("FinishedGame_staffAverageSound_" + gameName, scoreDetails.staffAverageSound);
                saveData.Add("FinishedGame_staffAverageGraphics_" + gameName, scoreDetails.staffAverageGraphics);
                saveData.Add("FinishedGame_staffAverageDesign_" + gameName, scoreDetails.staffAverageDesign);

                saveData.Add("FinishedGame_maxGraphics_" + gameName, scoreDetails.maxGraphics);
                saveData.Add("FinishedGame_maxSound_" + gameName, scoreDetails.maxSound);
                saveData.Add("FinishedGame_maxGampelay_" + gameName, scoreDetails.maxGameplay);
                saveData.Add("FinishedGame_maxContent_" + gameName, scoreDetails.maxContent);
                saveData.Add("FinishedGame_maxControls_" + gameName, scoreDetails.maxControls);
                saveData.Add("FinishedGame_optimumSum_" + gameName, scoreDetails.optimumSum);

                saveData.Add("FinishedGame_setGraphics_" + gameName, scoreDetails.setGraphics);
                saveData.Add("FinishedGame_setSound_" + gameName, scoreDetails.setSound);
                saveData.Add("FinishedGame_setGameplay_" + gameName, scoreDetails.setGameplay);
                saveData.Add("FinishedGame_seticContent_" + gameName, scoreDetails.setContent);
                saveData.Add("FinishedGame_setControls_" + gameName, scoreDetails.setControls);

                saveData.Add("FinishedGame_staffList_" + gameName, scoreDetails.staffList);

                saveData.Add("FinishedGame_graphicsScore_" + gameName, scoreDetails.graphicsScore);
                saveData.Add("FinishedGame_soundScore_" + gameName, scoreDetails.soundScore);
                saveData.Add("FinishedGame_gameplayScore_" + gameName, scoreDetails.gameplayScore);
                saveData.Add("FinishedGame_contentScore_" + gameName, scoreDetails.contentScore);
                saveData.Add("FinishedGame_controlsScore_" + gameName, scoreDetails.controlsScore);

                saveData.Add("FinishedGame_baseScore_" + gameName, scoreDetails.baseScore);
                saveData.Add("FinishedGame_priceRatio_" + gameName, scoreDetails.priceRatio);
                saveData.Add("FinishedGame_finalScore_" + gameName, scoreDetails.finalScore);

                finishedProjectsList.Add(gameName);
            }
        }

        saveData.Add("MyFinishedGamesList", finishedProjectsList);


        //Save Objects
        saveData.Add("ObjectCount", SavableObjects.Count);

        for (int i = 0; i < SavableObjects.Count; i++)
        {
            SavableObjects[i].Save(i);
            Debug.Log("Saved" + SavableObjects[i].GetComponent<SpecificObject>().cost);
        }

        saveData.Save();
        Debug.Log("Game Data saved to: " + saveData.GetFileName());

        //BELOW: Save Objects-Loop
        
        //PlayerPrefs.SetInt("ObjectCount"+saveName, SavableObjects.Count);

        
    }
    public void LoadData(string saveName)
    {
        
        saveData = new EasyFileSave(saveName);
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

            //Load Hired Workers and Status/Stats
            List<string> currentHiredWorkers = saveData.GetList<string>("HiredWorkersList");
            workerPrefabParent = GameObject.Find("CompanyStaff").transform;

            foreach (string worker in currentHiredWorkers)
            {
                int workerPrefabIndex = saveData.GetInt("Worker CharacterPrefab_" + worker);
                int workerMaterialIndex = saveData.GetInt("Worker CharacterPrefabMaterial_" + worker);

                string workerFirstName = saveData.GetString("Worker First Name_" + worker);
                string workerLastName = saveData.GetString("Worker Last Name_" + worker);
                string workerProfession = saveData.GetString("Worker Profession_" + worker);

                float workerID = saveData.GetFloat("Worker ID_" + worker);
                bool workerIDSet = saveData.GetBool("Worker IDIsSet_" + worker);

                int workerStatProgramming = saveData.GetInt("Worker Stat Programming_" + worker);
                int workerStatSound = saveData.GetInt("Worker Stat Sound_" + worker);
                int workerStatGraphics = saveData.GetInt("Worker Stat Graphics_" + worker);
                int workerStatDesign = saveData.GetInt("Worker Stat Design_" + worker);

                string workerAssignedProject = saveData.GetString("Worker assigned Project_" + worker);

                bool workerIsAvailable = saveData.GetBool("Worker is available_" + worker);
                bool workerIsAssigned = saveData.GetBool("Worker is assigned_" + worker);

                //Instantiate hired Workers
                if (GameObject.Find("worker_" + workerFirstName + " " + workerLastName) == null)
                { 
                    GameObject newWorker = Instantiate(workerPrefab, workerPrefabParent);
                    StaffHandler sh = newWorker.GetComponent<StaffHandler>();

                    sh.workerModelprefabIndex = workerPrefabIndex;
                    sh.workerMaterialIndex = workerMaterialIndex;

                    sh.firstName = workerFirstName;
                    sh.lastName = workerLastName;
                    sh.workerProfession = workerProfession;

                    sh.workerID = workerID;
                    sh.workerIDSet = workerIDSet;

                    sh.workerStatProgramming = workerStatProgramming;
                    sh.workerStatSound = workerStatSound;
                    sh.workerStatGraphics = workerStatGraphics;
                    sh.workerStatDesign = workerStatDesign;

                    sh.assignedProjectName = workerAssignedProject;

                    sh.isAvailable = workerIsAvailable;
                    sh.isAssignedToProject = workerIsAssigned;

                    newWorker.gameObject.name = "worker_" + workerFirstName + " " + workerLastName;
                }
                if (GameObject.Find("worker_" + workerFirstName + " " + workerLastName) != null)
                {
                    GameObject existingWorker = GameObject.Find("worker_" + workerFirstName + " " + workerLastName);
                    StaffHandler sh = existingWorker.GetComponent<StaffHandler>();

                    sh.workerStatProgramming = workerStatProgramming;
                    sh.workerStatSound = workerStatSound;
                    sh.workerStatGraphics = workerStatGraphics;
                    sh.workerStatDesign = workerStatDesign;

                    sh.assignedProjectName = workerAssignedProject;

                    sh.isAvailable = workerIsAvailable;
                    sh.isAssignedToProject = workerIsAssigned;
                }
            }


            //Load active Projects
            List<string> currentActiveProjects = saveData.GetList<string>("ActiveGamesList");
            activeProjectsParent = GameObject.Find("CurrentActiveProjects").transform;

            foreach (string activeProject in currentActiveProjects)
            {
                string _gameName = saveData.GetString("ActiveGame_Name_" + activeProject);
                string _mainGenre = saveData.GetString("ActiveGame_MainGenre_" + activeProject);
                string _subGenre = saveData.GetString("ActiveGame_SubGenre_" + activeProject);
                string _theme = saveData.GetString("ActiveGame_Theme_" + activeProject);
                string _gameSize = saveData.GetString("ActiveGame_Gamesize_" + activeProject);
                string _targetAudience = saveData.GetString("ActiveGame_TargetAudience_" + activeProject);

                float _setGraphics = saveData.GetFloat("ActiveGame_setGraphics_" + activeProject);
                float _setSound = saveData.GetFloat("ActiveGame_setSound_" + activeProject);
                float _setGameplay = saveData.GetFloat("ActiveGame_setGameplay_" + activeProject);
                float _setContent = saveData.GetFloat("ActiveGame_setContent_" + activeProject);
                float _setControls = saveData.GetFloat("ActiveGame_setControls_" + activeProject);

                int _setPrice = saveData.GetInt("ActiveGame_setPrice_" + activeProject);
                int _defaultPrice = saveData.GetInt("ActiveGame_DefaultPrice_" + activeProject);

                float _setDevelopmentTime = saveData.GetFloat("ActiveGame_setDevelopmentTime_" + activeProject);

                float _optimumGraphics = saveData.GetFloat("ActiveGame_optimumGraphics_" + activeProject);
                float _optimumSound = saveData.GetFloat("ActiveGame_optimumSound_" + activeProject);
                float _optimumGameplay = saveData.GetFloat("ActiveGame_optimumGameplay_" + activeProject);
                float _optimumContent = saveData.GetFloat("ActiveGame_optimumContent_" + activeProject);
                float _optimumControls = saveData.GetFloat("ActiveGame_optimumControls_" + activeProject);

                float _optimumDevelopmentTime = saveData.GetFloat("ActiveGame_optimumDevlopmentTime_" + activeProject);

                int _startDay = saveData.GetInt("ActiveGame_StartDay_" + activeProject);
                int _startYear = saveData.GetInt("ActiveGame_StartYear_" + activeProject);

                int _endDay = saveData.GetInt("ActiveGame_EndDay_" + activeProject);
                int _endYear = saveData.GetInt("ActiveGame_EndYear_" + activeProject);

                int _sendAwayDay = saveData.GetInt("ActiveGame_SendAwayDay_" + activeProject);
                int _sendAwayYear = saveData.GetInt("ActiveGame_SendAwayYear_" + activeProject);

                int _reviewDay = saveData.GetInt("ActiveGame_ReviewDay_" + activeProject);
                int _reviewYear = saveData.GetInt("ActiveGame_ReviewYear_" + activeProject);

                bool _isFinished = saveData.GetBool("ActiveGame_isFinished_" + activeProject);
                bool _isRated = saveData.GetBool("ActiveGame_isRated_" + activeProject);
                bool _hasBeenSent = saveData.GetBool("ActiveGame_hasBennSent_" + activeProject);

                List<string> _assignedStaffList = saveData.GetList<string>("ActiveGame_AssignedStaffList_" + activeProject);

                //Instantiate active Projects
                if(GameObject.Find(_gameName) == null)
                {
                    GameObject _activeProject = Instantiate(projectsPrefab, activeProjectsParent);
                    _activeProject.gameObject.name = _gameName;
                    ProjectInDevelopment _pid = _activeProject.GetComponent<ProjectInDevelopment>();

                    _pid.projectName = _gameName;
                    _pid.mainGenre = _mainGenre;
                    _pid.subGenre = _subGenre;
                    _pid.Theme = _theme;
                    _pid.gameSize = _gameSize;
                    _pid.targetAudience = _targetAudience;

                    _pid.setGraphics = _setGraphics;
                    _pid.setSound = _setSound;
                    _pid.setGameplay = _setGameplay;
                    _pid.setContent = _setContent;
                    _pid.setControls = _setControls;

                    _pid.setPrice = _setPrice;
                    _pid.defaultPrice = _defaultPrice;

                    _pid.setDevelopmentTime = _setDevelopmentTime;

                    _pid.optimumGraphics = _optimumGraphics;
                    _pid.optimumSound = _optimumSound;
                    _pid.optimumGameplay = _optimumGameplay;
                    _pid.optimumContent = _optimumContent;
                    _pid.optimumControls = _optimumControls;

                    _pid.optimumDevelopmentTime = _optimumDevelopmentTime;

                    _pid.startDay = _startDay;
                    _pid.startYear = _startYear;

                    _pid.endDay = _endDay;
                    _pid.endYear = _endYear;

                    _pid.sendAwayDay = _sendAwayDay;
                    _pid.sendAwayYear = _sendAwayYear;

                    _pid.reviewDay = _reviewDay;
                    _pid.reviewYear = _reviewYear;

                    _pid.isFinished = _isFinished;
                    _pid.isRated = _isRated;
                    _pid.hasBeenSent = _hasBeenSent;
                }

            }

            //Load finished Projects
            List<string> currentFinishedProjects = saveData.GetList<string>("MyFinishedGamesList");
            finishedProjectsParent = GameObject.Find("MyFinishedGames").transform;

            foreach (string finishedProject in currentFinishedProjects)
            {
                string _gameName = saveData.GetString("FinishedGame_Name_" + finishedProject);
                string _mainGenre = saveData.GetString("FinishedGame_MainGenre_" + finishedProject);
                string _subGenre = saveData.GetString("FinishedGame_SubGenre_" + finishedProject);
                string _theme = saveData.GetString("FinishedGame_Theme_" + finishedProject);
                string _gameSize = saveData.GetString("FinishedGame_Gamesize_" + finishedProject);
                string _targetAudience = saveData.GetString("FinishedGame_TargetAudience_" + finishedProject);

                float _setGraphics = saveData.GetFloat("FinishedGame_setGraphics_" + finishedProject);
                float _setSound = saveData.GetFloat("FinishedGame_setSound_" + finishedProject);
                float _setGameplay = saveData.GetFloat("FinishedGame_setGameplay_" + finishedProject);
                float _setContent = saveData.GetFloat("FinishedGame_setContent_" + finishedProject);
                float _setControls = saveData.GetFloat("FinishedGame_setControls_" + finishedProject);

                int _setPrice = saveData.GetInt("FinishedGame_setPrice_" + finishedProject);
                int _defaultPrice = saveData.GetInt("FinishedGame_DefaultPrice_" + finishedProject);

                float _setDevelopmentTime = saveData.GetFloat("FinishedGame_setDevelopmentTime_" + finishedProject);

                float _optimumGraphics = saveData.GetFloat("FinishedGame_optimumGraphics_" + finishedProject);
                float _optimumSound = saveData.GetFloat("FinishedGame_optimumSound_" + finishedProject);
                float _optimumGameplay = saveData.GetFloat("FinishedGame_optimumGameplay_" + finishedProject);
                float _optimumContent = saveData.GetFloat("FinishedGame_optimumContent_" + finishedProject);
                float _optimumControls = saveData.GetFloat("FinishedGame_optimumControls_" + finishedProject);

                float _optimumDevelopmentTime = saveData.GetFloat("FinishedGame_optimumDevlopmentTime_" + finishedProject);

                int _startDay = saveData.GetInt("FinishedGame_StartDay_" + finishedProject);
                int _startYear = saveData.GetInt("FinishedGame_StartYear_" + finishedProject);

                int _endDay = saveData.GetInt("FinishedGame_EndDay_" + finishedProject);
                int _endYear = saveData.GetInt("FinishedGame_EndYear_" + finishedProject);

                int _sendAwayDay = saveData.GetInt("FinishedGame_SendAwayDay_" + finishedProject);
                int _sendAwayYear = saveData.GetInt("FinishedGame_SendAwayYear_" + finishedProject);

                int _reviewDay = saveData.GetInt("FinishedGame_ReviewDay_" + finishedProject);
                int _reviewYear = saveData.GetInt("FinishedGame_ReviewYear_" + finishedProject);

                bool _isFinished = saveData.GetBool("FinishedGame_isFinished_" + finishedProject);
                bool _isRated = saveData.GetBool("FinishedGame_isRated_" + finishedProject);
                bool _hasBeenSent = saveData.GetBool("FinishedGame_hasBennSent_" + finishedProject);

                List<string> _assignedStaffList = saveData.GetList<string>("FinishedGame_AssignedStaffList_" + finishedProject);

                float _totalAmountOfStaff = saveData.GetFloat("FinishedGame_TotalAmountOfStaff_" + finishedProject);

                int _staffTotalProgramming = saveData.GetInt("FinishedGame_staffTotalProgramming_" + finishedProject);
                int _staffTotalSound = saveData.GetInt("FinishedGame_staffTotalSound_" + finishedProject);
                int _staffTotalGraphics = saveData.GetInt("FinishedGame_staffTotalGraphics_" + finishedProject);
                int _staffTotalDesign = saveData.GetInt("FinishedGame_staffTotalDesign_" + finishedProject);

                float _staffAverageProgramming = saveData.GetFloat("FinishedGame_staffAverageProgramming_" + finishedProject);
                float _staffAverageSound = saveData.GetFloat("FinishedGame_staffAverageSound_" + finishedProject);
                float _staffAverageGraphics = saveData.GetFloat("FinishedGame_staffAverageGraphics_" + finishedProject);
                float _staffAvergaeDesign = saveData.GetFloat("FinishedGame_staffAverageDesign_" + finishedProject);

                float _maxGraphics = saveData.GetFloat("FinishedGame_maxGraphics_" + finishedProject);
                float _maxSound = saveData.GetFloat("FinishedGame_maxSound_" + finishedProject);
                float _maxGameplay = saveData.GetFloat("FinishedGame_maxGampelay_" + finishedProject);
                float _maxContent = saveData.GetFloat("FinishedGame_maxContent_" + finishedProject);
                float _maxControls = saveData.GetFloat("FinishedGame_maxControls_" + finishedProject);
                float _optimumSum = saveData.GetFloat("FinishedGame_optimumSum_" + finishedProject);

                float _reachedGraphics = saveData.GetFloat("FinishedGame_setGraphics_" + finishedProject);
                float _reachedSound = saveData.GetFloat("FinishedGame_setSound_" + finishedProject);
                float _reachedGameplay = saveData.GetFloat("FinishedGame_setGameplay_" + finishedProject);
                float _reachedContent = saveData.GetFloat("FinishedGame_seticContent_" + finishedProject);
                float _reachedControls = saveData.GetFloat("FinishedGame_setControls_" + finishedProject);

                List<string> _staffList = saveData.GetList<string>("FinishedGame_staffList_" + finishedProject);

                float _graphicsScore = saveData.GetFloat("FinishedGame_graphicsScore_" + finishedProject);
                float _soundScore = saveData.GetFloat("FinishedGame_soundScore_" + finishedProject);
                float _gameplayScore = saveData.GetFloat("FinishedGame_gameplayScore_" + finishedProject);
                float _contentScore = saveData.GetFloat("FinishedGame_contentScore_" + finishedProject);
                float _controlsScore = saveData.GetFloat("FinishedGame_controlsScore_" + finishedProject);

                float _baseScore = saveData.GetFloat("FinishedGame_baseScore_" + finishedProject);
                float _priceRatio = saveData.GetFloat("FinishedGame_priceRatio_" + finishedProject);
                float _finalScore = saveData.GetFloat("FinishedGame_finalScore_" + finishedProject);

                //Instantiate finished Projects
                if (GameObject.Find(_gameName) == null)
                {
                    GameObject _Project = Instantiate(projectsPrefab, finishedProjectsParent);
                    ProjectInDevelopment _pid = _Project.GetComponent<ProjectInDevelopment>();
                    CalculateGameScore _cgs = _Project.GetComponent<CalculateGameScore>();
                    _Project.gameObject.name = _gameName;

                    _pid.projectName = _gameName;
                    _pid.mainGenre = _mainGenre;
                    _pid.subGenre = _subGenre;
                    _pid.Theme = _theme;
                    _pid.gameSize = _gameSize;
                    _pid.targetAudience = _targetAudience;

                    _pid.setGraphics = _setGraphics;
                    _pid.setSound = _setSound;
                    _pid.setGameplay = _setGameplay;
                    _pid.setContent = _setContent;
                    _pid.setControls = _setControls;

                    _pid.setPrice = _setPrice;
                    _pid.defaultPrice = _defaultPrice;

                    _pid.setDevelopmentTime = _setDevelopmentTime;

                    _pid.optimumGraphics = _optimumGraphics;
                    _pid.optimumSound = _optimumSound;
                    _pid.optimumGameplay = _optimumGameplay;
                    _pid.optimumContent = _optimumContent;
                    _pid.optimumControls = _optimumControls;

                    _pid.optimumDevelopmentTime = _optimumDevelopmentTime;

                    _pid.startDay = _startDay;
                    _pid.startYear = _startYear;

                    _pid.endDay = _endDay;
                    _pid.endYear = _endYear;

                    _pid.sendAwayDay = _sendAwayDay;
                    _pid.sendAwayYear = _sendAwayYear;

                    _pid.reviewDay = _reviewDay;
                    _pid.reviewYear = _reviewYear;

                    _pid.isFinished = _isFinished;
                    _pid.isRated = _isRated;
                    _pid.hasBeenSent = _hasBeenSent;

                    _cgs.totalAmountoffStaffMembers = _totalAmountOfStaff;

                    _cgs.staffTotalProgramming = _staffTotalProgramming;
                    _cgs.staffTotalSound = _staffTotalSound;
                    _cgs.staffTotalGraphics = _staffTotalGraphics;
                    _cgs.staffTotalDesign = _staffTotalDesign;

                    _cgs.staffAverageProgramming = _staffAverageProgramming;
                    _cgs.staffAverageSound = _staffAverageSound;
                    _cgs.staffAverageGraphics = _staffAverageGraphics;
                    _cgs.staffAverageDesign = _staffAvergaeDesign;

                    _cgs.maxGraphics = _maxGraphics;
                    _cgs.maxSound = _maxSound;
                    _cgs.maxGameplay = _maxGameplay;
                    _cgs.maxContent = _maxContent;
                    _cgs.maxControls = _maxControls;
                    _cgs.optimumSum = _optimumSum;

                    _cgs.setGraphics = _reachedGraphics;
                    _cgs.setSound = _reachedSound;
                    _cgs.setGameplay = _reachedGameplay;
                    _cgs.setContent = _reachedContent;
                    _cgs.setControls = _reachedControls;

                    _cgs.staffList = _staffList;

                    _cgs.graphicsScore = _graphicsScore;
                    _cgs.soundScore = _soundScore;
                    _cgs.gameplayScore = _gameplayScore;
                    _cgs.contentScore = _contentScore;
                    _cgs.controlsScore = _controlsScore;

                    _cgs.baseScore = _baseScore;
                    _cgs.priceRatio = _priceRatio;
                    _cgs.finalScore = _finalScore;
                }

            }


            // Load Objects
            int currentObjects = saveData.GetInt("ObjectCount");

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
                    companyManager.GetComponent<CompanyManager>().startingMoney = 0;


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

                    int objectCount = currentObjects;

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
            //LoadData();
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

