using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Reflection;

public class MenuManager : MonoBehaviour
{
    public GameObject maincam;

    public GameObject buildUI;
    public  GameObject deskUI;
    

    //private void Awake()
    //{
        
    //}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SwitchBuildUI()
    {
        
        if (buildUI.activeInHierarchy)
        {
            
            buildUI.SetActive(false);
        }
        else
        {
            buildUI.SetActive(true);
            
        }
            
    }

    public void ExitDeskUI()
    {
        maincam.SetActive(true);
        //deskcam.SetActive(false);
        GameObject.Find("MainCameraRig").GetComponent<CameraController>().enabled = true;
    }

}
