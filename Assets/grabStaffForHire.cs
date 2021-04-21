using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class grabStaffForHire : MonoBehaviour
{
    [SerializeField]
    private GameObject StaffForHirePrefab;
    [SerializeField]
    private Transform staffForHireButtonParent;
    [SerializeField]
    private Transform staffForHireContainer;
    [SerializeField]
    private AvailableWorkersLibraryManager availableWorkersLibraryManager;
    [SerializeField]
    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateContacts()
    {
        foreach (string _staff in availableWorkersLibraryManager.availableWorkers)
        {
            if (staffForHireButtonParent.Find("available_" + _staff) == null)
            {
                GameObject _newButton = Instantiate(StaffForHirePrefab, staffForHireButtonParent);
                _newButton.name = "available_" + _staff;
                int _newIndex = index + 1;

                string[] _nameArray = _staff.Split(char.Parse("_"));
                string _firstName = _nameArray[1];
                string _lastName = _nameArray[2];

                Debug.Log("worker_" + _firstName + " " + _lastName);

                StaffHandler _sh = staffForHireContainer.Find("worker_" + _firstName + " " + _lastName).GetComponent<StaffHandler>();

                _newButton.transform.Find("Name").GetComponent<TMP_Text>().text = _sh.firstName + " " + _sh.lastName;
                _newButton.transform.Find("Infos").GetComponent<TMP_Text>().text = _sh.workerProfession;
                _newButton.transform.Find("ID").GetComponent<TMP_Text>().text = (availableWorkersLibraryManager.availableWorkers.IndexOf(_staff) + 1).ToString() + ".";

                index = _newIndex;
            }
            
        }
    }
}
