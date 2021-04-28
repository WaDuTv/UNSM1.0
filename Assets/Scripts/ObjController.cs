using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Doozy.Engine.UI;
using System.Linq;

public class ObjController : MonoBehaviour
{
    MouseManager mm;
    public PickUp pickUpFunction;
    public GameObject deskcam;
    public GameObject maincam;
    public GameObject buildMenuUI;
    public GameObject deskMenuUI;
    public float transspeed = 0.125f;
    public GameObject indicators;
    public GameObject fademanager;
    public GameObject desktopGraph;
    public UICanvas desktopCanvas;
    public UIView desktopView;
    public UIView overviewView;

    
    //public FadeObjects faderadius;

    private void Start()
    {
        mm = GameObject.FindObjectOfType<MouseManager>();
        //deskMenuUI = GameObject.Find("MenuManager");
        //buildMenuUI = GameObject.Find("BuildCanvas");
        //maincam = GameObject.FindGameObjectWithTag("worldcam");

    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, (1 << 7)))
        {
            if (hit.collider != null)
            {
                OnMouseDown();                
            }
        }
    }
    public void OnMouseDown()
    {
        if(Input.GetMouseButton(0))
        {

            //pickUpFunction.enabled = false;
            //deskcam.SetActive(true);
            //if (maincam.activeSelf)
            //{
            //    maincam.SetActive(false);

            //}
            //buildMenuUI.SetActive(false);
            //FadeObjects fadesettings = fademanager.GetComponent<FadeObjects>();
            //fadesettings.maxTransparency = 1f;
            //fadesettings.radius = 0f;
            //fademanager.GetComponent<FadeObjects>().enabled = false;
            //indicators.SetActive(false);
            desktopGraph.SetActive(true);
            desktopView.Show();
            
            
            
            //GameObject.Find("MainCameraRig").GetComponent<CameraController>().enabled = false;
        }

    }

    public void ReactivateFunctions()
    {
        indicators.SetActive(true);
        //fademanager.GetComponent<FadeObjects>().enabled = true;
        FadeObjects fadesettings = fademanager.GetComponent<FadeObjects>();
        fadesettings.maxTransparency = 0f;
        fadesettings.radius = 4f;
    }
  
}