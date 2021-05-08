using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnGameLibraryManager : MonoBehaviour
{
    public List<GameObject> ownFinishedGames;
    public List<GameObject> ownCurrentDevelopedGames;

    [SerializeField]
    private Transform activeProjectsContainer;
    [SerializeField]
    private Transform finishedProjectsContainer;

    // Start is called before the first frame update
    void Start()
    {
        activeProjectsContainer = GameObject.Find("CurrentActiveProjects").transform;
        finishedProjectsContainer = GameObject.Find("MyFinishedGames").transform;

    }

    // Update is called once per frame
    void Update()
    {
        GetDevelopedGames();
        GetFinishedGames();
    }

    private void GetDevelopedGames()
    {
        Transform[] _activeProjectsArray = activeProjectsContainer.GetComponentsInChildren<Transform>();
        foreach (Transform t in _activeProjectsArray)
        {
            if(t != activeProjectsContainer && !ownCurrentDevelopedGames.Contains(t.gameObject))
            {
                ownCurrentDevelopedGames.Add(t.gameObject);
            }
            if(ownFinishedGames.Contains(t.gameObject))
            {
                ownCurrentDevelopedGames.Remove(t.gameObject);
            }
        }
    }

    private void GetFinishedGames()
    {
        Transform[] _finishedProjectsArray = finishedProjectsContainer.GetComponentsInChildren<Transform>();
        foreach (Transform t in _finishedProjectsArray)
        {
            if (t != finishedProjectsContainer && !ownFinishedGames.Contains(t.gameObject))
            {
                ownFinishedGames.Add(t.gameObject);
            }
        }
    }
}
