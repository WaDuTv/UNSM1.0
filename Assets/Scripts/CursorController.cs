using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CursorController : MonoBehaviour
{
    // Start is called before the first frame update

    public Texture2D cursor;
    public Texture2D cursorClicked;
    
    private MouseControls controls;

    private Camera mainCamera;
    public GameObject deskcam;
    public GameObject maincam;

    private void Awake()
    {

        controls = new MouseControls();
        ChangeCursor(cursor);
        Cursor.lockState = CursorLockMode.None;
        mainCamera = Camera.main;

    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Start()
    {
        controls.Mouse.Click.started += _ => StartedClick();
        controls.Mouse.Click.performed += _ => EndedClick();
    }

    private void Update()
    {
        
    }

    private void StartedClick()
    {
        ChangeCursor(cursorClicked);
    }

    private void EndedClick()
    {
        ChangeCursor(cursor);
        DetectObject();
    }


    private void DetectObject()
    {
        //3D
        Ray ray = mainCamera.ScreenPointToRay(controls.Mouse.Position.ReadValue<Vector2>());
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit,Mathf.Infinity/*, (1 << 7))*/))
        {
            if(hit.collider !=null)
            {
                //hit.collider.gameObject.GetComponent<IClicked>().OnClickAction();
               //if(hit.collider.gameObject.tag == "ChiefDesk")
               // {
               //     // deskcam = GameObject.FindGameObjectWithTag("ChiefDesk").GetComponentInChildren<desk;
               //     //deskcam.SetActive(true); 
               //     deskcam = hit.collider.gameObject.GetComponentInParent<ObjController>().deskcam;
               //     deskcam.SetActive(true);
                   
               // }
                 Debug.Log("3d Hit:" + hit.collider.gameObject.name);
            }
        }
    }

    private void ChangeCursor(Texture2D cursorType)
    {
        //Vector2 hotspot = new Vector2(cursorType.width / 2, cursorType.height / 2);
        Cursor.SetCursor(cursorType, Vector2.zero, CursorMode.Auto);
    }
    

}
