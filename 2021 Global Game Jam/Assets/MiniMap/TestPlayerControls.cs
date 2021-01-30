// GENERATED AUTOMATICALLY FROM 'Assets/MiniMap/TestPlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @TestPlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @TestPlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""TestPlayerControls"",
    ""maps"": [
        {
            ""name"": ""testplayercontrols"",
            ""id"": ""9634e6d3-e4ac-4716-826d-517180257195"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""a8b11695-b5f0-4bf9-9693-9ef0e21bafdf"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Light"",
                    ""type"": ""Button"",
                    ""id"": ""b70e69ea-0ce3-4156-8079-32ccaa9a0cb2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Mouse"",
                    ""type"": ""Value"",
                    ""id"": ""12accc64-bbbe-4a81-bd22-029f64d87534"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sonar"",
                    ""type"": ""Button"",
                    ""id"": ""0a5b5ab2-7bc9-40d4-978e-a0a56ca7eb53"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""ac4bf07b-b721-46b1-9dd2-b4a6d719926d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""54ecffca-3c6c-48d9-8ad1-9ad2c0ca8b5e"",
                    ""path"": ""<Keyboard>/#(W)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ee2d8d31-a315-427e-bfdb-9013a5183196"",
                    ""path"": ""<Keyboard>/#(S)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4a35f3a4-46a5-42ed-b365-e505b90144c4"",
                    ""path"": ""<Keyboard>/#(A)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d065719a-bc79-4dca-9095-d7cc8be812ca"",
                    ""path"": ""<Keyboard>/#(D)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""49005a0d-96d1-4697-8d1b-7618e082c4aa"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Light"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f393c16b-db6d-46cd-8a91-fbecc34a7bf3"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Mouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9e02b98c-d40e-4253-ad29-aa89b2016ba4"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Sonar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": []
        }
    ]
}");
        // testplayercontrols
        m_testplayercontrols = asset.FindActionMap("testplayercontrols", throwIfNotFound: true);
        m_testplayercontrols_Move = m_testplayercontrols.FindAction("Move", throwIfNotFound: true);
        m_testplayercontrols_Light = m_testplayercontrols.FindAction("Light", throwIfNotFound: true);
        m_testplayercontrols_Mouse = m_testplayercontrols.FindAction("Mouse", throwIfNotFound: true);
        m_testplayercontrols_Sonar = m_testplayercontrols.FindAction("Sonar", throwIfNotFound: true);
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

    // testplayercontrols
    private readonly InputActionMap m_testplayercontrols;
    private ITestplayercontrolsActions m_TestplayercontrolsActionsCallbackInterface;
    private readonly InputAction m_testplayercontrols_Move;
    private readonly InputAction m_testplayercontrols_Light;
    private readonly InputAction m_testplayercontrols_Mouse;
    private readonly InputAction m_testplayercontrols_Sonar;
    public struct TestplayercontrolsActions
    {
        private @TestPlayerControls m_Wrapper;
        public TestplayercontrolsActions(@TestPlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_testplayercontrols_Move;
        public InputAction @Light => m_Wrapper.m_testplayercontrols_Light;
        public InputAction @Mouse => m_Wrapper.m_testplayercontrols_Mouse;
        public InputAction @Sonar => m_Wrapper.m_testplayercontrols_Sonar;
        public InputActionMap Get() { return m_Wrapper.m_testplayercontrols; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TestplayercontrolsActions set) { return set.Get(); }
        public void SetCallbacks(ITestplayercontrolsActions instance)
        {
            if (m_Wrapper.m_TestplayercontrolsActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_TestplayercontrolsActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_TestplayercontrolsActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_TestplayercontrolsActionsCallbackInterface.OnMove;
                @Light.started -= m_Wrapper.m_TestplayercontrolsActionsCallbackInterface.OnLight;
                @Light.performed -= m_Wrapper.m_TestplayercontrolsActionsCallbackInterface.OnLight;
                @Light.canceled -= m_Wrapper.m_TestplayercontrolsActionsCallbackInterface.OnLight;
                @Mouse.started -= m_Wrapper.m_TestplayercontrolsActionsCallbackInterface.OnMouse;
                @Mouse.performed -= m_Wrapper.m_TestplayercontrolsActionsCallbackInterface.OnMouse;
                @Mouse.canceled -= m_Wrapper.m_TestplayercontrolsActionsCallbackInterface.OnMouse;
                @Sonar.started -= m_Wrapper.m_TestplayercontrolsActionsCallbackInterface.OnSonar;
                @Sonar.performed -= m_Wrapper.m_TestplayercontrolsActionsCallbackInterface.OnSonar;
                @Sonar.canceled -= m_Wrapper.m_TestplayercontrolsActionsCallbackInterface.OnSonar;
            }
            m_Wrapper.m_TestplayercontrolsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Light.started += instance.OnLight;
                @Light.performed += instance.OnLight;
                @Light.canceled += instance.OnLight;
                @Mouse.started += instance.OnMouse;
                @Mouse.performed += instance.OnMouse;
                @Mouse.canceled += instance.OnMouse;
                @Sonar.started += instance.OnSonar;
                @Sonar.performed += instance.OnSonar;
                @Sonar.canceled += instance.OnSonar;
            }
        }
    }
    public TestplayercontrolsActions @testplayercontrols => new TestplayercontrolsActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface ITestplayercontrolsActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnLight(InputAction.CallbackContext context);
        void OnMouse(InputAction.CallbackContext context);
        void OnSonar(InputAction.CallbackContext context);
    }
}
