using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListHolder : MonoBehaviour
{
    public List<GameObject> activeProjectsList;
    public List<GameObject> projectsInReviewList;
    public List<GameObject> progressBarList;
    // Start is called before the first frame update
    void Awake()
    {
        activeProjectsList = new List<GameObject>();
        projectsInReviewList = new List<GameObject>();
        progressBarList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
