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

    [SerializeField]
    private GameObject workerMaterialHolder;
    
    public GameObject workerModelprefab;
    
    public Material workerMaterial;


    // Start is called before the first frame update
    void Awake() 
    {
        modelContainer = GameObject.Find("ModelContainer").transform;
        this.gameObject.name = "worker_"+firstName + " " + lastName;
        workerStatGraphicsAndDesign = workerStatGraphics + workerStatDesign;
        workerStatProgrammingAndDesign = workerStatProgramming + workerStatDesign;
        //SetUp Worker Model
        
        workerModelprefab = characterVisualsManager.characterModelPrefabs[workerModelprefabIndex];
        workerMaterial = characterVisualsManager.characterModelMaterials[workerMaterialIndex];

        workerModel = Instantiate(workerModelprefab, modelContainer);
        if(workerModelprefab.name == "Developer_Female_01")
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
        workerModel.transform.position = new Vector3(-7, 0, -5);
        workerMaterialHolder.GetComponent<SkinnedMeshRenderer>().material = workerMaterial;

        //Set WorkerID
        if(workerIDSet == false)
        {
            workerID = Random.Range(100000, 999999);
            workerIDSet = true;
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
}
