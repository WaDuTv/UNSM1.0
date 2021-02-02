using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class gridManager : MonoBehaviour
{
    private Grid grid;
    private Vector3 currentMouseposition;
    [SerializeField] private LayerMask mouseColliderLayerMask;
    
    // Start is called before the first frame update
    private void Start()
    {
        grid = new Grid(60,60, 5f, new Vector3(-130,17,-130));
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit hit, 999f, mouseColliderLayerMask))
        {
            currentMouseposition = hit.point;
        }

        if(Input.GetMouseButtonDown(0))
        {
           grid.SetValue(currentMouseposition,2);              
        }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(grid.GetValue(currentMouseposition));
        }

    }
}
