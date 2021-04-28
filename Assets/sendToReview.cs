using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doozy.Engine.UI;
using TMPro;

public class sendToReview : MonoBehaviour
{
    public UIView developmentSumaryView;
    public string barName;
    public string projectName;
    public string systemName;

    public Transform progressBarContainer;
    public Transform finishedGameContainer;
    public InstantiateDevelopmentProgressBars instantiateProgressbarsScript;

    private GameObject activeProgressBar;
    private GameObject activeProject;

    public ListHolder listHolder;

    public List<GameObject> activeProjectsList;
    public List<GameObject> projectsInReviewList;
    public List<GameObject> progressBarList;
    // Start is called before the first frame update
    void Start()
    {
        activeProjectsList = listHolder.activeProjectsList;
        projectsInReviewList = listHolder.projectsInReviewList;
        progressBarList = listHolder.progressBarList;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SendToReviewButton()
    {
        activeProgressBar = progressBarContainer.Find(barName).gameObject;
        activeProject = finishedGameContainer.Find(projectName).gameObject;
        activeProject.GetComponent<ProjectInDevelopment>().sendToRating();        
        developmentSumaryView.Hide();
        //Save values for this Game in instantiated GameObject with needed Stats-Script
        progressBarList.Remove(activeProgressBar);
        Destroy(activeProgressBar);        
        instantiateProgressbarsScript.SetUpandRefresh();        
    }
}
