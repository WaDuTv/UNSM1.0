using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    public Transform followTransform;
    public Transform cameraTransform;
    public float normalSpeed;
    public float fastSpeed;
    public float movementSpeed;
    public float movementTime;
    public float rotationAmount;
    public Vector3 zoomAmount;
    public Vector3 zoomAmountMouse;
    public float maxLeft;
    public float maxRight;
    public float maxUp;
    public float maxDown;
    public GameObject worldviewcam;

    public Vector3 newPosition;
    public Quaternion newRotation;
    public Vector3 newZoom;

    public Vector3 dragStartPosition;
    public Vector3 dragCurrentPosition;
    public Vector3 rotateStartPosition;
    public Vector3 rotateCurrentPosition;

    // Start is called before the first frame update
    void Start()
    {
        newPosition = transform.position;
        newRotation = transform.rotation;
        newZoom = cameraTransform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (followTransform != null)
        {
            transform.position = followTransform.position;
        }
        else
        {
            HandleMouseInput();
            HandleMovementInput();
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            followTransform = null;
        }

        if (transform.position.x <= maxLeft || transform.position.x >= maxRight || transform.position.z <= maxDown || transform.position.z >= maxUp)
        {
            normalSpeed = 0f;
            fastSpeed = 0f;
        }
        if (transform.position.x <= maxLeft)
        {
            newPosition.x = newPosition.x = -43;
            normalSpeed = 0.2f;
            fastSpeed = 0.5f;
        }
        if (transform.position.x >= maxRight)
        {
            newPosition.x = newPosition.x = 59;
            normalSpeed = 0.2f;
            fastSpeed = 0.5f;
        }
        if (transform.position.z <= maxDown)
        {
            newPosition.z = newPosition.z = -45;
            normalSpeed = 0.2f;
            fastSpeed = 0.5f;
        }
        if (transform.position.z >= maxUp)
        {
            newPosition.z = newPosition.z = 43;
            normalSpeed = 0.2f;
            fastSpeed = 0.5f;
        }

    }
    void HandleMouseInput()
    {
        zoomView();
        //if (Input.mouseScrollDelta.y != 0)
        //{
        //    newZoom += Input.mouseScrollDelta.y * zoomAmountMouse;
        //}
        if (Input.GetMouseButtonDown(1))
        {
            Plane plane = new Plane(Vector3.up, Vector3.zero);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            float entry;

            if (plane.Raycast(ray, out entry))
            {
                dragStartPosition = ray.GetPoint(entry);
            }
        }
        if (Input.GetMouseButton(1))
        {
            Plane plane = new Plane(Vector3.up, Vector3.zero);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            float entry;

            if (plane.Raycast(ray, out entry))
            {
                dragCurrentPosition = ray.GetPoint(entry);

                newPosition = transform.position + dragStartPosition - dragCurrentPosition;
            }
            
        }
        if (Input.GetMouseButtonDown(2))
        {
            rotateStartPosition = Input.mousePosition;
        }
        if (Input.GetMouseButton(2))
        {
            rotateCurrentPosition = Input.mousePosition;

            Vector3 difference = rotateStartPosition - rotateCurrentPosition;

            rotateStartPosition = rotateCurrentPosition;

            newRotation *= Quaternion.Euler(Vector3.up * (-difference.x / 5f));
        }

    }
    void HandleMovementInput()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = fastSpeed;
        }
        else
        {
            movementSpeed = normalSpeed;
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            newPosition += (transform.forward * movementSpeed);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            newPosition += (transform.forward * -movementSpeed);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            newPosition += (transform.right * movementSpeed);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            newPosition += (transform.right * -movementSpeed);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            newRotation *= Quaternion.Euler(Vector3.up * rotationAmount);
        }
        if (Input.GetKey(KeyCode.E))
        {
            newRotation *= Quaternion.Euler(Vector3.up * -rotationAmount);
        }
        if (Input.GetKey(KeyCode.R))
        {
            newZoom += zoomAmount;
        }
        if (Input.GetKey(KeyCode.F))
        {
            newZoom += -zoomAmount;
        }

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * movementTime);
        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, newZoom, Time.deltaTime * movementTime);
    }


    void zoomView()
    {        
        if (worldviewcam.activeSelf)
        {
            CinemachineVirtualCamera zoomCam = GameObject.Find("Worldview").GetComponent<CinemachineVirtualCamera>();

            if (Input.mouseScrollDelta.y != 0)
            {
                zoomCam.m_Lens.FieldOfView = zoomCam.m_Lens.FieldOfView + Input.mouseScrollDelta.y * Time.deltaTime;
            }
        }

    }
}
