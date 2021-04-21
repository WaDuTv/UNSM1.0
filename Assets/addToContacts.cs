using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class addToContacts : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI workerName;

    private myContacts myContacts;
    private Transform availableStaffContainer;

    private void Awake()
    {
        myContacts = GameObject.Find("ContactsLibray").GetComponent<myContacts>();
        availableStaffContainer = GameObject.Find("AvailableWorkers").transform;
    }
    public void AddToContacts()
    {
        GameObject _attachedWorker = availableStaffContainer.Find("worker_" + workerName.text).gameObject;
        StaffHandler _sh = _attachedWorker.GetComponent<StaffHandler>();

        myContacts.contacts.Add(_attachedWorker.name.ToString());
    }
}
