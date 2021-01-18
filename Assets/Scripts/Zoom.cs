using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Zoom : MonoBehaviour
{
    [SerializeField]
    public float zoomSpeed = 3f;
    [SerializeField]
    public float zoomInMax = 40f;
    [SerializeField]
    public float zoomOutMax = 90f;
    private CinemachineInputProvider inputProvider;
    private CinemachineVirtualCamera virtualCamera;

    private void Awake()
    {
        inputProvider = GetComponent<CinemachineInputProvider>();
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float z = inputProvider.GetAxisValue(2);
        if (z != 0)
        {
            ZoomScreen(z);
        }
    }
    public void ZoomScreen(float increment)
    {
        float fov = virtualCamera.m_Lens.FieldOfView;
        float target = Mathf.Clamp(fov + increment, zoomInMax, zoomOutMax);
        virtualCamera.m_Lens.FieldOfView = Mathf.Lerp(fov, target, zoomSpeed * Time.deltaTime);
    }
}
