using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class GridTest : MonoBehaviour
{
    private Grid <HeatMapObject>grid;
    // Start is called before the first frame update
    void Start()
    {
        grid = new Grid<HeatMapObject>(4, 2, 10f, Vector3.zero, (Grid<HeatMapObject> g, int x, int z) => new HeatMapObject(g, x,z));
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //Vector3 position = UtilsClass.GetMouseWorldPosition();

            Plane plane = new Plane(Vector3.up, Vector3.zero);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            float entry;

            if (plane.Raycast(ray, out entry))
            {
                Debug.Log(Input.mousePosition);
                //HeatMapObject heatMapObject = grid.GetGridObject(entry);
                //if (heatMapObject != null)
                //{
                //    heatMapObject.AddValue(5);
                //}
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(UtilsClass.GetMouseWorldPosition());
        }
    }

}

public class HeatMapObject
{
    private const int MIN = 0;
    private const int MAX = 100;

    private Grid<HeatMapObject> grid;
    private int x;
    private int z;
    public int value;

    public HeatMapObject(Grid<HeatMapObject> grid, int x, int z)
    {
        this.grid = grid;
        this.x = x;
        this.z = z;
    }
    
    public void AddValue(int addValue)
    {
        value += addValue;
        value = Mathf.Clamp(value, MIN, MAX);
        grid.TriggerGridObjectChanged(x, z);
    }

    public float GetValueNormalized()
    {
        return (float)value / MAX;
    }

    public override string ToString()
    {
        return value.ToString();
    }
}