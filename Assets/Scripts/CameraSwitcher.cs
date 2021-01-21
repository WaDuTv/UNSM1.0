using UnityEngine;
using UnityEngine.UI;

//[RequireComponent(typeof(Button))]
public class CameraSwitcher : MonoBehaviour
{
    public CameraType desiredCameraType;

    CameraManager cameraManager;
    //Button menuButton;

    // Start is called before the first frame update
    void Start()
    {
        //menuButton = GetComponent<Button>();
        //menuButton.onClick.AddListener(OnButtonClicked);
        cameraManager = CameraManager.GetInstance();
    }

    void OnButtonClicked()
    {
        cameraManager.SwitchCamera(desiredCameraType);
    }

}
