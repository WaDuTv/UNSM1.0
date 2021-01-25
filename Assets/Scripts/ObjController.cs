using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ObjController : MonoBehaviour
{
    public PickUp pickUpFunction;
    public GameObject deskcam;
    public GameObject maincam;
    public GameObject buildMenuUI;
    public GameObject deskMenuUI;
    public float transspeed = 0.125f;
    public GameObject indicators;

    private void Start()
    {        
        deskMenuUI = GameObject.Find("MenuManager");
        buildMenuUI = GameObject.Find("BuildCanvas");
        maincam = GameObject.FindGameObjectWithTag("worldcam");

    }
    public void OnMouseDown()
    {
        indicators = GameObject.Find("UI Selection Indicator");
        indicators.GetComponent<UISelectionIndicator>().enabled = false;
        pickUpFunction.enabled = false;
        deskcam.SetActive(true);
        if (maincam.activeSelf)
        {
            maincam.SetActive(false);
        
        }
        buildMenuUI.SetActive(false);

        deskMenuUI.GetComponent<MenuManager>().deskUI.SetActive(true);        
        GameObject.Find("MainCameraRig").GetComponent<CameraController>().enabled = false;
        

    }
  
}