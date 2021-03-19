using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InstantiateDevelopmentProgressBars : MonoBehaviour
{
    public Transform activeProjectContainer;
    public List<GameObject> activeProjectsList;

    public GameObject progressBarPrefab;
    public Transform progressBarParent;

    [SerializeField]
    private List<GameObject> progressBarList;
    // Start is called before the first frame update
    void Start()
    {
        activeProjectsList = new List<GameObject>();
        progressBarList = new List<GameObject>();
        Transform[] activeProjects = activeProjectContainer.gameObject.GetComponentsInChildren<Transform>();

        foreach (Transform project in activeProjects)
        {
            if(project != null && project.name != "CurrentActiveProjects")
            {
                activeProjectsList.Add(project.gameObject);
                GameObject progressBar = Instantiate(progressBarPrefab, progressBarParent);
                progressBar.name = "ProgressBar_" + project.name;
                progressBarList.Add(progressBar);
            }
        }

        int index = 0;

        foreach (GameObject progressBar in progressBarList)
        {
            progressBar.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, index * -85);
            index++;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetUpandRefresh()
    {
        activeProjectsList = new List<GameObject>();
        progressBarList = new List<GameObject>();
        Transform[] activeProjects = activeProjectContainer.gameObject.GetComponentsInChildren<Transform>();

        foreach (Transform project in activeProjects)
        {
            if (project != null && project.name != "CurrentActiveProjects")
            {
                activeProjectsList.Add(project.gameObject);
                GameObject progressBar = Instantiate(progressBarPrefab, progressBarParent);
                progressBar.name = "ProgressBar_" + project.name;
                progressBarList.Add(progressBar);
            }
        }

        int index = 0;

        foreach (GameObject progressBar in progressBarList)
        {
            progressBar.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, index * -85);
            index++;
        }
    } 
}
