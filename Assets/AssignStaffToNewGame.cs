using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using BehaviorDesigner.Runtime;

public class AssignStaffToNewGame : MonoBehaviour
{
    public GameObject assignedStaffContainer;
    public GameObject staffContainer;

    public TMP_InputField projectName;
    
    public List<string> assignedStaff;

    private

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
            if(staffInfo.isPlayer == true)
            {
                GameObject.Find("PlayerModel").GetComponent<stateChanger>().isIdle = false;
                GameObject.Find("PlayerModel").GetComponent<stateChanger>().isAssignedToProject = true;
            }
            if(staffInfo.isPlayer == false)
            {
                GameObject.Find("workerModel_" + staffInfo.firstName + " " + staffInfo.lastName).GetComponent<stateChanger>().isIdle = false;
                GameObject.Find("workerModel_" + staffInfo.firstName + " " + staffInfo.lastName).GetComponent<stateChanger>().isAssignedToProject = true;
                BehaviorTree _behaviorTree = GameObject.Find("workerModel_" + staffInfo.firstName + " " + staffInfo.lastName).GetComponent<BehaviorTree>();
                _behaviorTree.SetVariableValue("AssignedWorkspace", staffInfo.assignedWorkspace);
                _behaviorTree.SetVariableValue("WorkSpaceRotation", staffInfo.assignedWorkspace.transform.localEulerAngles);

            }

            staffInfo.isAvailable = false;
            staffInfo.isAssignedToProject = true;            
            staffInfo.currentProject = projectName.text;

        }
    }
}
