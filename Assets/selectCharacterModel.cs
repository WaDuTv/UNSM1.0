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
        }
        if (modelVariant == 1)
        {
            characterDummy.transform.Find("SM_Chr_Business_Male_01").gameObject.SetActive(false);
            characterDummy.transform.Find("SM_Chr_Business_Male_02").gameObject.SetActive(true);
            currentModel = characterDummy.transform.Find("SM_Chr_Business_Male_02").gameObject;
        }
        if (modelVariant == 2)
        {
            characterDummy.transform.Find("SM_Chr_Business_Male_02").gameObject.SetActive(false);
            characterDummy.transform.Find("SM_Chr_Business_Male_03").gameObject.SetActive(true);
            currentModel = characterDummy.transform.Find("SM_Chr_Business_Male_03").gameObject;
        }
        if (modelVariant == 3)
        {
            characterDummy.transform.Find("SM_Chr_Business_Male_03").gameObject.SetActive(false);
            characterDummy.transform.Find("SM_Chr_Business_Male_04").gameObject.SetActive(true);
            currentModel = characterDummy.transform.Find("SM_Chr_Business_Male_04").gameObject;
        }
        if (modelVariant == 4)
        {
            characterDummy.transform.Find("SM_Chr_Business_Male_04").gameObject.SetActive(false);
            characterDummy.transform.Find("SM_Chr_Business_Female_01").gameObject.SetActive(true);
            currentModel = characterDummy.transform.Find("SM_Chr_Business_Female_01").gameObject;
        }
        if (modelVariant == 5)
        {
            characterDummy.transform.Find("SM_Chr_Business_Female_01").gameObject.SetActive(false);
            characterDummy.transform.Find("SM_Chr_Business_Female_02").gameObject.SetActive(true);
            currentModel = characterDummy.transform.Find("SM_Chr_Business_Female_02").gameObject;
        }
        if (modelVariant == 6)
        {
            characterDummy.transform.Find("SM_Chr_Business_Female_02").gameObject.SetActive(false);
            characterDummy.transform.Find("SM_Chr_Business_Female_03").gameObject.SetActive(true);
            currentModel = characterDummy.transform.Find("SM_Chr_Business_Female_03").gameObject;
        }
        if (modelVariant == 7)
        {
            characterDummy.transform.Find("SM_Chr_Business_Female_03").gameObject.SetActive(false);
            characterDummy.transform.Find("SM_Chr_Business_Female_04").gameObject.SetActive(true);
            currentModel = characterDummy.transform.Find("SM_Chr_Business_Female_04").gameObject;
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
        }
        if (modelVariant == 1)
        {
            characterDummy.transform.Find("SM_Chr_Business_Male_03").gameObject.SetActive(false);
            characterDummy.transform.Find("SM_Chr_Business_Male_02").gameObject.SetActive(true);
            currentModel = characterDummy.transform.Find("SM_Chr_Business_Male_02").gameObject;
        }
        if (modelVariant == 2)
        {
            characterDummy.transform.Find("SM_Chr_Business_Male_04").gameObject.SetActive(false);
            characterDummy.transform.Find("SM_Chr_Business_Male_03").gameObject.SetActive(true);
            currentModel = characterDummy.transform.Find("SM_Chr_Business_Male_03").gameObject;
        }
        if (modelVariant == 3)
        {
            characterDummy.transform.Find("SM_Chr_Business_Female_01").gameObject.SetActive(false);
            characterDummy.transform.Find("SM_Chr_Business_Male_04").gameObject.SetActive(true);
            currentModel = characterDummy.transform.Find("SM_Chr_Business_Male_04").gameObject;
        }
        if (modelVariant == 4)
        {
            characterDummy.transform.Find("SM_Chr_Business_Female_02").gameObject.SetActive(false);
            characterDummy.transform.Find("SM_Chr_Business_Female_01").gameObject.SetActive(true);
            currentModel = characterDummy.transform.Find("SM_Chr_Business_Female_01").gameObject;
        }
        if (modelVariant == 5)
        {
            characterDummy.transform.Find("SM_Chr_Business_Female_03").gameObject.SetActive(false);
            characterDummy.transform.Find("SM_Chr_Business_Female_02").gameObject.SetActive(true);
            currentModel = characterDummy.transform.Find("SM_Chr_Business_Female_02").gameObject;
        }
        if (modelVariant == 6)
        {
            characterDummy.transform.Find("SM_Chr_Business_Female_04").gameObject.SetActive(false);
            characterDummy.transform.Find("SM_Chr_Business_Female_03").gameObject.SetActive(true);
            currentModel = characterDummy.transform.Find("SM_Chr_Business_Female_03").gameObject;
        }
        if (modelVariant == 7)
        {           
            characterDummy.transform.Find("SM_Chr_Business_Female_04").gameObject.SetActive(true);
            currentModel = characterDummy.transform.Find("SM_Chr_Business_Female_04").gameObject;
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
        }
        if (textureVariant == 1)
        {
            currentModel.GetComponent<SkinnedMeshRenderer>().material = material2;
        }
        if (textureVariant == 2)
        {
            currentModel.GetComponent<SkinnedMeshRenderer>().material = material3;
        }
        if (textureVariant == 3)
        {
            currentModel.GetComponent<SkinnedMeshRenderer>().material = material4;
        }
        if (textureVariant == 4)
        {
            currentModel.GetComponent<SkinnedMeshRenderer>().material = material5;
        }
        if (textureVariant == 5)
        {
            currentModel.GetComponent<SkinnedMeshRenderer>().material = material6;
        }
        if (textureVariant == 6)
        {
            currentModel.GetComponent<SkinnedMeshRenderer>().material = material7;
        }
        if (textureVariant == 7)
        {
            currentModel.GetComponent<SkinnedMeshRenderer>().material = material8;
        }
        if (textureVariant == 8)
        {
            currentModel.GetComponent<SkinnedMeshRenderer>().material = material9;
        }
        if (textureVariant == 9)
        {
            currentModel.GetComponent<SkinnedMeshRenderer>().material = material10;
        }
        if (textureVariant == 10)
        {
            currentModel.GetComponent<SkinnedMeshRenderer>().material = material11;
        }
        if (textureVariant == 11)
        {
            currentModel.GetComponent<SkinnedMeshRenderer>().material = material12;
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
        }
        if (textureVariant == 1)
        {
            currentModel.GetComponent<SkinnedMeshRenderer>().material = material2;
        }
        if (textureVariant == 2)
        {
            currentModel.GetComponent<SkinnedMeshRenderer>().material = material3;
        }
        if (textureVariant == 3)
        {
            currentModel.GetComponent<SkinnedMeshRenderer>().material = material4;
        }
        if (textureVariant == 4)
        {
            currentModel.GetComponent<SkinnedMeshRenderer>().material = material5;
        }
        if (textureVariant == 5)
        {
            currentModel.GetComponent<SkinnedMeshRenderer>().material = material6;
        }
        if (textureVariant == 6)
        {
            currentModel.GetComponent<SkinnedMeshRenderer>().material = material7;
        }
        if (textureVariant == 7)
        {
            currentModel.GetComponent<SkinnedMeshRenderer>().material = material8;
        }
        if (textureVariant == 8)
        {
            currentModel.GetComponent<SkinnedMeshRenderer>().material = material9;
        }
        if (textureVariant == 9)
        {
            currentModel.GetComponent<SkinnedMeshRenderer>().material = material10;
        }
        if (textureVariant == 10)
        {
            currentModel.GetComponent<SkinnedMeshRenderer>().material = material11;
        }
        if (textureVariant == 11)
        {
            currentModel.GetComponent<SkinnedMeshRenderer>().material = material12;
        }
    }

}
