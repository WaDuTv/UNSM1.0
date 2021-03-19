using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StaffHandler : MonoBehaviour
{
    public WorkersSO worker;

    public string assignedProjectName;

    public string lastName;
    public string firstName;

    public string workerProfession;

    public int workerStatProgramming;
    public int workerStatSound;
    public int workerStatGraphics;
    public int workerStatDesign;

    public bool isAvailable;
    public bool isAssignedToProject;

    public string currentProject;

    

    // Start is called before the first frame update
    void Awake() 
    {        
        this.gameObject.name = "worker_"+firstName + " " + lastName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ProjectAssignement()
    {
        isAvailable = false;
        isAssignedToProject = true;

        currentProject = assignedProjectName;
    }

    public void isRemovedFromProject()
    {
        isAvailable = true;
        isAssignedToProject = false;

        currentProject = "";
    }
}
