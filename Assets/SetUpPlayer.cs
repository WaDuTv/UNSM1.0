using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUpPlayer : MonoBehaviour
{
    public StaffHandler staffHandlerScript;
    public CompanyManager companyManager;
    public bool setupDone;

    public GameObject playerModel;
    public Material playerMaterial;

    [SerializeField]
    private string[] splitArray;

    [SerializeField]
    private GameObject _activeModel;
    [SerializeField]
    private GameObject _activeMaterial;
    [SerializeField]
    private List<GameObject> _modelPrefabs;

    void Start()
    {
        staffHandlerScript.isPlayer = true;
        companyManager = GameObject.Find("CompanyManager").GetComponent<CompanyManager>();
        playerMaterial = companyManager.playerMaterial;
        splitArray = companyManager.playerName.Split(' ');
        _activeModel = playerModel.transform.Find("SM_Chr_Business_Male_01").gameObject;
        _activeModel.GetComponent<SkinnedMeshRenderer>().material = playerMaterial;
        string _firstName = splitArray[0];
        string _lastName = splitArray[1];

        staffHandlerScript.workerStatProgramming = companyManager.playerStatProgramming;
        staffHandlerScript.workerStatSound = companyManager.playerStatSound;
        staffHandlerScript.workerStatGraphics = companyManager.playerStatGraphics;
        staffHandlerScript.workerStatDesign = companyManager.playerStatDesign;
        staffHandlerScript.workerStatGraphicsAndDesign = staffHandlerScript.workerStatGraphics + staffHandlerScript.workerStatDesign;
        staffHandlerScript.workerStatProgrammingAndDesign = staffHandlerScript.workerStatProgramming + staffHandlerScript.workerStatDesign;

        staffHandlerScript.lastName = _lastName;
        staffHandlerScript.firstName = _firstName;

        this.gameObject.name = "worker_" + _firstName + " " + _lastName;

        if (companyManager.playerModelIndex == 1)
        {
            playerModel.transform.Find("SM_Chr_Business_Male_01").gameObject.SetActive(true);
            _activeModel = playerModel.transform.Find("SM_Chr_Business_Male_01").gameObject;
        }
        if (companyManager.playerModelIndex == 2)
        {
            playerModel.transform.Find("SM_Chr_Business_Male_01").gameObject.SetActive(false);
            playerModel.transform.Find("SM_Chr_Business_Male_02").gameObject.SetActive(true);
            _activeModel = playerModel.transform.Find("SM_Chr_Business_Male_02").gameObject;
        }
        if (companyManager.playerModelIndex == 3)
        {
            playerModel.transform.Find("SM_Chr_Business_Male_01").gameObject.SetActive(false);
            playerModel.transform.Find("SM_Chr_Business_Male_03").gameObject.SetActive(true);
            _activeModel = playerModel.transform.Find("SM_Chr_Business_Male_03").gameObject;
        }
        if (companyManager.playerModelIndex == 4)
        {
            playerModel.transform.Find("SM_Chr_Business_Male_01").gameObject.SetActive(false);
            playerModel.transform.Find("SM_Chr_Business_Male_04").gameObject.SetActive(true);
            _activeModel = playerModel.transform.Find("SM_Chr_Business_Male_04").gameObject;
        }
        if (companyManager.playerModelIndex == 5)
        {
            playerModel.transform.Find("SM_Chr_Business_Male_01").gameObject.SetActive(false);
            playerModel.transform.Find("SM_Chr_Business_Female_01").gameObject.SetActive(true);
            _activeModel = playerModel.transform.Find("SM_Chr_Business_Female_01").gameObject;
        }
        if (companyManager.playerModelIndex == 6)
        {
            playerModel.transform.Find("SM_Chr_Business_Male_01").gameObject.SetActive(false);
            playerModel.transform.Find("SM_Chr_Business_Female_02").gameObject.SetActive(true);
            _activeModel = playerModel.transform.Find("SM_Chr_Business_Female_02").gameObject;
        }
        if (companyManager.playerModelIndex == 7)
        {                
            playerModel.transform.Find("SM_Chr_Business_Male_01").gameObject.SetActive(false);
            playerModel.transform.Find("SM_Chr_Business_Female_03").gameObject.SetActive(true);
            _activeModel = playerModel.transform.Find("SM_Chr_Business_Female_03").gameObject;
        }
        if (companyManager.playerModelIndex == 8)
        {
            playerModel.transform.Find("SM_Chr_Business_Male_01").gameObject.SetActive(false);
            playerModel.transform.Find("SM_Chr_Business_Female_04").gameObject.SetActive(true);
            _activeModel = playerModel.transform.Find("SM_Chr_Business_Female_04").gameObject;
        }

        _activeModel.GetComponent<SkinnedMeshRenderer>().material = playerMaterial;
    }
}
