using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    RaycastHit hit;

    private void OnMouseDrag()
    {

        if (GetComponent<PickUp>().enabled)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Terrain.activeTerrain.GetComponent<Collider>().Raycast(ray, out hit, 50000.0f))
            {
                transform.position = hit.point;//+ new Vector3(0, 0, 0); <= Lift up
                Debug.Log("Moved Something!");
            }
        }
        else
        {
            return;
        }
    }
}
    
