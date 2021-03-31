using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Doozy.Engine.UI;


public class InstantiateDevelopmentProgressBars : MonoBehaviour
{
    public Transform activeProjectContainer;
    public Transform finishedGamesContainer;

    public ListHolder listHoder;

    public List<GameObject> activeProjectsList;
    public List<GameObject> projectsInReviewList;

    public GameObject progressBarPrefab;
    public GameObject reviewProgressBarPrefab;
    public Transform progressBarParent;

    public UIView developmentOverview;

    public int index = 1;

    [SerializeField]
    private List<GameObject> progressBarList;
    // Start is called before the first frame update
    void Start()
    {
        //activeProjectsList = listHoder.activeProjectsList;
        //projectsInReviewList = listHoder.projectsInReviewList;
        //progressBarList = listHoder.progressBarList;
        //Transform[] activeProjects = activeProjectContainer.gameObject.GetComponentsInChildren<Transform>();
        //Transform[] projectsinReview = finishedGamesContainer.gameObject.GetComponentsInChildren<Transform>();

        //int index = 0;

        //foreach (Transform project in activeProjects)
        //{
        //    if (project != null && project.name != "CurrentActiveProjects")
        //    {
        //        if (activeProjectsList.Contains(project.gameObject))
        //        { }
        //        else
        //        {
        //            activeProjectsList.Add(project.gameObject);
        //            GameObject progressBar = Instantiate(progressBarPrefab, progressBarParent);
        //            progressBar.name = "ProgressBar_" + project.name;
        //            progressBarList.Add(progressBar);
        //        }
        //    }
        //}

        //foreach (Transform pir in projectsinReview)
        //{
        //    if (pir != null && pir.name != "MyFinishedGames" && pir.gameObject.GetComponent<ProjectInDevelopment>().isRated == false && pir.gameObject.GetComponent<ProjectInDevelopment>().hasBeenSent == true)
        //    {
        //        if (projectsInReviewList.Contains(pir.gameObject))
        //        { }
        //        else
        //        {
        //            projectsInReviewList.Add(pir.gameObject);
        //            activeProjectsList.Remove(pir.gameObject);
        //            GameObject progressBar = Instantiate(progressBarPrefab, progressBarParent);
        //            progressBar.transform.Find("ProgressBar").GetComponent<Image>().enabled = false;
        //            progressBar.transform.Find("ProgressBar").GetComponent<ProgressBar>().enabled = false;
        //            progressBar.transform.Find("ProgressBar").Find("Mask").Find("Fill").GetComponent<Image>().enabled = false;
        //            progressBar.transform.Find("ProgressBar").Find("GameName").GetComponent<TMP_Text>().text = "In Review: " + pir.name;
        //            progressBar.name = "InReviewBar_" + pir.name;
        //            progressBarList.Add(progressBar);
        //        }
        //    }
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetUpandRefresh()
    {
        activeProjectsList = listHoder.activeProjectsList;
        projectsInReviewList = listHoder.projectsInReviewList;
        progressBarList = listHoder.progressBarList;
        Transform[] activeProjects = activeProjectContainer.gameObject.GetComponentsInChildren<Transform>();
        Transform[] projectsinReview = finishedGamesContainer.gameObject.GetComponentsInChildren<Transform>();        

        foreach (Transform project in activeProjects)
        {
            if (project != null && project.name != "CurrentActiveProjects")
            {
                if (activeProjectsList.Contains(project.gameObject))
                { }
                else
                {
                    activeProjectsList.Add(project.gameObject);
                    GameObject progressBar = Instantiate(progressBarPrefab, progressBarParent);         
                    progressBar.name = "ProgressBar_" + project.name;
                    progressBarList.Add(progressBar);

                }
            }
        }

        foreach (Transform pir in projectsinReview)
        {
            if (pir != null && pir.name != "MyFinishedGames" && pir.gameObject.GetComponent<ProjectInDevelopment>().isRated == false && pir.gameObject.GetComponent<ProjectInDevelopment>().hasBeenSent == true)
            {
                if (projectsInReviewList.Contains(pir.gameObject))
                { }
                else
                {                    
                    projectsInReviewList.Add(pir.gameObject);
                    activeProjectsList.Remove(pir.gameObject);
                    GameObject progressBar = Instantiate(reviewProgressBarPrefab, progressBarParent);
                    progressBar.transform.Find("ProgressBar").GetComponent<Image>().enabled = false;
                    progressBar.transform.Find("ProgressBar").GetComponent<ProgressBar>().enabled = false;
                    progressBar.transform.Find("ProgressBar").Find("Mask").Find("Fill").GetComponent<Image>().enabled = false;                    
                    progressBar.name = "InReviewBar_" + pir.name;                                        
                    progressBarList.Add(progressBar);                    
                }
            }
        }        
    }

    public void UpdateBarPositions()
    {
        foreach (GameObject bar in progressBarList)
        {
            Vector2 _defaultPosition = progressBarPrefab.GetComponent<RectTransform>().anchoredPosition;
            Transform barTransform = bar.transform;
            Vector2 _positionOffset = new Vector2(0, index * -85f);
            Vector2 _newPosition = _defaultPosition + _positionOffset;
            Debug.Log("Position of " + bar.name + "should be " + (barTransform.GetComponent<RectTransform>().anchoredPosition += _positionOffset));
            barTransform.GetComponent<RectTransform>().anchoredPosition += _positionOffset;
            Debug.Log("But it is" + barTransform.GetComponent<RectTransform>().anchoredPosition);
            index++;
        }
        index = 1;
    }
}
