using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public GameObject hoveredObject;
    //public GameObject selectedObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        
        if(Physics.Raycast(ray, out hitInfo) && hitInfo.transform.gameObject.tag == "Selectable")
        {
            GameObject hitObject = hitInfo.transform.gameObject;
            Debug.Log("Mouse is over:" + hitObject.tag);
            SelectObject(hitObject);
        }
        else 
        {
            ClearSelection();
        }

        //if (Input.GetMouseButtonDown(0))
        //{
        //    selectedObject = hoveredObject;
        //}
    }


    void SelectObject(GameObject obj)
    {
        if(hoveredObject !=null)
        {
            if (obj == hoveredObject)
                return;

            ClearSelection();
        }
        hoveredObject = obj;

        //If Color Change i wanted --> 

        //Renderer[] rs = hoveredObject.GetComponentsInChildren<Renderer>();
        //foreach(Renderer r in rs)
        //{
        //    Material m = r.materials[0];
        //    m.color = Color.green;
        //    r.material = m;
        //}
    }

    void ClearSelection()
    {
        if(hoveredObject == null)
        { 
            return;
        }

        //If Color Change i wanted --> 

        //Renderer[] rs = hoveredObject.GetComponentsInChildren<Renderer>();
        //foreach (Renderer r in rs)
        //{
        //    Material m = r.materials[0];
        //    m.color = Color.white;
        //    r.material = m;
        //}

        hoveredObject = null;
    }
}