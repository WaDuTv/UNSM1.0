using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Doozy.Engine.UI;
using PixelCrushers.DialogueSystem;
using TMPro;
using UnityEngine.AI;

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
    [SerializeField]
    GameObject callerwindow;
    [SerializeField]
    private GameObject[] phoneCallSpawns;
    [SerializeField]
    AlwaysVisibleHolderScript alwaysVisibleHolderScript;
    
    


    private void Start()
    {                                              
        dialogueSystemTrigger.conversationActor = GameObject.Find("AlwaysVisibleHolder").GetComponent<AlwaysVisibleHolderScript>().playerModel.transform;
        moodSlider = GameObject.Find("Progress Bar_Current Mood").GetComponent<Slider>();
        calledPersonNameDisplay = GameObject.Find("CalledPerson_Name").GetComponent<TMP_Text>();
        workerModelContainer = GameObject.Find("ModelContainer");
        hangUpCallButton = GameObject.Find("Button - Hangup Phone").GetComponent<HangUpCall>();
        alwaysVisibleHolderScript = GameObject.Find("AlwaysVisibleHolder").GetComponent<AlwaysVisibleHolderScript>();

        phoneCallSpawns = GameObject.FindGameObjectsWithTag("phoneCallSpawn");

        callerwindow = GameObject.Find("Contact_Caller_Window");


    }
    public void MakeCall()
    {
        callerwindow.GetComponent<RawImage>().enabled = true;
        AlwaysVisibleHolderScript _holder = GameObject.Find("AlwaysVisibleHolder").GetComponent<AlwaysVisibleHolderScript>();
        CompanyManager _companyManager = GameObject.Find("CompanyManager").GetComponent<CompanyManager>();
        CompanyValuesManager _companyValuesManager = GameObject.Find("CompanyValuesManager").GetComponent<CompanyValuesManager>();
        companyStandartsManager _companyStandartsManager = GameObject.Find("CompanyValuesManager").GetComponent<companyStandartsManager>();
        conversationManagerScript _conversationManagerScript = GameObject.Find("ConversationManager").GetComponent<conversationManagerScript>();
        highscoreHolder _highscoreHolder = GameObject.Find("GameDevelopmentManager").GetComponent<highscoreHolder>();
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
        DialogueLua.SetVariable("CompanyNumberOfWorkers", _companyValuesManager.numberOfCurrentWorkers);

        if(_highscoreHolder.highestScore != 0)
        { 
            DialogueLua.SetVariable("CompanyBestGame", _highscoreHolder.highscoringGame);
            DialogueLua.SetVariable("CompanyBestGameScore", _highscoreHolder.highestScore);
        }
        if (_highscoreHolder.highestScore == 0)
        {
            DialogueLua.SetVariable("CompanyBestGame", "None");
        }

        DialogueLua.SetVariable("minHiringSkillProgramming", _companyStandartsManager.minimumHiringStatProgramming);
        DialogueLua.SetVariable("minHiringSkillGraphics", _companyStandartsManager.minimumHiringStatGraphics);
        DialogueLua.SetVariable("minHiringSkillSound", _companyStandartsManager.minimumHiringStatSound);
        DialogueLua.SetVariable("minHiringSkillDesign", _companyStandartsManager.minimumHiringStatDesign);

        int _averageSkill = (_calledPersonStaffHandler.workerStatGraphics + _calledPersonStaffHandler.workerStatSound + _calledPersonStaffHandler.workerStatProgramming + _calledPersonStaffHandler.workerStatDesign) / 4;
        DialogueLua.SetVariable("AverageSkill", _averageSkill);

        DialogueLua.SetVariable("ConversantSkillProgramming", _calledPersonStaffHandler.workerStatProgramming);
        DialogueLua.SetVariable("ConversantSkillGraphics", _calledPersonStaffHandler.workerStatGraphics);
        DialogueLua.SetVariable("ConversantSkillSound", _calledPersonStaffHandler.workerStatSound);
        DialogueLua.SetVariable("ConversantSkillDesign", _calledPersonStaffHandler.workerStatDesign);

        DialogueLua.SetVariable("ConversantProffession", _calledPersonStaffHandler.workerProfession);


        dialogueSystemTrigger.conversationConversant = calledPerson.transform;

        int _index = Random.Range(0, phoneCallSpawns.Length);

        moodSlider.value = _calledPersonStaffHandler.workerMood;
        calledPersonNameDisplay.text = _calledPersonStaffHandler.firstName + " " + _calledPersonStaffHandler.lastName;
        
        if (workerModelContainer.transform.Find("workerModel_" + _calledPersonStaffHandler.firstName + " " + _calledPersonStaffHandler.lastName) == null)
        {
            _calledPersonStaffHandler.InstantiateTemporaryCharacterModel();                        
            workerModel = workerModelContainer.transform.Find("workerModel_" + _calledPersonStaffHandler.firstName + " " + _calledPersonStaffHandler.lastName).gameObject;
            workerModel.transform.position = phoneCallSpawns[_index].transform.position;            
            workerModel.transform.eulerAngles = phoneCallSpawns[_index].transform.eulerAngles;
            workerModel.GetComponent<NavMeshAgent>().Warp(phoneCallSpawns[_index].transform.position);
        }
        if (workerModelContainer.transform.Find("workerModel_" + _calledPersonStaffHandler.firstName + " " + _calledPersonStaffHandler.lastName) != null)
        {
            workerModel = workerModelContainer.transform.Find("workerModel_" + _calledPersonStaffHandler.firstName + " " + _calledPersonStaffHandler.lastName).gameObject;
        }

        workerModelanimator = workerModel.GetComponent<Animator>();
        //workerModelanimator.SetBool("isBeingCalled", true);
        //workerModelanimator.SetBool("isIdle", true);
        workerModel.GetComponent<stateChanger>().isIdle = false;
        workerModel.GetComponent<stateChanger>().isOnPhone = true;
        alwaysVisibleHolderScript.playerModel.GetComponent<stateChanger>().isIdle = false;
        alwaysVisibleHolderScript.playerModel.GetComponent<stateChanger>().isOnPhone = true;
        TextureHolder = workerModel.GetComponent<textureHolder>();
        modelCam = workerModel.transform.Find("modelCam").GetComponent<Camera>();
        modelCam.targetTexture = TextureHolder.camTexture;

        hangUpCallButton.callerModel = workerModel;

        cellPhone = workerModel.GetComponent<modelAttachmentsHolder>().cellPhone;
        cellPhone.SetActive(true);
    }
}
