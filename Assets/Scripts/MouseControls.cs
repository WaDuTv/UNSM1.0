// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/MouseControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MouseControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MouseControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MouseControls"",
    ""maps"": [
        {
            ""name"": ""Mouse"",
            ""id"": ""0639ee43-3416-4000-8424-e0463db8c6a2"",
            ""actions"": [
                {
                    ""name"": ""Zoom"",
                    ""type"": ""PassThrough"",
                    ""id"": ""51c53b84-eab3-4239-877c-4b5d60bb7144"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": ""Normalize(min=-1,max=1),Invert"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Click"",
                    ""type"": ""Button"",
                    ""id"": ""93136769-e798-443d-9955-5204e4eca354"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""Normalize(min=-1,max=1),Invert"",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Position"",
                    ""type"": ""PassThrough"",
                    ""id"": ""3f7d4bf2-a551-4aa1-b22d-0d5a22ee45d7"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""Normalize(min=-1,max=1),Invert"",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""461b669d-778e-4bc3-a654-41068db41c8b"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": ""Normalize(min=-1,max=1)"",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""26bcc028-6269-4590-8cfd-e6317cdcb817"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fc5f3ff3-d139-4003-a265-d73a4a0908ed"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Position"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""asd"",
            ""bindingGroup"": ""asd"",
            ""devices"": []
        }
    ]
}");
        // Mouse
        m_Mouse = asset.FindActionMap("Mouse", throwIfNotFound: true);
        m_Mouse_Zoom = m_Mouse.FindAction("Zoom", throwIfNotFound: true);
        m_Mouse_Click = m_Mouse.FindAction("Click", throwIfNotFound: true);
        m_Mouse_Position = m_Mouse.FindAction("Position", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Mouse
    private readonly InputActionMap m_Mouse;
    private IMouseActions m_MouseActionsCallbackInterface;
    private readonly InputAction m_Mouse_Zoom;
    private readonly InputAction m_Mouse_Click;
    private readonly InputAction m_Mouse_Position;
    public struct MouseActions
    {
        private @MouseControls m_Wrapper;
        public MouseActions(@MouseControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Zoom => m_Wrapper.m_Mouse_Zoom;
        public InputAction @Click => m_Wrapper.m_Mouse_Click;
        public InputAction @Position => m_Wrapper.m_Mouse_Position;
        public InputActionMap Get() { return m_Wrapper.m_Mouse; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MouseActions set) { return set.Get(); }
        public void SetCallbacks(IMouseActions instance)
        {
            if (m_Wrapper.m_MouseActionsCallbackInterface != null)
            {
                @Zoom.started -= m_Wrapper.m_MouseActionsCallbackInterface.OnZoom;
                @Zoom.performed -= m_Wrapper.m_MouseActionsCallbackInterface.OnZoom;
                @Zoom.canceled -= m_Wrapper.m_MouseActionsCallbackInterface.OnZoom;
                @Click.started -= m_Wrapper.m_MouseActionsCallbackInterface.OnClick;
                @Click.performed -= m_Wrapper.m_MouseActionsCallbackInterface.OnClick;
                @Click.canceled -= m_Wrapper.m_MouseActionsCallbackInterface.OnClick;
                @Position.started -= m_Wrapper.m_MouseActionsCallbackInterface.OnPosition;
                @Position.performed -= m_Wrapper.m_MouseActionsCallbackInterface.OnPosition;
                @Position.canceled -= m_Wrapper.m_MouseActionsCallbackInterface.OnPosition;
            }
            m_Wrapper.m_MouseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Zoom.started += instance.OnZoom;
                @Zoom.performed += instance.OnZoom;
                @Zoom.canceled += instance.OnZoom;
                @Click.started += instance.OnClick;
                @Click.performed += instance.OnClick;
                @Click.canceled += instance.OnClick;
                @Position.started += instance.OnPosition;
                @Position.performed += instance.OnPosition;
                @Position.canceled += instance.OnPosition;
            }
        }
    }
    public MouseActions @Mouse => new MouseActions(this);
    private int m_asdSchemeIndex = -1;
    public InputControlScheme asdScheme
    {
        get
        {
            if (m_asdSchemeIndex == -1) m_asdSchemeIndex = asset.FindControlSchemeIndex("asd");
            return asset.controlSchemes[m_asdSchemeIndex];
        }
    }
    public interface IMouseActions
    {
        void OnZoom(InputAction.CallbackContext context);
        void OnClick(InputAction.CallbackContext context);
        void OnPosition(InputAction.CallbackContext context);
    }
}
