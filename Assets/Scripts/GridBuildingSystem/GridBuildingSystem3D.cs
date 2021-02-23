using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using CodeMonkey.Utils;

public class GridBuildingSystem3D : MonoBehaviour {

    public static GridBuildingSystem3D Instance { get; private set; }

    public event EventHandler OnSelectedChanged;
    public event EventHandler OnObjectPlaced;


    private Grid<GridObject> grid;
    [SerializeField] public List<BuildingTypeSO> placedObjectTypeSOList = null;
    public BuildingTypeSO placedObjectTypeSO;
    private BuildingTypeSO.Dir dir;

    public ShopScript shopSystem;

    private void Awake() {
        Instance = this;

        int gridWidth = 10;
        int gridHeight = 11;
        float cellSize = 1f;
        grid = new Grid<GridObject>(gridWidth, gridHeight, cellSize, new Vector3(-1, 17, -48), (Grid<GridObject> g, int x, int y) => new GridObject(g, x, y));

        placedObjectTypeSO = null;
    }

    public class GridObject {

        private Grid<GridObject> grid;
        private int x;
        private int y;
        public PlacedObject placedObject;

        public GridObject(Grid<GridObject> grid, int x, int y) {
            this.grid = grid;
            this.x = x;
            this.y = y;
            placedObject = null;
        }

        public override string ToString() {
            return x + ", " + y + "\n" + placedObject;
        }

        public void SetPlacedObject(PlacedObject placedObject) {
            this.placedObject = placedObject;
            grid.TriggerGridObjectChanged(x, y);
        }

        public void ClearPlacedObject() {
            placedObject = null;
            grid.TriggerGridObjectChanged(x, y);
        }

        public PlacedObject GetPlacedObject() {
            return placedObject;
        }

        public bool CanBuild() {
            return placedObject == null;
        }

    }

    private void Update() {
        if (Input.GetMouseButtonDown(0) && placedObjectTypeSO != null) {
            Vector3 mousePosition = Mouse3D.GetMouseWorldPosition();
            grid.GetXZ(mousePosition, out int x, out int z);

            Vector2Int placedObjectOrigin = new Vector2Int(x, z);
            placedObjectOrigin = grid.ValidateGridPosition(placedObjectOrigin);

            int currentMoney = shopSystem.bankamount;

            if (currentMoney >= placedObjectTypeSO.objectPrice)
            {

                // Test Can Build
                List<Vector2Int> gridPositionList = placedObjectTypeSO.GetGridPositionList(placedObjectOrigin, dir);
                bool canBuild = true;
                foreach (Vector2Int gridPosition in gridPositionList)
                {
                    if (!grid.GetGridObject(gridPosition.x, gridPosition.y).CanBuild())
                    {
                        canBuild = false;
                        break;
                    }
                }

                if (canBuild)
                {
                    Vector2Int rotationOffset = placedObjectTypeSO.GetRotationOffset(dir);
                    Vector3 placedObjectWorldPosition = grid.GetWorldPosition(placedObjectOrigin.x, placedObjectOrigin.y) + new Vector3(rotationOffset.x, 0, rotationOffset.y) * grid.GetCellSize();

                    if (EventSystem.current.IsPointerOverGameObject())
                        return;

                    PlacedObject placedObject = PlacedObject.Create(placedObjectWorldPosition, placedObjectOrigin, dir, placedObjectTypeSO);

                    foreach (Vector2Int gridPosition in gridPositionList)
                    {
                        grid.GetGridObject(gridPosition.x, gridPosition.y).SetPlacedObject(placedObject);
                    }
                    
                    OnObjectPlaced?.Invoke(this, EventArgs.Empty);

                    //DeselectObjectType();

                    int newMoney = currentMoney - placedObjectTypeSO.objectPrice;
                    shopSystem.bankamount = newMoney;

                }
                else
                {
                    // Cannot build here
                    UtilsClass.CreateWorldTextPopup("Cannot Build Here!", mousePosition);
                }

            }
            else
            {
                // Not enough money
                UtilsClass.CreateWorldTextPopup("Not enough Money!", mousePosition);
                DeselectObjectType();
            }
        }

        if (Input.GetKeyDown(KeyCode.Period)) {
            dir = BuildingTypeSO.GetNextDir(dir);
        }       

        if (Input.GetMouseButtonDown(1)) { DeselectObjectType(); }


        if (Input.GetKeyDown(KeyCode.Delete)) {
            Vector3 mousePosition = Mouse3D.GetMouseWorldPosition();
            if (grid.GetGridObject(mousePosition) != null) {
                // Valid Grid Position
                PlacedObject placedObject = grid.GetGridObject(mousePosition).GetPlacedObject();
                if (placedObject != null) {
                    // Demolish
                    placedObject.DestroySelf();

                    List<Vector2Int> gridPositionList = placedObject.GetGridPositionList();
                    foreach (Vector2Int gridPosition in gridPositionList) {
                        grid.GetGridObject(gridPosition.x, gridPosition.y).ClearPlacedObject();
                    }
                }
            }
        }
    }

    private void DeselectObjectType() {
        placedObjectTypeSO = null; RefreshSelectedObjectType();
    }

    public void RefreshSelectedObjectType() {
        OnSelectedChanged?.Invoke(this, EventArgs.Empty);
    }


    public Vector2Int GetGridPosition(Vector3 worldPosition) {
        grid.GetXZ(worldPosition, out int x, out int z);
        return new Vector2Int(x, z);
    }

    public Vector3 GetMouseWorldSnappedPosition() {
        Vector3 mousePosition = Mouse3D.GetMouseWorldPosition();
        grid.GetXZ(mousePosition, out int x, out int z);

        if (placedObjectTypeSO != null) {
            Vector2Int rotationOffset = placedObjectTypeSO.GetRotationOffset(dir);
            Vector3 placedObjectWorldPosition = grid.GetWorldPosition(x, z) + new Vector3(rotationOffset.x, 0, rotationOffset.y) * grid.GetCellSize();
            return placedObjectWorldPosition;
        } else {
            return mousePosition;
        }
    }

    public Quaternion GetPlacedObjectRotation() {
        if (placedObjectTypeSO != null) {
            return Quaternion.Euler(0, placedObjectTypeSO.GetRotationAngle(dir), 0);
        } else {
            return Quaternion.identity;
        }
    }

    public BuildingTypeSO GetPlacedObjectTypeSO() {
        return placedObjectTypeSO;
    }    

}
