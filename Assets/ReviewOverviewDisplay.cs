using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Doozy.Engine.UI;
using TMPro;


public class ReviewOverviewDisplay : MonoBehaviour
{
    public int reviewReadyDay;
    public int reviewReadyMonth;
    public int reviewReadyYear;

    public float _sendAwayDay;
    public float _timeForReview;
    public float _dayPast;

    public float reviewProgress;

    public string projectName;

    public developmentOverviewValues values;
    
    public UIView reviewSplashScreen;

    public Button showReviewButton;
    public UIButton showReviewUIButton;

    public sendToReview sendToReviewButton;

    public GameObject thisProject;

    public GameObject finishedGameConatainer;

    [SerializeField]
    private ProgressBar progressBar;


    [SerializeField]
    private string barName;
    [SerializeField]
    private string[] splitArray;
    [SerializeField]
    private int currentDay;
    [SerializeField]
    private int currentMonth;
    [SerializeField]
    private int currentYear;
    [SerializeField]
    private Clock clock;
    [SerializeField]
    private TMP_Text gameName;
    [SerializeField]
    private TMP_Text developmentEndText;

    // Start is called before the first frame update
    void Start()
    {
        showReviewButton.enabled = false;
        showReviewUIButton.enabled = false;
        reviewSplashScreen = GameObject.Find("View - ReviewResultSplashScreen").GetComponent<UIView>();
        sendToReviewButton = GameObject.Find("Button - Send to Review").GetComponent<sendToReview>();
        clock = GameObject.Find("TimeManager").GetComponent<Clock>();
        barName = this.gameObject.name.ToString();
        splitArray = barName.Split('_');
        projectName = splitArray[1];
        finishedGameConatainer = GameObject.Find("MyFinishedGames");
        thisProject = finishedGameConatainer.transform.Find(projectName).gameObject;

        gameName.text = projectName + " ("+ thisProject.GetComponent<ProjectInDevelopment>().system;        

        reviewProgress = 0;

        reviewReadyDay = thisProject.GetComponent<ProjectInDevelopment>().reviewDay;
        reviewReadyMonth = thisProject.GetComponent<ProjectInDevelopment>().reviewMonth;
        reviewReadyYear = thisProject.GetComponent<ProjectInDevelopment>().reviewYear;

        developmentEndText.text = "Review ready on " + reviewReadyDay + "." + reviewReadyMonth + "." + reviewReadyYear;

    }

    // Update is called once per frame
    void Update()
    {
        currentMonth = clock.month;
        currentDay = clock.day;
        currentYear = clock.year;

        if(reviewProgress < 100)
        {
            CalculateProgress();            
        }
        UpdateProgressBar();
        if (reviewProgress <= 33)
        {
            progressBar.color = Color.red;
        }
        if (reviewProgress > 33 && reviewProgress <= 66)
        {
            progressBar.color = new Color32(255, 152, 0, 255);
        }
        if (reviewProgress > 66 && reviewProgress <= 99)
        {
            progressBar.color = Color.yellow;
        }
        if (reviewProgress == 100)
        {
            progressBar.color = Color.green;
            showReviewButton.enabled = true;
            showReviewUIButton.enabled = true;
        }
    }

    public void EnableReviewResultsView()
    {
        sendToReviewButton.barName = "In Review" + barName;
        sendToReviewButton.projectName = projectName;
        reviewSplashScreen.Show();
    }

    public void CalculateProgress()
    {
        _sendAwayDay = (thisProject.GetComponent<ProjectInDevelopment>().sendAwayMonth-1)*30 + thisProject.GetComponent<ProjectInDevelopment>().sendAwayDay;
        _timeForReview = ((reviewReadyMonth - 1) * 30 + reviewReadyDay) - _sendAwayDay;

        _dayPast = ((currentMonth-1)*30 + currentDay) - _sendAwayDay;

        reviewProgress = _dayPast / _timeForReview * 100f;
        
    }

    public void UpdateProgressBar()
    {
        if ((int)reviewProgress <= 100)
        {
            progressBar.current = (int)reviewProgress;
        }
        if ((int)reviewProgress > 100)
        {
            progressBar.current = 100;
        }

    }
}
