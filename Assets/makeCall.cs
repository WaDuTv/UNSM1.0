using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Doozy.Engine.UI;
using PixelCrushers.DialogueSystem;
using TMPro;

public class makeCall : MonoBehaviour
{    
    [SerializeField]
    private GameObject calledPerson;
    [SerializeField]
    private GameObject workerModel;
    [SerializeField]
    private textureHolder TextureHolder;
    [SerializeField]
    private Camera modelCam;
    [SerializeField]
    private Animator workerModelanimator;
    [SerializeField]
    private DialogueSystemTrigger dialogueSystemTrigger;
    [SerializeField]
    private Slider moodSlider;
    [SerializeField]
    private TMP_Text calledPersonNameDisplay;
    [SerializeField]
    private GameObject workerModelContainer;
    [SerializeField]
    private HangUpCall hangUpCallButton;
    [SerializeField]
    private GameObject cellPhone;

    


    private void Start()
    {                                              
        dialogueSystemTrigger.conversationActor = GameObject.Find("AlwaysVisibleHolder").GetComponent<AlwaysVisibleHolderScript>().playerModel.transform;
        moodSlider = GameObject.Find("Progress Bar_Current Mood").GetComponent<Slider>();
        calledPersonNameDisplay = GameObject.Find("CalledPerson_Name").GetComponent<TMP_Text>();
        workerModelContainer = GameObject.Find("ModelContainer");
        hangUpCallButton = GameObject.Find("Button - Hangup Phone").GetComponent<HangUpCall>();


    }
    public void MakeCall()
    {
        
        AlwaysVisibleHolderScript _holder = GameObject.Find("AlwaysVisibleHolder").GetComponent<AlwaysVisibleHolderScript>();
        CompanyManager _companyManager = GameObject.Find("CompanyManager").GetComponent<CompanyManager>();
        CompanyValuesManager _companyValuesManager = GameObject.Find("CompanyValuesManager").GetComponent<CompanyValuesManager>();
        conversationManagerScript _conversationManagerScript = GameObject.Find("ConversationManager").GetComponent<conversationManagerScript>();
        string[] _nameArray = this.name.ToString().Split(char.Parse("_"));        
        string _calledPersonName = "worker_" + _nameArray[2] + " " + _nameArray[3];
        string _playername = _holder.playerPrefab.GetComponent<StaffHandler>().firstName + " " + _holder.playerPrefab.GetComponent<StaffHandler>().lastName;

        calledPerson = GameObject.Find(_calledPersonName);        
        StaffHandler _calledPersonStaffHandler = calledPerson.GetComponent<StaffHandler>();
        _conversationManagerScript.currentWorkerStaffHandler = _calledPersonStaffHandler;

        //Set Conversa<tion Variables        
        DialogueLua.SetActorField("NPC", "Display Name", _nameArray[2]+" "+_nameArray[3]);
        
        DialogueLua.SetActorField("Player", "Display Name", _playername);
        DialogueLua.SetVariable("ConversantMood", _calledPersonStaffHandler.workerMood);
        DialogueLua.SetVariable("CompanyName", _companyManager.companyName);
        DialogueLua.SetVariable("CompanyReputation", _companyValuesManager.companyReputaion);
        DialogueLua.SetVariable("CompanyNumberOfWorkers", _companyValuesManager.numberOfCurrentWorkers);

        
        dialogueSystemTrigger.conversationConversant = calledPerson.transform;

        

        moodSlider.value = _calledPersonStaffHandler.workerMood;
        calledPersonNameDisplay.text = _calledPersonStaffHandler.firstName + " " + _calledPersonStaffHandler.lastName;
        
        if (workerModelContainer.transform.Find("workerModel_" + _calledPersonStaffHandler.firstName + " " + _calledPersonStaffHandler.lastName) == null)
        {
            _calledPersonStaffHandler.InstantiateTemporaryCharacterModel();                        
            workerModel = workerModelContainer.transform.Find("workerModel_" + _calledPersonStaffHandler.firstName + " " + _calledPersonStaffHandler.lastName).gameObject;
            workerModel.transform.position = new Vector3(-15.243f, 0, -18.696f);
            workerModel.transform.eulerAngles = new Vector3(0, -47.278f, 0);
        }
        if (workerModelContainer.transform.Find("workerModel_" + _calledPersonStaffHandler.firstName + " " + _calledPersonStaffHandler.lastName) != null)
        {
            workerModel = workerModelContainer.transform.Find("workerModel_" + _calledPersonStaffHandler.firstName + " " + _calledPersonStaffHandler.lastName).gameObject;
        }

        workerModelanimator = workerModel.GetComponent<Animator>();        
        workerModelanimator.SetBool("isBeingCalled", true);
        TextureHolder = workerModel.GetComponent<textureHolder>();
        modelCam = workerModel.transform.Find("modelCam").GetComponent<Camera>();
        modelCam.targetTexture = TextureHolder.camTexture;

        hangUpCallButton.callerModel = workerModel;

        cellPhone = workerModel.GetComponent<modelAttachmentsHolder>().cellPhone;
        cellPhone.SetActive(true);
    }
}
