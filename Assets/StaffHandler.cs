using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class StaffHandler : MonoBehaviour
{
    public WorkersSO worker;    

    public characterVisuals characterVisualsManager; 

    public int workerModelprefabIndex;
    public int workerMaterialIndex;    

    public GameObject workerModel;

    public Transform modelContainer;

    public GameObject assignedWorkspace;

    public bool isMale;    

    public string assignedProjectName;

    public string lastName;
    public string firstName;

    public string workerProfession;

    public float workerID;
    public bool workerIDSet = false;

    public float workerMood;

    public int workerStatProgramming;
    public int workerStatSound;
    public int workerStatGraphics;
    public int workerStatDesign;

    public int workerStatGraphicsAndDesign;
    public int workerStatProgrammingAndDesign;

    public string workerGrade_;

    public int workerSalary;

    public bool isAvailable;
    public bool isAssignedToProject;

    public string currentProject;

    public bool isPlayer = false;

    [SerializeField]
    private GameObject workerMaterialHolder;    
    
    public GameObject workerModelprefab;
    public GameObject playerModel;

    public Material workerMaterial;

    public Vector3 lastModelPosition;
    public Quaternion lastModelRotation;

    [SerializeField]
    private GameObject companyStaffContainer;
    [SerializeField]
    workspaceManager workspaceManager;



    // Start is called before the first frame update
    void Awake() 
    {
        this.gameObject.name = "worker_" + firstName + " " + lastName;
        Debug.Log("done renaming 1");
        modelContainer = GameObject.Find("ModelContainer").transform;
        companyStaffContainer = GameObject.Find("CompanyStaff");
        workspaceManager = GameObject.Find("WorkspaceManager").GetComponent<workspaceManager>();
        workerStatGraphicsAndDesign = workerStatGraphics + workerStatDesign;
        workerStatProgrammingAndDesign = workerStatProgramming + workerStatDesign;        

        //Set WorkerID
        if (workerIDSet == false)
        {
            workerID = Random.Range(100000, 999999);
            workerIDSet = true;
        }

        //Get WorkerGrade
        float _workerStatValue = (workerStatProgramming + workerStatSound + workerStatGraphics + workerStatDesign) / 4f;
        if(_workerStatValue >= 0 && _workerStatValue < 2.5)
        {
            workerGrade_ = "D";
        }
        if (_workerStatValue >= 2.5 && _workerStatValue < 5)
        {
            workerGrade_ = "C";
        }
        if (_workerStatValue >= 5 && _workerStatValue < 7.5)
        {
            workerGrade_ = "B";
        }
        if (_workerStatValue >= 7.5 && _workerStatValue <= 10)
        {
            workerGrade_ = "A";
        }
    }

    private void Start()
    {      
        this.gameObject.name = "worker_" + firstName + " " + lastName;
        Debug.Log("done renaming 2");
        InstantiateCharacterModel();
        if (GetComponent<SetUpPlayer>() != null)
        {
            playerModel.transform.position = lastModelPosition;
            playerModel.transform.rotation = lastModelRotation;            
        }
        for (int i = 0; i < workspaceManager.availableWorkspaces.Count; i++)
        {
            assignedWorkspace = workspaceManager.availableWorkspaces[i];
            break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ProjectAssignement()
    {
        stateChanger _stateChanger;
        if(isPlayer != true)
        { 
            _stateChanger = modelContainer.Find("workerModel_"+firstName+ " " +lastName).GetComponent<stateChanger>();
            _stateChanger.isIdle = false;
            _stateChanger.isAssignedToProject = true;

        }
        if(isPlayer == true)
        {
            _stateChanger = modelContainer.Find("PlayerModel").GetComponent<stateChanger>(); 
            _stateChanger.isIdle = false;
            _stateChanger.isAssignedToProject = true;
        }

        isAvailable = false;
        isAssignedToProject = true;
        

        currentProject = assignedProjectName;
    }

    public void isRemovedFromProject()
    {
        stateChanger _stateChanger;
        if (isPlayer == false)
        {
            _stateChanger = modelContainer.Find("workerModel_" + firstName + " " + lastName).GetComponent<stateChanger>();
            _stateChanger.isIdle = true;
            _stateChanger.isAssignedToProject = false;

        }
        if (isPlayer == true)
        {
            _stateChanger = modelContainer.Find("PlayerModel").GetComponent<stateChanger>();
            _stateChanger.isIdle = true;
            _stateChanger.isAssignedToProject = false;
        }

        isAvailable = true;
        isAssignedToProject = false;        
        currentProject = "";
    }

    public void InstantiateCharacterModel()
    {
        if (GetComponent<SetUpPlayer>() == null && this.transform.parent == GameObject.Find("CompanyStaff").transform)
        {
            characterVisualsManager = GameObject.Find("CharacterVisualsManager").GetComponent<characterVisuals>();
            workerModelprefab = characterVisualsManager.characterModelPrefabs[workerModelprefabIndex];
            workerMaterial = characterVisualsManager.characterModelMaterials[workerMaterialIndex];

            workerModel = Instantiate(workerModelprefab, modelContainer);
            if (workerModelprefab.name == "Developer_Female_01")
            {
                workerMaterialHolder = workerModel.transform.Find("SM_Chr_Developer_Female_01").gameObject;
            }
            if (workerModelprefab.name == "Developer_Female_02")
            {
                workerMaterialHolder = workerModel.transform.Find("SM_Chr_Developer_Female_02").gameObject;
            }
            if (workerModelprefab.name == "Developer_Male_01")
            {
                workerMaterialHolder = workerModel.transform.Find("SM_Chr_Developer_Male_01").gameObject;
            }
            if (workerModelprefab.name == "Developer_Male_02")
            {
                workerMaterialHolder = workerModel.transform.Find("SM_Chr_Developer_Male_02").gameObject;
            }
            workerModel.name = "workerModel_" + firstName + " " + lastName;
            workerMaterialHolder.GetComponent<SkinnedMeshRenderer>().material = workerMaterial;

            workerModel.transform.position = lastModelPosition;
            workerModel.transform.rotation = lastModelRotation;

            
        }
    }

    public void InstantiateTemporaryCharacterModel()
    {        
        characterVisualsManager = GameObject.Find("CharacterVisualsManager").GetComponent<characterVisuals>();
        workerModelprefab = characterVisualsManager.characterModelPrefabs[workerModelprefabIndex];
        workerMaterial = characterVisualsManager.characterModelMaterials[workerMaterialIndex];

        workerModel = Instantiate(workerModelprefab, modelContainer);
        if (workerModelprefab.name == "Developer_Female_01")
        {
            workerMaterialHolder = workerModel.transform.Find("SM_Chr_Developer_Female_01").gameObject;
        }
        if (workerModelprefab.name == "Developer_Female_02")
        {
            workerMaterialHolder = workerModel.transform.Find("SM_Chr_Developer_Female_02").gameObject;
        }
        if (workerModelprefab.name == "Developer_Male_01")
        {
            workerMaterialHolder = workerModel.transform.Find("SM_Chr_Developer_Male_01").gameObject;
        }
        if (workerModelprefab.name == "Developer_Male_02")
        {
            workerMaterialHolder = workerModel.transform.Find("SM_Chr_Developer_Male_02").gameObject;
        }
        workerModel.name = "workerModel_" + firstName + " " + lastName;
        workerMaterialHolder.GetComponent<SkinnedMeshRenderer>().material = workerMaterial;
        workerModel.GetComponent<isTemporaryModel>().isTemporary_ = true;        

        workerModel.transform.position = lastModelPosition;
        workerModel.transform.rotation = lastModelRotation;
        
    }
}
