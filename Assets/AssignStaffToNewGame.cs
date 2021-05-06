using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AssignStaffToNewGame : MonoBehaviour
{
    public GameObject assignedStaffContainer;
    public GameObject staffContainer;

    public TMP_InputField projectName;
    
    public List<string> assignedStaff;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AssignStaffToNewProject()
    {
        assignedStaff = new List<string>();
        Transform[] staffList = assignedStaffContainer.GetComponentsInChildren<Transform>();
        foreach (Transform t in staffList)
        {
            if (t != null && t.gameObject != null && t.gameObject != assignedStaffContainer && t.gameObject.name != "StaffName" && t.gameObject.name != "Staffinfo")
            {
                workerNameHolder worker = t.gameObject.GetComponent<workerNameHolder>();
                assignedStaff.Add(worker.workerName);
            }
        }

        int index = 0;

        foreach (string s in assignedStaff)
        {
            StaffHandler staffInfo = GameObject.Find(s).GetComponent<StaffHandler>();
            stateChanger stateChanger = GameObject.Find(s).GetComponent<stateChanger>();
            staffInfo.isAvailable = false;
            staffInfo.isAssignedToProject = true;
            stateChanger.isIdle = false;
            staffInfo.currentProject = projectName.text;

        }
    }
}
