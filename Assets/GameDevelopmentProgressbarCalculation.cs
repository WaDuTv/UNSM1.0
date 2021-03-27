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
    public int startYear;

    public float progress;

    public int currentDay;
    public int currentYear;

    public TMP_Text displayedName;

    public GameObject progressBarFill;

    public UIView developmentOverview;

    public Button showDevelopmentOverviewButton;
    public UIButton showDevelopmentOverviewUIButton;

    public string projectName;

    [SerializeField]
    private List<GameObject> activeProjectsList;
    [SerializeField]
    private string barName;
    [SerializeField]
    private string[] splitArray;    
    [SerializeField]
    private int daysPast;

    // Start is called before the first frame update
    void Start()
    {
        activeProjectsContainer = GameObject.Find("CurrentActiveProjects").transform;
        activeProjectsList = GetComponentInParent<InstantiateDevelopmentProgressBars>().activeProjectsList;
        displayedName = this.transform.Find("ProgressBar").Find("GameName").GetComponent<TMP_Text>();
        barName = this.gameObject.name.ToString();
        splitArray = barName.Split('_');
        projectName = splitArray[1];
        displayedName.text = projectName;
        progressBarFill = this.transform.Find("ProgressBar").gameObject;
        developmentOverview = GameObject.Find("View - DevelopmentOverview").GetComponent<UIView>();
        showDevelopmentOverviewUIButton.enabled = false;
        showDevelopmentOverviewButton.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        currentDay = EnviroSky.instance.GameTime.Days;
        currentYear = EnviroSky.instance.GameTime.Years;
        CalculateProgress();
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
                startDay = g.GetComponent<ProjectInDevelopment>().startDay;
                startYear = g.GetComponent<ProjectInDevelopment>().startYear;
                developmentTime = g.GetComponent<ProjectInDevelopment>().setDevelopmentTime;
            }
        }
        daysPast = currentDay - startDay + (currentYear - startYear) * EnviroSky.instance.GameTime.DaysInYear;
        if (developmentTime != 0)
        {
            progress = daysPast / developmentTime * 100;            
        }
    }

    public void EnableDevelopmentOverview()
    {
        developmentOverview.Show();
    }
    
}
