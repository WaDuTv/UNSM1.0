using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doozy.Engine.UI;
using PixelCrushers.DialogueSystem;

public class makeCall : MonoBehaviour
{
    [SerializeField]
    private UIView callView;
    [SerializeField]
    private UIView ringingView;
    [SerializeField]
    private UIView contactsView;
    [SerializeField]
    private UIView currentView;

    [SerializeField]
    private GameObject calledPerson;

    [SerializeField]
    private DialogueSystemTrigger dialogueSystemTrigger;
    

    private void Start()
    {
        callView = GameObject.Find("View - Contacts").GetComponent<UIView>();
        ringingView = GameObject.Find("View - Phonecall_Ringing").GetComponent<UIView>();               
        
        if (this.transform.parent.parent.parent.parent.parent = GameObject.Find("View - Hire Staff").transform)
        {
            currentView = GameObject.Find("View - Hire Staff").GetComponent<UIView>();
        }

        dialogueSystemTrigger.conversationActor = GameObject.Find("AlwaysVisibleHolder").GetComponent<AlwaysVisibleHolderScript>().playerModel.transform;        
    }
    public void MakeCall()
    {
        currentView.Hide();
        callView.Show();
        ringingView.Show();

        string[] _nameArray = this.name.ToString().Split(char.Parse("_"));        
        string _calledPersonName = "worker_" + _nameArray[2] + " " + _nameArray[3];

        calledPerson = GameObject.Find(_calledPersonName);
        dialogueSystemTrigger.conversationConversant = calledPerson.transform;

    }
}
