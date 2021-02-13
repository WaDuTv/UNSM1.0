using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildScript : MonoBehaviour
{
    private BuildingTypeSO activeBuildingType;    
    [SerializeField] private BuildingTypeSO _temp;
    public GridBuildingSystem3D gridBuildingSystem3D;
    public List<BuildingTypeSO> objList;
    

    private void Start()
    {
        //objList = gridBuildingSystem3D.placedObjectTypeSOList;
        activeBuildingType = _temp;    
    }
    private void Update()
    {                
        if(Input.GetMouseButtonDown(0))
        {
            
        }
    }

    public void SetActiveBuildingType(BuildingTypeSO buildingTypeSO)
    {        
        activeBuildingType = buildingTypeSO;
        Instantiate(activeBuildingType.prefab);
    }

}
