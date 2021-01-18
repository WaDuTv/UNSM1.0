using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    public GameObject buildUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("Worldview").activeSelf)
        {
            buildUI.SetActive(true);
        }
        else
        {
            buildUI.SetActive(false);
        }
    }
}
