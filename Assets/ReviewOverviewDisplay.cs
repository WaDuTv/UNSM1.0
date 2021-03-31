using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Doozy.Engine.UI;


public class ReviewOverviewDisplay : MonoBehaviour
{
    public int reviewReadyDay;
    public int reviewReadyYear;

    public string projectName;

    public developmentOverviewValues values;
    
    public UIView reviewSplashScreen;

    public Button showReviewButton;
    public UIButton showReviewUIButton;

    public sendToReview sendToReviewButton;

    public GameObject thisProject;

    public GameObject finishedGameConatainer;


    [SerializeField]
    private string barName;
    [SerializeField]
    private string[] splitArray;
    [SerializeField]
    private int currentDay;
    [SerializeField]
    private int currentYear;

    // Start is called before the first frame update
    void Start()
    {
        showReviewButton.enabled = false;
        showReviewUIButton.enabled = false;
        reviewSplashScreen = GameObject.Find("View - ReviewResultSplashScreen").GetComponent<UIView>();
        sendToReviewButton = GameObject.Find("Button - Send to Review").GetComponent<sendToReview>();
        barName = this.gameObject.name.ToString();
        splitArray = barName.Split('_');
        projectName = splitArray[1];
        finishedGameConatainer = GameObject.Find("MyFinishedGames");
        thisProject = finishedGameConatainer.transform.Find(projectName).gameObject;

        reviewReadyDay = thisProject.GetComponent<ProjectInDevelopment>().reviewDay;
        reviewReadyYear = thisProject.GetComponent<ProjectInDevelopment>().reviewYear;

    }

    // Update is called once per frame
    void Update()
    {
        currentDay = EnviroSky.instance.GameTime.Days;
        currentYear = EnviroSky.instance.GameTime.Years;        

        if(reviewReadyDay != 0 && reviewReadyDay <= currentDay && reviewReadyYear != 0 && reviewReadyYear <= currentYear)
        {
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
}
