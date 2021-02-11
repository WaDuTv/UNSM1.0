using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacedObject : MonoBehaviour
{

    private BuildingTypeSO buildingTypeSO;
    private Vector2Int origin;
    private BuildingTypeSO.Dir dir;

    public static PlacedObject Create(Vector3 worldPosition, Vector2Int origin, BuildingTypeSO.Dir dir, BuildingTypeSO buildingTypeSO)
    {
        Transform placedObjectTransform = Instantiate(buildingTypeSO.prefab, worldPosition, Quaternion.Euler(0, buildingTypeSO.GetRotationAngle(dir), 0));

        PlacedObject placedObject = placedObjectTransform.GetComponent<PlacedObject>();

        placedObject.buildingTypeSO = buildingTypeSO;
        placedObject.origin = origin;

        return placedObject;
    }

    public List<Vector2Int> GetGridPositionList()
    {
        return buildingTypeSO.GetGridPositionList(origin, dir);
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }


}
