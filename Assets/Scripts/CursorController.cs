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
        //HighlightObject();
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
        if(Physics.Raycast(ray, out hit,Mathf.Infinity, (1 << 7)))
        {
            if(hit.collider !=null)
            {
               if(hit.collider.gameObject.tag == "ChiefDesk")
                {
                    // deskcam = GameObject.FindGameObjectWithTag("ChiefDesk").GetComponentInChildren<desk;
                    //deskcam.SetActive(true); 
                    deskcam = hit.collider.gameObject.GetComponentInParent<ObjController>().deskcam;
                    deskcam.SetActive(true);
                   
                }
                    //Debug.Log("3d Hit:" + hit.collider.gameObject.name + " Active Cameras" + Camera.allCameras);
            }
        }
    }

    //public void HighlightObject()
    //{
    //    //3D
    //    Ray ray = mainCamera.ScreenPointToRay(controls.Mouse.Position.ReadValue<Vector2>());
    //    RaycastHit hit;
    //    if (Physics.Raycast(ray, out hit))
    //    {
    //        if (hit.collider != null)
    //        {
    //            if (hit.collider.gameObject.tag == "Furniture")
    //            {
    //                if (hit.collider.gameObject.GetComponent<Outline>() == null)
    //                {
    //                    var outline = hit.collider.gameObject.AddComponent<Outline>();

    //                    outline.OutlineMode = Outline.Mode.OutlineAll;
    //                    outline.OutlineColor = Color.yellow;
    //                    outline.OutlineWidth = 1f;
    //                }
    //                if (hit.collider.gameObject.GetComponent<Outline>() != null)
    //                    hit.collider.gameObject.GetComponent<Outline>();
    //                Destroy(hit.collider.gameObject.GetComponent<Outline>());
    //            }

    //        }
    //        if (hit.collider == null)
    //        {

    //        }
    //    }
    //}


    private void ChangeCursor(Texture2D cursorType)
    {
        //Vector2 hotspot = new Vector2(cursorType.width / 2, cursorType.height / 2);
        Cursor.SetCursor(cursorType, Vector2.zero, CursorMode.Auto);
    }
    

}
