using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildScript : MonoBehaviour
{
    private BuildingTypeSO activeBuildingType;
    private BuildingTypeSO finalBuildingType;
    [SerializeField] private BuildingTypeSO _temp;
    private List<BuildingTypeSO> objList;

    private void Start()
    {
        activeBuildingType = _temp;
    }
    private void Update()
    {        
        //Debug.Log(activeBuildingType.prefab);
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Placement of" + activeBuildingType.prefab);
        }
    }

    public void SetActiveBuildingType(BuildingTypeSO buildingTypeSO)
    {
        activeBuildingType = buildingTypeSO;
        Instantiate(activeBuildingType.prefab);
    }

}
