using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class developmentOverviewValues : MonoBehaviour
{
    public GameDevelopmentProgressbarCalculation gameInProgressStats;

    public string projectLead;
    public string graphicsLead;
    public string soundLead;
    public string leadingProgrammer;
    public string designLead;
        
    [SerializeField]
    private GameObject developmentOverviewView;
    [SerializeField]
    private Transform finishedGamesContainer;
    [SerializeField]
    private GameObject thisProject;
    [SerializeField]
    private Transform staffContainer;
    [SerializeField]
    private List<string> staffList;

    private List<int> programmingStats;
    private List<int> soundStats;
    private List<int> graphicStats;
    private List<int> designStats;
    private List<int> totalStats;

    private List<string> firstNames;
    private List<string> lastNames;
    // Start is called before the first frame update
    void Start()
    {        
        finishedGamesContainer = GameObject.Find("CurrentActiveProjects").transform; /*<< Just for Testing, else use line below*/
        //finishedGamesContainer = GameObject.Find("MyFinishedGames").transform;
        thisProject = finishedGamesContainer.Find(gameInProgressStats.projectName).gameObject;
        staffContainer = GameObject.Find("CompanyStaff").transform;
        staffList = thisProject.GetComponent<ProjectInDevelopment>().assignedStaff;
        gameInProgressStats = this.gameObject.GetComponent<GameDevelopmentProgressbarCalculation>();
        developmentOverviewView = GameObject.Find("AlwaysVisibleHolder").GetComponent<AlwaysVisibleHolderScript>().developmentOverviewBodyView;
        GetAndSetValues();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetAndSetValues()
    {
        programmingStats = new List<int>();
        soundStats = new List<int>();
        graphicStats = new List<int>();
        designStats = new List<int>();
        totalStats = new List<int>();

        firstNames = new List<string>();
        lastNames = new List<string>();

        // Set Header Text
        developmentOverviewView.transform.Find("Header").Find("HeaderText").GetComponent<TMP_Text>().text = "Development-Report for: ''" + gameInProgressStats.projectName + "''";

        //Set General Infos
        Transform _generalStats = developmentOverviewView.transform.Find("Body").Find("Left").Find("GeneralStats").transform;

        _generalStats.Find("Genre").GetComponent<TMP_Text>().text = thisProject.GetComponent<ProjectInDevelopment>().mainGenre + " / " + thisProject.GetComponent<ProjectInDevelopment>().subGenre;
        _generalStats.Find("Theme").GetComponent<TMP_Text>().text = thisProject.GetComponent<ProjectInDevelopment>().Theme;
        _generalStats.Find("GameSize").GetComponent<TMP_Text>().text = thisProject.GetComponent<ProjectInDevelopment>().gameSize;
        _generalStats.Find("Target Audience").GetComponent<TMP_Text>().text = thisProject.GetComponent<ProjectInDevelopment>().targetAudience;

        //Set Leading Staff
        Transform _LeadingStaff = developmentOverviewView.transform.Find("Body").Find("Left").Find("StaffLists").transform;

        foreach (string worker in staffList)
        {

            int _statProgramming = staffContainer.Find(worker).GetComponent<StaffHandler>().workerStatProgramming;
            int _statSound = staffContainer.Find(worker).GetComponent<StaffHandler>().workerStatSound;
            int _statGraphics = staffContainer.Find(worker).GetComponent<StaffHandler>().workerStatGraphics;
            int _statDesign = staffContainer.Find(worker).GetComponent<StaffHandler>().workerStatDesign;

            int _totalValue = _statProgramming + _statSound + _statGraphics + _statDesign;

            string _workerFirstName = staffContainer.Find(worker).GetComponent<StaffHandler>().firstName;
            string _workerLastName = staffContainer.Find(worker).GetComponent<StaffHandler>().lastName;            

                        
            programmingStats.Add(_statProgramming);
            soundStats.Add(_statSound);
            graphicStats.Add(_statGraphics);
            designStats.Add(_statDesign);
            totalStats.Add(_totalValue);
            
            firstNames.Add(_workerFirstName);
            lastNames.Add(_workerLastName);
            
        }

        int maxProgramming = Mathf.Max(programmingStats.ToArray());
        int[] programmingStatsArray = programmingStats.ToArray();
        int i = 0;

        for (i = 0; i < programmingStatsArray.Length; i++)
        {
            if(programmingStatsArray[i] == maxProgramming)
            {
                leadingProgrammer = firstNames[i] + " " + lastNames[i];
            }
        }

        _LeadingStaff.Find("LeadingProgrammer").GetComponent<TMP_Text>().text = leadingProgrammer;

        int maxTotalValue = Mathf.Max(totalStats.ToArray());
        int[] totalValueStatsArray = totalStats.ToArray();        

        for (i = 0; i < totalValueStatsArray.Length; i++)
        {
            if (totalValueStatsArray[i] == maxTotalValue)
            {
                projectLead = firstNames[i] + " " + lastNames[i];
            }
        }

        _LeadingStaff.Find("ProjectLeader").GetComponent<TMP_Text>().text = projectLead;

        int maxGraphics = Mathf.Max(graphicStats.ToArray());
        int[] graphicsStatsArray = graphicStats.ToArray();

        for (i = 0; i < graphicsStatsArray.Length; i++)
        {
            if (graphicsStatsArray[i] == maxGraphics)
            {
                graphicsLead = firstNames[i] + " " + lastNames[i];
            }
        }

        _LeadingStaff.Find("GraphicsLeader").GetComponent<TMP_Text>().text = graphicsLead;

        int maxSound = Mathf.Max(soundStats.ToArray());
        int[] SoundStatsArray = soundStats.ToArray();

        for (i = 0; i < SoundStatsArray.Length; i++)
        {
            if (SoundStatsArray[i] == maxSound)
            {
                soundLead = firstNames[i] + " " + lastNames[i];
            }
        }

        _LeadingStaff.Find("SoundDesignLeader").GetComponent<TMP_Text>().text = soundLead;

        int maxDesign = Mathf.Max(designStats.ToArray());
        int[] DesignStatsArray = designStats.ToArray();        

        for (i = 0; i < DesignStatsArray.Length; i++)
        {
            if (DesignStatsArray[i] == maxDesign)
            {
                designLead = firstNames[i] + " " + lastNames[i];
            }
        }

        _LeadingStaff.Find("GameDesignLeader").GetComponent<TMP_Text>().text = designLead;

        //Set Development Summary


    }

}


