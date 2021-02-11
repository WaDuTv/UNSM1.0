using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildTypeSelectUI : MonoBehaviour
{
    [SerializeField] public List<BuildingTypeSO> buildingTypeSOList;
    [SerializeField] private BuildScript blueprint;

    private void Awake()
    {
        int index = 0;
        Transform btnTemplate = transform.Find("Plant_01");
        btnTemplate.gameObject.SetActive(false);
        foreach(BuildingTypeSO buildingTypeSO in buildingTypeSOList)
        {
            Transform btnTransform = Instantiate(btnTemplate, transform);
            btnTransform.gameObject.SetActive(true);

            btnTransform.GetComponent<RectTransform>().anchoredPosition += new Vector2(index *60,0);
            btnTransform.Find("Label").GetComponent<TextMeshProUGUI>().text = buildingTypeSO.nameString;

            btnTransform.GetComponent<Button>().onClick.AddListener(() =>
            {
                blueprint.SetActiveBuildingType(buildingTypeSO);
                
            });
            
            index++;
        }
    }
}
