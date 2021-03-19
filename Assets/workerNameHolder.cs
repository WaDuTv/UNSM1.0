using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class workerNameHolder : MonoBehaviour
{
    public string workerName;
    public TMP_InputField newGameName;

    public GameObject staffContainer;

    // Start is called before the first frame update
    void Start()
    {
        newGameName = GameObject.Find("List_Content_staff").GetComponent<ListAvailableStaff>().newGameName;
        staffContainer = GameObject.Find("List_Content_staff").GetComponent<ListAvailableStaff>().staffContainer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeWorkerStats()
    {
        GameObject worker;
        worker = staffContainer.transform.Find(workerName).gameObject;
        worker.GetComponent<StaffHandler>().assignedProjectName = newGameName.text;
        worker.GetComponent<StaffHandler>().isAvailable = false;
        worker.GetComponent<StaffHandler>().isAssignedToProject = true;
    }
}
