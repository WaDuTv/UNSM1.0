using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class CamSwitcher : MonoBehaviour
{
    [SerializeField]
    public InputAction action;
    [SerializeField]
    private CinemachineVirtualCamera vcam1; //Mainview Camera
    [SerializeField]
    private CinemachineVirtualCamera vcam2; //Desk Camera
    private Animator animator;
    public bool mainCamera = true;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void onEnable()
    {
        action.Enable();
    }

    private void onDisable()
    {
        action.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        action.performed += _ => SwitchState();

    }
    private void SwitchState()
    {
        if (mainCamera)
        {
            animator.Play("Desk");
        }
        else
        {
            animator.Play("Main");
        }
        mainCamera = !mainCamera;
    }
    private void SwitchPriority()
    {
        if (Input.GetKey(KeyCode.Space)) 
        {
            vcam1.Priority = 0;
            vcam2.Priority = 1;
        }
        else
        {
            vcam1.Priority = 1;
            vcam2.Priority = 0;
        }
        mainCamera = !mainCamera;
    }

}
