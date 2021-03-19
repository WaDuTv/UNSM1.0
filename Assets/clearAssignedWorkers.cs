using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clearAssignedWorkers : MonoBehaviour
{    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClearWorkers()
    {
        Transform[] ts = gameObject.GetComponentsInChildren<Transform>();

        foreach(Transform t in ts)
        {
            if (t != null && t != this.transform)
            { Destroy(t.gameObject); }
        }
    }
}
