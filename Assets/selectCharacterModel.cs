using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectCharacterModel : MonoBehaviour
{
    public GameObject characterDummy;

    public GameObject malePrefab1;
    public GameObject malePrefab2;
    public GameObject malePrefab3;
    public GameObject malePrefab4;
    public GameObject femalePrefab1;
    public GameObject femalePrefab2;
    public GameObject femalePrefab3;
    public GameObject femalePrefab4;

    public Material material1;
    public Material material2;
    public Material material3;
    public Material material4;
    public Material material5;
    public Material material6;
    public Material material7;
    public Material material8;
    public Material material9;
    public Material material10;
    public Material material11;
    public Material material12;

    public int modelVariant;
    public int textureVariant;

    [SerializeField]
    private GameObject currentModel;
    [SerializeField]
    private CompanyManager companyManager;


    // Start is called before the first frame update
    void Start()
    {
        currentModel = characterDummy.transform.Find("SM_Chr_Business_Male_01").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeModelNext()
    {
        modelVariant = modelVariant+1;
        textureVariant = 0;
        currentModel.GetComponent<SkinnedMeshRenderer>().material = material1;
        if (modelVariant < 0)
        {
            modelVariant = 0;
        }
        if(modelVariant > 7)
        {
            modelVariant = 7;
        }
        if (modelVariant == 0)
        {
            characterDummy.transform.Find("SM_Chr_Business_Male_01").gameObject.SetActive(true);
            currentModel = characterDummy.transform.Find("SM_Chr_Business_Male_01").gameObject;
            companyManager.playerModelIndex = 1;            
        }
        if (modelVariant == 1)
        {
            characterDummy.transform.Find("SM_Chr_Business_Male_01").gameObject.SetActive(false);
            characterDummy.transform.Find("SM_Chr_Business_Male_02").gameObject.SetActive(true);
            currentModel = characterDummy.transform.Find("SM_Chr_Business_Male_02").gameObject;
            companyManager.playerModelIndex = 2;
        }
        if (modelVariant == 2)
        {
            characterDummy.transform.Find("SM_Chr_Business_Male_02").gameObject.SetActive(false);
            characterDummy.transform.Find("SM_Chr_Business_Male_03").gameObject.SetActive(true);
            currentModel = characterDummy.transform.Find("SM_Chr_Business_Male_03").gameObject;
            companyManager.playerModelIndex = 3;
        }
        if (modelVariant == 3)
        {
            characterDummy.transform.Find("SM_Chr_Business_Male_03").gameObject.SetActive(false);
            characterDummy.transform.Find("SM_Chr_Business_Male_04").gameObject.SetActive(true);
            currentModel = characterDummy.transform.Find("SM_Chr_Business_Male_04").gameObject;
            companyManager.playerModelIndex = 4;
        }
        if (modelVariant == 4)
        {
            characterDummy.transform.Find("SM_Chr_Business_Male_04").gameObject.SetActive(false);
            characterDummy.transform.Find("SM_Chr_Business_Female_01").gameObject.SetActive(true);
            currentModel = characterDummy.transform.Find("SM_Chr_Business_Female_01").gameObject;
            companyManager.playerModelIndex = 5;
        }
        if (modelVariant == 5)
        {
            characterDummy.transform.Find("SM_Chr_Business_Female_01").gameObject.SetActive(false);
            characterDummy.transform.Find("SM_Chr_Business_Female_02").gameObject.SetActive(true);
            currentModel = characterDummy.transform.Find("SM_Chr_Business_Female_02").gameObject;
            companyManager.playerModelIndex = 6;
        }
        if (modelVariant == 6)
        {
            characterDummy.transform.Find("SM_Chr_Business_Female_02").gameObject.SetActive(false);
            characterDummy.transform.Find("SM_Chr_Business_Female_03").gameObject.SetActive(true);
            currentModel = characterDummy.transform.Find("SM_Chr_Business_Female_03").gameObject;
            companyManager.playerModelIndex = 7;
        }
        if (modelVariant == 7)
        {
            characterDummy.transform.Find("SM_Chr_Business_Female_03").gameObject.SetActive(false);
            characterDummy.transform.Find("SM_Chr_Business_Female_04").gameObject.SetActive(true);
            currentModel = characterDummy.transform.Find("SM_Chr_Business_Female_04").gameObject;
            companyManager.playerModelIndex = 8;
        }
        
    }

    public void ChangeModelPrevious()
    {        
        modelVariant = modelVariant - 1;
        textureVariant = 0;
        currentModel.GetComponent<SkinnedMeshRenderer>().material = material1;
        if (modelVariant < 0)
        {
            modelVariant = 0;
        }
        if (modelVariant > 7)
        {
            modelVariant = 7;
        }
        if (modelVariant == 0)
        {
            characterDummy.transform.Find("SM_Chr_Business_Male_02").gameObject.SetActive(false);
            characterDummy.transform.Find("SM_Chr_Business_Male_01").gameObject.SetActive(true);
            currentModel = characterDummy.transform.Find("SM_Chr_Business_Male_01").gameObject;
            companyManager.playerModelIndex = 1;
        }
        if (modelVariant == 1)
        {
            characterDummy.transform.Find("SM_Chr_Business_Male_03").gameObject.SetActive(false);
            characterDummy.transform.Find("SM_Chr_Business_Male_02").gameObject.SetActive(true);
            currentModel = characterDummy.transform.Find("SM_Chr_Business_Male_02").gameObject;
            companyManager.playerModelIndex = 2;
        }
        if (modelVariant == 2)
        {
            characterDummy.transform.Find("SM_Chr_Business_Male_04").gameObject.SetActive(false);
            characterDummy.transform.Find("SM_Chr_Business_Male_03").gameObject.SetActive(true);
            currentModel = characterDummy.transform.Find("SM_Chr_Business_Male_03").gameObject;
            companyManager.playerModelIndex = 3;
        }
        if (modelVariant == 3)
        {
            characterDummy.transform.Find("SM_Chr_Business_Female_01").gameObject.SetActive(false);
            characterDummy.transform.Find("SM_Chr_Business_Male_04").gameObject.SetActive(true);
            currentModel = characterDummy.transform.Find("SM_Chr_Business_Male_04").gameObject;
            companyManager.playerModelIndex = 4;
        }
        if (modelVariant == 4)
        {
            characterDummy.transform.Find("SM_Chr_Business_Female_02").gameObject.SetActive(false);
            characterDummy.transform.Find("SM_Chr_Business_Female_01").gameObject.SetActive(true);
            currentModel = characterDummy.transform.Find("SM_Chr_Business_Female_01").gameObject;
            companyManager.playerModelIndex = 5;
        }
        if (modelVariant == 5)
        {
            characterDummy.transform.Find("SM_Chr_Business_Female_03").gameObject.SetActive(false);
            characterDummy.transform.Find("SM_Chr_Business_Female_02").gameObject.SetActive(true);
            currentModel = characterDummy.transform.Find("SM_Chr_Business_Female_02").gameObject;
            companyManager.playerModelIndex = 6;
        }
        if (modelVariant == 6)
        {
            characterDummy.transform.Find("SM_Chr_Business_Female_04").gameObject.SetActive(false);
            characterDummy.transform.Find("SM_Chr_Business_Female_03").gameObject.SetActive(true);
            currentModel = characterDummy.transform.Find("SM_Chr_Business_Female_03").gameObject;
            companyManager.playerModelIndex = 7;
        }
        if (modelVariant == 7)
        {           
            characterDummy.transform.Find("SM_Chr_Business_Female_04").gameObject.SetActive(true);
            currentModel = characterDummy.transform.Find("SM_Chr_Business_Female_04").gameObject;
            companyManager.playerModelIndex = 8;
        }       
    }

    public void ChangeTextureNext()
    {
        textureVariant = textureVariant + 1;
        if(textureVariant < 0)
        {
            textureVariant = 0;
        }
        if(textureVariant > 11)
        {
            textureVariant = 11;
        }
        if(textureVariant == 0)
        {
            currentModel.GetComponent<SkinnedMeshRenderer>().material = material1;
            companyManager.playerMaterialIndex = 0;
        }
        if (textureVariant == 1)
        {
            currentModel.GetComponent<SkinnedMeshRenderer>().material = material2;
            companyManager.playerMaterialIndex = 1;
        }
        if (textureVariant == 2)
        {
            currentModel.GetComponent<SkinnedMeshRenderer>().material = material3;
            companyManager.playerMaterialIndex = 2;
        }
        if (textureVariant == 3)
        {
            currentModel.GetComponent<SkinnedMeshRenderer>().material = material4;
            companyManager.playerMaterialIndex = 3;
        }
        if (textureVariant == 4)
        {
            currentModel.GetComponent<SkinnedMeshRenderer>().material = material5;
            companyManager.playerMaterialIndex = 4;
        }
        if (textureVariant == 5)
        {
            currentModel.GetComponent<SkinnedMeshRenderer>().material = material6;
            companyManager.playerMaterialIndex = 5;
        }
        if (textureVariant == 6)
        {
            currentModel.GetComponent<SkinnedMeshRenderer>().material = material7;
            companyManager.playerMaterialIndex = 6;
        }
        if (textureVariant == 7)
        {
            currentModel.GetComponent<SkinnedMeshRenderer>().material = material8;
            companyManager.playerMaterialIndex = 7;
        }
        if (textureVariant == 8)
        {
            currentModel.GetComponent<SkinnedMeshRenderer>().material = material9;
            companyManager.playerMaterialIndex = 8;
        }
        if (textureVariant == 9)
        {
            currentModel.GetComponent<SkinnedMeshRenderer>().material = material10;
            companyManager.playerMaterialIndex = 9;
        }
        if (textureVariant == 10)
        {
            currentModel.GetComponent<SkinnedMeshRenderer>().material = material11;
            companyManager.playerMaterialIndex = 10;
        }
        if (textureVariant == 11)
        {
            currentModel.GetComponent<SkinnedMeshRenderer>().material = material12;
            companyManager.playerMaterialIndex = 11;
        }
    }
    public void ChangeTexturePrevious()
    {
        textureVariant = textureVariant -1;
        if (textureVariant < 0)
        {
            textureVariant = 0;
        }
        if (textureVariant > 11)
        {
            textureVariant = 11;
        }
        if (textureVariant == 0)
        {
            currentModel.GetComponent<SkinnedMeshRenderer>().material = material1;
            companyManager.playerMaterial = material1;
        }
        if (textureVariant == 1)
        {
            currentModel.GetComponent<SkinnedMeshRenderer>().material = material2;
            companyManager.playerMaterial = material2;
        }
        if (textureVariant == 2)
        {
            currentModel.GetComponent<SkinnedMeshRenderer>().material = material3;
            companyManager.playerMaterial = material3;
        }
        if (textureVariant == 3)
        {
            currentModel.GetComponent<SkinnedMeshRenderer>().material = material4;
            companyManager.playerMaterial = material4;
        }
        if (textureVariant == 4)
        {
            currentModel.GetComponent<SkinnedMeshRenderer>().material = material5;
            companyManager.playerMaterial = material5;
        }
        if (textureVariant == 5)
        {
            currentModel.GetComponent<SkinnedMeshRenderer>().material = material6;
            companyManager.playerMaterial = material6;
        }
        if (textureVariant == 6)
        {
            currentModel.GetComponent<SkinnedMeshRenderer>().material = material7;
            companyManager.playerMaterial = material7;
        }
        if (textureVariant == 7)
        {
            currentModel.GetComponent<SkinnedMeshRenderer>().material = material8;
            companyManager.playerMaterial = material8;
        }
        if (textureVariant == 8)
        {
            currentModel.GetComponent<SkinnedMeshRenderer>().material = material9;
            companyManager.playerMaterial = material9;
        }
        if (textureVariant == 9)
        {
            currentModel.GetComponent<SkinnedMeshRenderer>().material = material10;
            companyManager.playerMaterial = material10;
        }
        if (textureVariant == 10)
        {
            currentModel.GetComponent<SkinnedMeshRenderer>().material = material11;
            companyManager.playerMaterial = material11;
        }
        if (textureVariant == 11)
        {
            currentModel.GetComponent<SkinnedMeshRenderer>().material = material12;
            companyManager.playerMaterial = material12;
        }
    }
}
