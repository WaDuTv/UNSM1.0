using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    RaycastHit hit;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

    }
    private void OnMouseDrag()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 50000.0f, (1 << 3)))
        {
            this.transform.position = hit.point; //+ new Vector3(0, 0, 0); <= Lift up
        }
    }
    
    //void DragObject()
    //{
    //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

    //    if (Physics.Raycast(ray, out hit, 50000.0f, (1 << 3)))
    //    {
    //        this.transform.position = hit.point + new Vector3(0, 0.2f, 0);            
    //    }        
    //}

}

    
