using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class grabContacts : MonoBehaviour
{
    [SerializeField]
    private GameObject contactButtonPrefab;
    [SerializeField]
    private Transform contactButtonParent;
    [SerializeField]
    private myContacts myContacts;
    // Start is called before the first frame update
    void Start()
    {
        UpdateContacts();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateContacts()
    {        
        foreach (string _contact in myContacts.contacts)
        {
            if(contactButtonParent.Find("contact_" + _contact) == null)
            { 
            GameObject _newButton = Instantiate(contactButtonPrefab, contactButtonParent);
            _newButton.name = "contact_" + _contact;
            
            StaffHandler _contactSH = GameObject.Find(_contact).GetComponent<StaffHandler>();
           
            _newButton.transform.Find("Name").GetComponent<TMP_Text>().text = _contactSH.firstName+ " " + _contactSH.lastName + " - (0231421 - " + _contactSH.workerID + ")";
            _newButton.transform.Find("Infos").GetComponent<TMP_Text>().text = _contactSH.workerProfession;
            _newButton.transform.Find("ID").GetComponent<TMP_Text>().text = (myContacts.contacts.IndexOf(_contact)+1).ToString()+".";
            }
        }
    }
}
