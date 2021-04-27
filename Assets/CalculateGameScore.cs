using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateGameScore : MonoBehaviour
{
    public ProjectInDevelopment projectSettings;
    public AlwaysVisibleHolderScript alwaysVisibleHolderScript;

    
    public float totalAmountoffStaffMembers;
    public int staffTotalProgramming;
    public int staffTotalSound;
    public int staffTotalGraphics;
    public int staffTotalDesign;


    public float staffAverageProgramming;
    public float staffAverageSound;
    public float staffAverageGraphics;
    public float staffAverageDesign;

    
    public float maxGraphics;    
    public float maxSound;    
    public float maxGameplay;    
    public float maxContent;    
    public float maxControls;    
    public float optimumSum;

    
    public float setGraphics;
    public float setSound;    
    public float setGameplay;    
    public float setContent;    
    public float setControls;


    public  float graphicsRatio;
    public  float soundRatio;
    public float gameplayRatio;
    public float contentRatio;
    public float controlsRatio;


    public Transform staffContainer;
    public List<string> staffList;


    public float graphicsScore;
    public float soundScore;
    public float gameplayScore;
    public float contentScore;
    public float controlsScore;

    public float baseScore;

    public float priceRatio;

    private float _graphicsAdjustment;
    private float _soundAdjustment;
    private float _gameplayAdjustment;
    private float _contentAdjustment;
    private float _controlsAdjustment;


    public float finalScore;
    public float _adjustedFinalScore;

    private GameObject player;



    // Start is called before the first frame update
    void Start()
    {
        staffContainer = GameObject.Find("CompanyStaff").transform;
        alwaysVisibleHolderScript = GameObject.Find("AlwaysVisibleHolder").GetComponent<AlwaysVisibleHolderScript>();
        projectSettings = GetComponent<ProjectInDevelopment>();
        player = GameObject.Find("AlwaysVisibleHolder").GetComponent<AlwaysVisibleHolderScript>().playerPrefab;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameScore()
    {
        staffList = GetComponent<ProjectInDevelopment>().assignedStaff;        
        totalAmountoffStaffMembers = staffList.Count;

        foreach (string s in staffList)
        {
            if (s == player.name.ToString())
            {
                StaffHandler staffHandler = player.GetComponent<StaffHandler>();
                if (staffHandler != null)
                {
                    staffTotalProgramming += staffHandler.workerStatProgramming;
                    staffTotalSound += staffHandler.workerStatSound;
                    staffTotalGraphics += staffHandler.workerStatGraphics;
                    staffTotalDesign += staffHandler.workerStatDesign;
                }

            }
            if (s != player.name.ToString())
            { 
                StaffHandler staffHandler = staffContainer.Find(s).GetComponent<StaffHandler>();
                if (staffHandler != null)
                {
                    staffTotalProgramming += staffHandler.workerStatProgramming;
                    staffTotalSound += staffHandler.workerStatSound;
                    staffTotalGraphics += staffHandler.workerStatGraphics;
                    staffTotalDesign += staffHandler.workerStatDesign;
                }
            }

        }
        staffAverageProgramming = staffTotalProgramming / totalAmountoffStaffMembers;
        staffAverageSound = staffTotalSound / totalAmountoffStaffMembers;
        staffAverageGraphics = staffTotalGraphics / totalAmountoffStaffMembers;
        staffAverageDesign = staffTotalDesign / totalAmountoffStaffMembers;

        //Calculate Optimum Criteria Values with optimum DevelopmentTime
        maxGraphics = projectSettings.optimumGraphics * projectSettings.optimumDevelopmentTime / 30;
        maxSound = projectSettings.optimumSound * projectSettings.optimumDevelopmentTime / 30;
        maxGameplay = projectSettings.optimumGameplay * projectSettings.optimumDevelopmentTime / 30;
        maxContent = projectSettings.optimumContent * projectSettings.optimumDevelopmentTime / 30;
        maxControls = projectSettings.optimumControls * projectSettings.optimumDevelopmentTime / 30;
        optimumSum = maxGraphics + maxSound + maxGameplay + maxContent + maxControls;

        //Calculate Set Criteria Values dependend on Staffskill and Developmenttime
        setGraphics = ((staffAverageGraphics + staffAverageDesign) * projectSettings.setDevelopmentTime/30) / 2;
        setSound = staffAverageSound * projectSettings.setDevelopmentTime/30;
        setGameplay = staffAverageProgramming * projectSettings.setDevelopmentTime/30;
        setContent = (staffAverageDesign + staffAverageProgramming) * projectSettings.setDevelopmentTime/30 / 2;
        setControls = staffAverageProgramming * projectSettings.setDevelopmentTime/30;
        
        //Calculate Optimum/Set Value Ratio
        if (setGraphics <= maxGraphics)
        {
            graphicsRatio = setGraphics / maxGraphics;
        }
        if (setGraphics > maxGraphics)
        {
            graphicsRatio = maxGraphics / setGraphics;
        }
        if (setSound <= maxSound)
        {
            soundRatio = setSound / maxSound;
        }
        if (setSound > maxSound)
        {
            soundRatio = maxSound / setSound;
        }
        if (setGameplay <= maxGameplay)
        {
            gameplayRatio = setGameplay / maxGameplay;
        }
        if (setGameplay > maxGameplay)
        {
            gameplayRatio = maxGameplay / setGameplay;
        }
        if (setContent <= maxContent)
        {
            contentRatio = setContent / maxContent;
        }
        if (setContent > maxContent)
        {
            contentRatio = maxContent / setContent;
        }
        if (setControls <= maxControls)
        {
            controlsRatio = setControls / maxControls;
        }
        if (setControls > maxControls)
        {
            controlsRatio = maxControls / setControls;
        }

        if (projectSettings.optimumGraphics > projectSettings.setGraphics)
        {
            _graphicsAdjustment = projectSettings.setGraphics / projectSettings.optimumGraphics;
        }
        if (projectSettings.optimumGraphics <= projectSettings.setGraphics)
        {
            _graphicsAdjustment = projectSettings.optimumGraphics / projectSettings.setGraphics;
        }

        if (projectSettings.optimumSound > projectSettings.setSound)
        {
            _soundAdjustment = projectSettings.setSound / projectSettings.optimumSound;
        }
        if (projectSettings.optimumSound <= projectSettings.setSound)
        {
            _soundAdjustment = projectSettings.optimumSound / projectSettings.setSound;
        }

        if (projectSettings.optimumGameplay > projectSettings.setGameplay)
        {
            _gameplayAdjustment = projectSettings.setGameplay / projectSettings.optimumGameplay;
        }
        if (projectSettings.optimumGameplay <= projectSettings.setGameplay)
        {
            _gameplayAdjustment = projectSettings.optimumGameplay / projectSettings.setGameplay;
        }

        if (projectSettings.optimumContent > projectSettings.setContent)
        {
            _contentAdjustment = projectSettings.setContent / projectSettings.optimumContent;
        }
        if (projectSettings.optimumContent <= projectSettings.setContent)
        {
            _contentAdjustment = projectSettings.optimumContent / projectSettings.setContent;
        }

        if (projectSettings.optimumControls > projectSettings.setControls)
        {
            _controlsAdjustment = projectSettings.setControls / projectSettings.optimumControls;
        }
        if (projectSettings.optimumControls <= projectSettings.setControls)
        {
            _controlsAdjustment = projectSettings.optimumControls / projectSettings.setControls;
        }

        //Calculate FinaleScores
        graphicsScore = setGraphics * graphicsRatio * _graphicsAdjustment;
        soundScore = setSound * soundRatio * _soundAdjustment;
        gameplayScore = setGameplay * gameplayRatio * _gameplayAdjustment;
        contentScore = setContent * contentRatio*_contentAdjustment;
        controlsScore = setControls * controlsRatio*_controlsAdjustment;

        //Calculate BaseScore
        baseScore = (graphicsScore + soundScore + gameplayScore + controlsScore + controlsScore) / optimumSum;

        //Calculate PriceRatio
        priceRatio = (float)projectSettings.defaultPrice / (float)projectSettings.setPrice;
        Debug.Log(priceRatio);

        //adjust Score according to Price

        finalScore = baseScore - ((1 - priceRatio) / 20);
        

        float _overallAdjustment = (_graphicsAdjustment + _soundAdjustment + _gameplayAdjustment + _contentAdjustment + _controlsAdjustment) / 5;
        if (_overallAdjustment == 1)
        {
            _adjustedFinalScore = finalScore * 1;
        }
        if(_overallAdjustment < 1)
        {
            _adjustedFinalScore = finalScore * _overallAdjustment;
        }

        finalScore = _adjustedFinalScore;
        

        foreach (string s in staffList)
        {
            if(s == player.name.ToString())
            {
                StaffHandler staffHandler = player.GetComponent<StaffHandler>();
                staffHandler.isAvailable = true;
                staffHandler.isAssignedToProject = false;
                staffHandler.currentProject = "";
            }
            if (s != player.name.ToString())
            {
                StaffHandler staffHandler = staffContainer.Find(s).GetComponent<StaffHandler>();
                if (staffHandler != null)
                {
                    staffHandler.isAvailable = true;
                    staffHandler.isAssignedToProject = false;
                    staffHandler.currentProject = "";
                }
            }
        }

        alwaysVisibleHolderScript.listAvailableStaffScript.RefreshList();

    }
}
