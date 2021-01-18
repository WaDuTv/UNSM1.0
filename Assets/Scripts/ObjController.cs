using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjController : MonoBehaviour
{
    public GameObject deskcam;
    public GameObject maincam;
    public GameObject maincontroller;
    public float transspeed = 0.125f;
    Transform currentView;

    private void Start()
    {
        maincam = GameObject.FindGameObjectWithTag("worldcam");
    }
    public void OnMouseDown()
    {
        
        deskcam.SetActive(true);
        if (maincam.gameObject.activeSelf)
        {
            maincam.SetActive(false);
        }
        GameObject.Find("MainCameraRig").GetComponent<CameraController>().enabled = false;
        

    }
    void Update()
    {

        if (Input.GetKey(KeyCode.Escape))
        {
            
            if (maincam.gameObject.activeSelf)
            {
            
            }
            maincam.SetActive(true);
            deskcam.SetActive(false);            
            GameObject.Find("MainCameraRig").GetComponent<CameraController>().enabled = true;
            
        }

    }
}