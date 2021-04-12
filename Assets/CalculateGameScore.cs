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


    private float graphicsRatio;
    private float soundRatio;
    private float gameplayRatio;
    private float contentRatio;
    private float controlsRatio;


    public Transform staffContainer;
    public List<string> staffList;


    public float graphicsScore;
    public float soundScore;
    public float gameplayScore;
    public float contentScore;
    public float controlsScore;

    public float baseScore;

    public float priceRatio;

    public float finalScore;



    // Start is called before the first frame update
    void Start()
    {
        staffContainer = GameObject.Find("CompanyStaff").transform;
        alwaysVisibleHolderScript = GameObject.Find("AlwaysVisibleHolder").GetComponent<AlwaysVisibleHolderScript>();
        projectSettings = GetComponent<ProjectInDevelopment>();
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
            StaffHandler staffHandler = staffContainer.Find(s).GetComponent<StaffHandler>();
            if (staffHandler != null)
            {
                staffTotalProgramming += staffHandler.workerStatProgramming;
                staffTotalSound += staffHandler.workerStatSound;
                staffTotalGraphics += staffHandler.workerStatGraphics;
                staffTotalDesign += staffHandler.workerStatDesign;
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
        if (setGraphics >= maxGraphics)
        {
            graphicsRatio = maxGraphics / setGraphics;
        }
        if (setSound <= maxSound)
        {
            soundRatio = setSound / maxSound;
        }
        if (setSound >= maxSound)
        {
            soundRatio = maxSound / setSound;
        }
        if (setGameplay <= maxGameplay)
        {
            gameplayRatio = setGameplay / maxGameplay;
        }
        if (setGameplay >= maxGameplay)
        {
            gameplayRatio = maxGameplay / setGameplay;
        }
        if (setContent <= maxContent)
        {
            contentRatio = setContent / maxContent;
        }
        if (setContent >= maxContent)
        {
            contentRatio = maxContent / setContent;
        }
        if (setControls <= maxControls)
        {
            controlsRatio = setControls / maxControls;
        }
        if (setControls >= maxControls)
        {
            controlsRatio = maxControls / setControls;
        }

        //Calculate FinaleScores
        graphicsScore = setGraphics * graphicsRatio;
        soundScore = setSound * soundRatio;
        gameplayScore = setGameplay * gameplayRatio;
        contentScore = setContent * contentRatio;
        controlsScore = setControls * controlsRatio;

        //Calculate BaseScore
        baseScore = (graphicsScore + soundScore + gameplayScore + controlsScore + controlsScore) / optimumSum;

        //Calculate PriceRatio
        priceRatio = (float)projectSettings.defaultPrice / (float)projectSettings.setPrice;
        Debug.Log(priceRatio);

        //adjust Score according to Price

        finalScore = baseScore - ((1 - priceRatio) / 20);

        foreach (string s in staffList)
        {
            StaffHandler staffHandler = staffContainer.Find(s).GetComponent<StaffHandler>();
            if (staffHandler != null)
            {
                staffHandler.isAvailable = true;
                staffHandler.isAssignedToProject = false;
                staffHandler.currentProject = "";
            }

        }

        alwaysVisibleHolderScript.listAvailableStaffScript.RefreshList();

    }
}
