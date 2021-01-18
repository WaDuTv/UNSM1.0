using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CanvasSwitcher : MonoBehaviour
{
    public CanvasType desiredCanvasType;

    InGameUIManager inGameUIManager;
    Button menuButton;

    // Start is called before the first frame update
    void Start()
    {
        menuButton = GetComponent<Button>();
        menuButton.onClick.AddListener(OnButtonClicked);
        inGameUIManager = InGameUIManager.GetInstance();
    }

    void OnButtonClicked()
    {
        inGameUIManager.SwitchCanvas(desiredCanvasType);
    }
    
}
