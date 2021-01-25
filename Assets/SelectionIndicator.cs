using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionIndicator : MonoBehaviour
{
    MouseManager mm;

    // Start is called before the first frame update
    void Start()
    {
        mm = GameObject.FindObjectOfType<MouseManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(mm.hoveredObject != null)
        {
            GetComponentInChildren<Renderer>().enabled = true;
            Bounds bigBounds = mm.hoveredObject.GetComponentInChildren<Renderer>().bounds;

            Renderer[] rs = mm.hoveredObject.GetComponentsInChildren<Renderer>();
            foreach(Renderer r in rs)
            {
                bigBounds.Encapsulate(r.bounds);
            }

            float padding = 1.0f;

            this.transform.position = new Vector3(bigBounds.center.x, bigBounds.center.y, bigBounds.center.z);
            this.transform.localScale = new Vector3(bigBounds.size.x* padding, bigBounds.size.y * padding, bigBounds.size.z * padding);
        }
        else
        {
            GetComponentInChildren<Renderer>().enabled = false;
        }
        
    }
}
