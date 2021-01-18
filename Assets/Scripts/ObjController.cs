using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ObjController : MonoBehaviour
{
    public GameObject deskcam;
    public GameObject maincam;
    public GameObject maincontroller;
    public float transspeed = 0.125f;
    Transform currentView;

    InGameUIManager inGameUIManager;

    private void Start()
    {
        inGameUIManager = InGameUIManager.GetInstance();
        maincam = GameObject.FindGameObjectWithTag("worldcam");
    }
    public void OnMouseDown()
    {
        inGameUIManager.SwitchCanvas(CanvasType.None);
        deskcam.SetActive(true);
        if (maincam.gameObject.activeSelf)
        {
            maincam.SetActive(false);
        }
        GameObject.Find("MainCameraRig").GetComponent<CameraController>().enabled = false;
        

    }

    //public void LeaveMenu()
    private void LateUpdate()
    {

        if (Input.GetKey(KeyCode.Escape))
        {
            maincam.SetActive(true);
            deskcam.SetActive(false);            
            GameObject.Find("MainCameraRig").GetComponent<CameraController>().enabled = true;
            
        }

    }
   
}