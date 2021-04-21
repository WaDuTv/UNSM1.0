using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StaffHandler : MonoBehaviour
{
    public WorkersSO worker;    

    public characterVisuals characterVisualsManager; 

    public int workerModelprefabIndex;
    public int workerMaterialIndex;    

    public GameObject workerModel;

    public Transform modelContainer;

    public bool isMale;    

    public string assignedProjectName;

    public string lastName;
    public string firstName;

    public string workerProfession;

    public float workerID;
    public bool workerIDSet = false;

    public int workerStatProgramming;
    public int workerStatSound;
    public int workerStatGraphics;
    public int workerStatDesign;

    public int workerStatGraphicsAndDesign;
    public int workerStatProgrammingAndDesign;

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



    // Start is called before the first frame update
    void Awake() 
    {
        modelContainer = GameObject.Find("ModelContainer").transform;
        companyStaffContainer = GameObject.Find("CompanyStaff");
        workerStatGraphicsAndDesign = workerStatGraphics + workerStatDesign;
        workerStatProgrammingAndDesign = workerStatProgramming + workerStatDesign;                
        //Set WorkerID
        if (workerIDSet == false)
        {
            workerID = Random.Range(100000, 999999);
            workerIDSet = true;
        }
                
    }

    private void Start()
    {
        this.gameObject.name = "worker_" + firstName + " " + lastName;
        InstantiateCharacterModel();
        if (GetComponent<SetUpPlayer>() != null)
        {
            playerModel.transform.position = lastModelPosition;
            playerModel.transform.rotation = lastModelRotation;            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ProjectAssignement()
    {
        isAvailable = false;
        isAssignedToProject = true;

        currentProject = assignedProjectName;
    }

    public void isRemovedFromProject()
    {
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
}
