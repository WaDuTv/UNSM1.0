using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum CameraType
{
    MainCam,
    DeskCam
}
public class CameraManager : Singleton<CameraManager>
{
    List<CameraControllerA> cameraControllerList;
    CameraControllerA lastActiveCamera;

    protected override void Awake()
    {
        cameraControllerList = GetComponentsInChildren<CameraControllerA>().ToList();
        cameraControllerList.ForEach(x => x.gameObject.SetActive(false));
        SwitchCamera(CameraType.MainCam);

    }

    public void SwitchCamera(CameraType _type)
    {
        if (lastActiveCamera != null)
        {
            lastActiveCamera.gameObject.SetActive(false);
        }

        CameraControllerA desiredCamera = cameraControllerList.Find(x => x.cameraType == _type);
        if (desiredCamera != null)
        {
            desiredCamera.gameObject.SetActive(true);
            lastActiveCamera = desiredCamera;
        }
        else Debug.LogWarning("Kamera wurde nicht gefunden!");
    }

}
