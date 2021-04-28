using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using TMPro;
using UnityEngine.UI;
using Doozy.Engine.UI;

public class GameDevelopmentProgressbarCalculation : MonoBehaviour
{
    public Transform activeProjectsContainer;

    public float developmentTime;
    public int startDay;
    public int startMonth;
    public int startYear;

    public float progress;

    public int currentDay;
    public int currentMonth;
    public int currentYear;

    public int getReviewReadyDay;
    public int getReviewReadyYear;

    public int endDay;
    public int endMonth;
    public int endYear;

    public string systemName;

    public TMP_Text displayedName;

    public GameObject progressBarFill;

    public UIView developmentOverview;
    public UIView reviewSplashScreen;

    public Button showDevelopmentOverviewButton;
    public UIButton showDevelopmentOverviewUIButton;

    public sendToReview sendToReviewButton;

    public string projectName;

    [SerializeField]
    private List<GameObject> activeProjectsList;
    [SerializeField]
    private string barName;
    [SerializeField]
    private string[] splitArray;    
    [SerializeField]
    private int daysPast;
    [SerializeField]
    private Clock clock;
    [SerializeField]
    private bool systemIsSet;

    // Start is called before the first frame update
    void Start()
    {
        activeProjectsContainer = GameObject.Find("CurrentActiveProjects").transform;
        Transform _finishedProjectcontainer = GameObject.Find("MyFinishedGames").transform;
        activeProjectsList = GetComponentInParent<InstantiateDevelopmentProgressBars>().activeProjectsList;        
        displayedName = this.transform.Find("background").Find("GameName").GetComponent<TMP_Text>();
        barName = this.gameObject.name.ToString();
        splitArray = barName.Split('_');
        projectName = splitArray[1];
        if(activeProjectsContainer.Find(projectName) != null)
        { 
            systemName = activeProjectsContainer.Find(projectName).gameObject.GetComponent<ProjectInDevelopment>().system;
            
        }
        if (activeProjectsContainer.Find(projectName) == null)
        {
            systemName = _finishedProjectcontainer.Find(projectName).gameObject.GetComponent<ProjectInDevelopment>().system;
        }
        displayedName.text = projectName+" ("+systemName+")";
        progressBarFill = this.transform.Find("background").Find("ProgressBar").gameObject;
        developmentOverview = GameObject.Find("View - DevelopmentOverview").GetComponent<UIView>();
        reviewSplashScreen = GameObject.Find("View - ReviewResultSplashScreen").GetComponent<UIView>();
        clock = GameObject.Find("TimeManager").GetComponent<Clock>();
        showDevelopmentOverviewUIButton.enabled = false;
        showDevelopmentOverviewButton.enabled = false;
        sendToReviewButton = GameObject.Find("Button - Send to Review").GetComponent<sendToReview>();
        getReviewReadyDay = this.gameObject.GetComponent<developmentOverviewValues>().reviewReadyDay;
        getReviewReadyYear = this.gameObject.GetComponent<developmentOverviewValues>().reviewReadyYear;
        endDay = activeProjectsContainer.Find(projectName).gameObject.GetComponent<ProjectInDevelopment>().endDay;
        endMonth = activeProjectsContainer.Find(projectName).gameObject.GetComponent<ProjectInDevelopment>().endMonth;
        endYear = activeProjectsContainer.Find(projectName).gameObject.GetComponent<ProjectInDevelopment>().endYear;
        this.transform.Find("background").Find("DevelopemtEndTest").GetComponent<TMP_Text>().text = "Done on "+endDay+"/"+endMonth+"/"+endYear;
    }

    // Update is called once per frame
    void Update()
    {        
        currentMonth = clock.month;
        currentDay = ((clock.month - 1) * 30) + clock.day;
        currentYear = clock.year;
        
        if (progress < 100)
        { 
            CalculateProgress();
        }
        UpdateProgressBar();
        if(progress <=33)
        {
            progressBarFill.GetComponent<ProgressBar>().color = Color.red;
        }
        if (progress > 33 && progress <= 66)
        {
            progressBarFill.GetComponent<ProgressBar>().color = new Color32(255,152,0,255);
        }
        if (progress >66 && progress <= 99)
        {
            progressBarFill.GetComponent<ProgressBar>().color = Color.yellow;
        }
        if (progress == 100)
        {
            progressBarFill.GetComponent<ProgressBar>().color = Color.green;
            showDevelopmentOverviewUIButton.enabled = true;
            showDevelopmentOverviewButton.enabled = true;
        }        
    }

    public void UpdateProgressBar()
    {
        if((int)progress <= 100)
        {
            progressBarFill.GetComponent<ProgressBar>().current = (int)progress;
        }
        if((int)progress > 100)
        {
            progressBarFill.GetComponent<ProgressBar>().current = 100;
        }
        
    }

    public void CalculateProgress()
    {        
        foreach (GameObject g in activeProjectsList)
        {
            if (g.name == projectName)
            {                                
                startMonth = g.GetComponent<ProjectInDevelopment>().startMonth;
                startDay = g.GetComponent<ProjectInDevelopment>().startDay + ((startMonth-1)*30);
                startYear = g.GetComponent<ProjectInDevelopment>().startYear;
                developmentTime = g.GetComponent<ProjectInDevelopment>().setDevelopmentTime;
            }
        }
        daysPast = currentDay - startDay + (currentYear - startYear) * 360;
        if (developmentTime != 0)
        {
            progress = daysPast / developmentTime * 100;            
        }
    }

    public void EnableDevelopmentOverview()
    {
        sendToReviewButton.barName = barName;
        sendToReviewButton.projectName = projectName;
        developmentOverview.Show();
    }
    public void EnableReviewResultsView()
    {
        sendToReviewButton.barName = "In Review" + barName;
        sendToReviewButton.projectName = projectName;
        sendToReviewButton.systemName = systemName;
        reviewSplashScreen.Show();
    }

}
