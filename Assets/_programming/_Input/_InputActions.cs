//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.11.2
//     from Assets/_programming/_input/_InputActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @_InputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @_InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""_InputActions"",
    ""maps"": [
        {
            ""name"": ""Adaptive_Controller_GamePad"",
            ""id"": ""dfabcefd-2f8e-4d06-88ef-dd1f095fb6a1"",
            ""actions"": [
                {
                    ""name"": ""Left_Button"",
                    ""type"": ""Button"",
                    ""id"": ""bbedbe58-c691-49da-a41a-bf9b6b3ec3c4"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Right_Button"",
                    ""type"": ""Button"",
                    ""id"": ""cf711bc0-a4dc-4abd-83b2-1029fb160488"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Pause_Button"",
                    ""type"": ""Button"",
                    ""id"": ""6589b1a1-dcc4-4ff7-9795-7669539c655e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Start_Button"",
                    ""type"": ""Button"",
                    ""id"": ""8b2b784a-f999-4d30-a6f1-bb6314d41d18"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""GamePad_Up"",
                    ""type"": ""Button"",
                    ""id"": ""881a7799-a667-453e-8e20-96f0a8169de8"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""GamePad_Down"",
                    ""type"": ""Button"",
                    ""id"": ""58695093-b99b-42b6-b5f0-7aa6ba86a879"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""GamePad_Left"",
                    ""type"": ""Button"",
                    ""id"": ""992c6d3c-6a0b-4a5a-981d-5e27892e9273"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""GamePad_Right"",
                    ""type"": ""Button"",
                    ""id"": ""f9d53b29-47db-4485-ab48-f362b479b22b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""486e7965-7b62-46d9-947f-b865a4160762"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left_Button"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b5502688-5d08-4bd7-bd72-85d6b1455ead"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right_Button"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a9c29b3c-9e02-4f63-8243-d94e2d96be29"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause_Button"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""32cf2ae9-1e4b-4993-855d-e87e2b017728"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Start_Button"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""932d0a31-3204-4248-949a-beb6a64fb343"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GamePad_Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""592de23a-9c96-4735-a627-8f6c1e73d65a"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GamePad_Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4e05bffd-b6d3-4fb6-b622-2904a72de5f7"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GamePad_Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e4f08086-f18a-4e7d-84e0-f5f9a7fd6ae5"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GamePad_Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Adaptive_Controller_Xbox"",
            ""id"": ""827366e5-6c23-487f-a1d6-5e1cf992ec6f"",
            ""actions"": [
                {
                    ""name"": ""Left_Button"",
                    ""type"": ""Button"",
                    ""id"": ""0fec8239-0475-49e7-9a87-f39460b4808b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Right_Button"",
                    ""type"": ""Button"",
                    ""id"": ""5ce49c9a-41d6-4299-bac7-233348470778"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Pause_Button"",
                    ""type"": ""Button"",
                    ""id"": ""5622ad81-579d-4715-8a51-bc5395cd1e1a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Start_Button"",
                    ""type"": ""Button"",
                    ""id"": ""9e4e5c4f-139f-411d-b4ab-179db6aa560f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Button_Up"",
                    ""type"": ""Button"",
                    ""id"": ""e212b118-080e-4fc0-8a82-c162c9c264a6"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Button_Down"",
                    ""type"": ""Button"",
                    ""id"": ""06ff3a67-0c4a-409a-86ee-655af8bbf618"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Button_Left"",
                    ""type"": ""Button"",
                    ""id"": ""76482a67-d9dc-454c-aa60-626a1287dc6d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Button_Right"",
                    ""type"": ""Button"",
                    ""id"": ""e4487dcf-6cb5-41f6-b4a5-95476a066410"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""081dedf7-0f98-4734-b4dd-db4ba30e8483"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left_Button"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a5a5c9e2-32fc-4f46-88fc-bc6e4a9a3070"",
                    ""path"": ""<XInputController>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right_Button"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""527cdfae-2f1a-488d-8f21-2e180b8fc18f"",
                    ""path"": ""<XInputController>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause_Button"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b2cea0a9-58e7-4bed-8ace-5d187e644dab"",
                    ""path"": ""<XInputController>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Start_Button"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f38bc563-5c0f-4395-9ecd-feb942b131fe"",
                    ""path"": ""<XInputController>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Button_Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b9ba07ce-6e14-48d3-9300-c03bb7a07187"",
                    ""path"": ""<XInputController>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Button_Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""25721e58-4cd2-4476-a2ac-a33be5b319d2"",
                    ""path"": ""<XInputController>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Button_Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c47620b1-5784-43c8-8307-602ce5e735d5"",
                    ""path"": ""<XInputController>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Button_Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Adaptive_Controller_GamePad
        m_Adaptive_Controller_GamePad = asset.FindActionMap("Adaptive_Controller_GamePad", throwIfNotFound: true);
        m_Adaptive_Controller_GamePad_Left_Button = m_Adaptive_Controller_GamePad.FindAction("Left_Button", throwIfNotFound: true);
        m_Adaptive_Controller_GamePad_Right_Button = m_Adaptive_Controller_GamePad.FindAction("Right_Button", throwIfNotFound: true);
        m_Adaptive_Controller_GamePad_Pause_Button = m_Adaptive_Controller_GamePad.FindAction("Pause_Button", throwIfNotFound: true);
        m_Adaptive_Controller_GamePad_Start_Button = m_Adaptive_Controller_GamePad.FindAction("Start_Button", throwIfNotFound: true);
        m_Adaptive_Controller_GamePad_GamePad_Up = m_Adaptive_Controller_GamePad.FindAction("GamePad_Up", throwIfNotFound: true);
        m_Adaptive_Controller_GamePad_GamePad_Down = m_Adaptive_Controller_GamePad.FindAction("GamePad_Down", throwIfNotFound: true);
        m_Adaptive_Controller_GamePad_GamePad_Left = m_Adaptive_Controller_GamePad.FindAction("GamePad_Left", throwIfNotFound: true);
        m_Adaptive_Controller_GamePad_GamePad_Right = m_Adaptive_Controller_GamePad.FindAction("GamePad_Right", throwIfNotFound: true);
        // Adaptive_Controller_Xbox
        m_Adaptive_Controller_Xbox = asset.FindActionMap("Adaptive_Controller_Xbox", throwIfNotFound: true);
        m_Adaptive_Controller_Xbox_Left_Button = m_Adaptive_Controller_Xbox.FindAction("Left_Button", throwIfNotFound: true);
        m_Adaptive_Controller_Xbox_Right_Button = m_Adaptive_Controller_Xbox.FindAction("Right_Button", throwIfNotFound: true);
        m_Adaptive_Controller_Xbox_Pause_Button = m_Adaptive_Controller_Xbox.FindAction("Pause_Button", throwIfNotFound: true);
        m_Adaptive_Controller_Xbox_Start_Button = m_Adaptive_Controller_Xbox.FindAction("Start_Button", throwIfNotFound: true);
        m_Adaptive_Controller_Xbox_Button_Up = m_Adaptive_Controller_Xbox.FindAction("Button_Up", throwIfNotFound: true);
        m_Adaptive_Controller_Xbox_Button_Down = m_Adaptive_Controller_Xbox.FindAction("Button_Down", throwIfNotFound: true);
        m_Adaptive_Controller_Xbox_Button_Left = m_Adaptive_Controller_Xbox.FindAction("Button_Left", throwIfNotFound: true);
        m_Adaptive_Controller_Xbox_Button_Right = m_Adaptive_Controller_Xbox.FindAction("Button_Right", throwIfNotFound: true);
    }

    ~@_InputActions()
    {
        UnityEngine.Debug.Assert(!m_Adaptive_Controller_GamePad.enabled, "This will cause a leak and performance issues, _InputActions.Adaptive_Controller_GamePad.Disable() has not been called.");
        UnityEngine.Debug.Assert(!m_Adaptive_Controller_Xbox.enabled, "This will cause a leak and performance issues, _InputActions.Adaptive_Controller_Xbox.Disable() has not been called.");
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Adaptive_Controller_GamePad
    private readonly InputActionMap m_Adaptive_Controller_GamePad;
    private List<IAdaptive_Controller_GamePadActions> m_Adaptive_Controller_GamePadActionsCallbackInterfaces = new List<IAdaptive_Controller_GamePadActions>();
    private readonly InputAction m_Adaptive_Controller_GamePad_Left_Button;
    private readonly InputAction m_Adaptive_Controller_GamePad_Right_Button;
    private readonly InputAction m_Adaptive_Controller_GamePad_Pause_Button;
    private readonly InputAction m_Adaptive_Controller_GamePad_Start_Button;
    private readonly InputAction m_Adaptive_Controller_GamePad_GamePad_Up;
    private readonly InputAction m_Adaptive_Controller_GamePad_GamePad_Down;
    private readonly InputAction m_Adaptive_Controller_GamePad_GamePad_Left;
    private readonly InputAction m_Adaptive_Controller_GamePad_GamePad_Right;
    public struct Adaptive_Controller_GamePadActions
    {
        private @_InputActions m_Wrapper;
        public Adaptive_Controller_GamePadActions(@_InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Left_Button => m_Wrapper.m_Adaptive_Controller_GamePad_Left_Button;
        public InputAction @Right_Button => m_Wrapper.m_Adaptive_Controller_GamePad_Right_Button;
        public InputAction @Pause_Button => m_Wrapper.m_Adaptive_Controller_GamePad_Pause_Button;
        public InputAction @Start_Button => m_Wrapper.m_Adaptive_Controller_GamePad_Start_Button;
        public InputAction @GamePad_Up => m_Wrapper.m_Adaptive_Controller_GamePad_GamePad_Up;
        public InputAction @GamePad_Down => m_Wrapper.m_Adaptive_Controller_GamePad_GamePad_Down;
        public InputAction @GamePad_Left => m_Wrapper.m_Adaptive_Controller_GamePad_GamePad_Left;
        public InputAction @GamePad_Right => m_Wrapper.m_Adaptive_Controller_GamePad_GamePad_Right;
        public InputActionMap Get() { return m_Wrapper.m_Adaptive_Controller_GamePad; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Adaptive_Controller_GamePadActions set) { return set.Get(); }
        public void AddCallbacks(IAdaptive_Controller_GamePadActions instance)
        {
            if (instance == null || m_Wrapper.m_Adaptive_Controller_GamePadActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_Adaptive_Controller_GamePadActionsCallbackInterfaces.Add(instance);
            @Left_Button.started += instance.OnLeft_Button;
            @Left_Button.performed += instance.OnLeft_Button;
            @Left_Button.canceled += instance.OnLeft_Button;
            @Right_Button.started += instance.OnRight_Button;
            @Right_Button.performed += instance.OnRight_Button;
            @Right_Button.canceled += instance.OnRight_Button;
            @Pause_Button.started += instance.OnPause_Button;
            @Pause_Button.performed += instance.OnPause_Button;
            @Pause_Button.canceled += instance.OnPause_Button;
            @Start_Button.started += instance.OnStart_Button;
            @Start_Button.performed += instance.OnStart_Button;
            @Start_Button.canceled += instance.OnStart_Button;
            @GamePad_Up.started += instance.OnGamePad_Up;
            @GamePad_Up.performed += instance.OnGamePad_Up;
            @GamePad_Up.canceled += instance.OnGamePad_Up;
            @GamePad_Down.started += instance.OnGamePad_Down;
            @GamePad_Down.performed += instance.OnGamePad_Down;
            @GamePad_Down.canceled += instance.OnGamePad_Down;
            @GamePad_Left.started += instance.OnGamePad_Left;
            @GamePad_Left.performed += instance.OnGamePad_Left;
            @GamePad_Left.canceled += instance.OnGamePad_Left;
            @GamePad_Right.started += instance.OnGamePad_Right;
            @GamePad_Right.performed += instance.OnGamePad_Right;
            @GamePad_Right.canceled += instance.OnGamePad_Right;
        }

        private void UnregisterCallbacks(IAdaptive_Controller_GamePadActions instance)
        {
            @Left_Button.started -= instance.OnLeft_Button;
            @Left_Button.performed -= instance.OnLeft_Button;
            @Left_Button.canceled -= instance.OnLeft_Button;
            @Right_Button.started -= instance.OnRight_Button;
            @Right_Button.performed -= instance.OnRight_Button;
            @Right_Button.canceled -= instance.OnRight_Button;
            @Pause_Button.started -= instance.OnPause_Button;
            @Pause_Button.performed -= instance.OnPause_Button;
            @Pause_Button.canceled -= instance.OnPause_Button;
            @Start_Button.started -= instance.OnStart_Button;
            @Start_Button.performed -= instance.OnStart_Button;
            @Start_Button.canceled -= instance.OnStart_Button;
            @GamePad_Up.started -= instance.OnGamePad_Up;
            @GamePad_Up.performed -= instance.OnGamePad_Up;
            @GamePad_Up.canceled -= instance.OnGamePad_Up;
            @GamePad_Down.started -= instance.OnGamePad_Down;
            @GamePad_Down.performed -= instance.OnGamePad_Down;
            @GamePad_Down.canceled -= instance.OnGamePad_Down;
            @GamePad_Left.started -= instance.OnGamePad_Left;
            @GamePad_Left.performed -= instance.OnGamePad_Left;
            @GamePad_Left.canceled -= instance.OnGamePad_Left;
            @GamePad_Right.started -= instance.OnGamePad_Right;
            @GamePad_Right.performed -= instance.OnGamePad_Right;
            @GamePad_Right.canceled -= instance.OnGamePad_Right;
        }

        public void RemoveCallbacks(IAdaptive_Controller_GamePadActions instance)
        {
            if (m_Wrapper.m_Adaptive_Controller_GamePadActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IAdaptive_Controller_GamePadActions instance)
        {
            foreach (var item in m_Wrapper.m_Adaptive_Controller_GamePadActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_Adaptive_Controller_GamePadActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public Adaptive_Controller_GamePadActions @Adaptive_Controller_GamePad => new Adaptive_Controller_GamePadActions(this);

    // Adaptive_Controller_Xbox
    private readonly InputActionMap m_Adaptive_Controller_Xbox;
    private List<IAdaptive_Controller_XboxActions> m_Adaptive_Controller_XboxActionsCallbackInterfaces = new List<IAdaptive_Controller_XboxActions>();
    private readonly InputAction m_Adaptive_Controller_Xbox_Left_Button;
    private readonly InputAction m_Adaptive_Controller_Xbox_Right_Button;
    private readonly InputAction m_Adaptive_Controller_Xbox_Pause_Button;
    private readonly InputAction m_Adaptive_Controller_Xbox_Start_Button;
    private readonly InputAction m_Adaptive_Controller_Xbox_Button_Up;
    private readonly InputAction m_Adaptive_Controller_Xbox_Button_Down;
    private readonly InputAction m_Adaptive_Controller_Xbox_Button_Left;
    private readonly InputAction m_Adaptive_Controller_Xbox_Button_Right;
    public struct Adaptive_Controller_XboxActions
    {
        private @_InputActions m_Wrapper;
        public Adaptive_Controller_XboxActions(@_InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Left_Button => m_Wrapper.m_Adaptive_Controller_Xbox_Left_Button;
        public InputAction @Right_Button => m_Wrapper.m_Adaptive_Controller_Xbox_Right_Button;
        public InputAction @Pause_Button => m_Wrapper.m_Adaptive_Controller_Xbox_Pause_Button;
        public InputAction @Start_Button => m_Wrapper.m_Adaptive_Controller_Xbox_Start_Button;
        public InputAction @Button_Up => m_Wrapper.m_Adaptive_Controller_Xbox_Button_Up;
        public InputAction @Button_Down => m_Wrapper.m_Adaptive_Controller_Xbox_Button_Down;
        public InputAction @Button_Left => m_Wrapper.m_Adaptive_Controller_Xbox_Button_Left;
        public InputAction @Button_Right => m_Wrapper.m_Adaptive_Controller_Xbox_Button_Right;
        public InputActionMap Get() { return m_Wrapper.m_Adaptive_Controller_Xbox; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Adaptive_Controller_XboxActions set) { return set.Get(); }
        public void AddCallbacks(IAdaptive_Controller_XboxActions instance)
        {
            if (instance == null || m_Wrapper.m_Adaptive_Controller_XboxActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_Adaptive_Controller_XboxActionsCallbackInterfaces.Add(instance);
            @Left_Button.started += instance.OnLeft_Button;
            @Left_Button.performed += instance.OnLeft_Button;
            @Left_Button.canceled += instance.OnLeft_Button;
            @Right_Button.started += instance.OnRight_Button;
            @Right_Button.performed += instance.OnRight_Button;
            @Right_Button.canceled += instance.OnRight_Button;
            @Pause_Button.started += instance.OnPause_Button;
            @Pause_Button.performed += instance.OnPause_Button;
            @Pause_Button.canceled += instance.OnPause_Button;
            @Start_Button.started += instance.OnStart_Button;
            @Start_Button.performed += instance.OnStart_Button;
            @Start_Button.canceled += instance.OnStart_Button;
            @Button_Up.started += instance.OnButton_Up;
            @Button_Up.performed += instance.OnButton_Up;
            @Button_Up.canceled += instance.OnButton_Up;
            @Button_Down.started += instance.OnButton_Down;
            @Button_Down.performed += instance.OnButton_Down;
            @Button_Down.canceled += instance.OnButton_Down;
            @Button_Left.started += instance.OnButton_Left;
            @Button_Left.performed += instance.OnButton_Left;
            @Button_Left.canceled += instance.OnButton_Left;
            @Button_Right.started += instance.OnButton_Right;
            @Button_Right.performed += instance.OnButton_Right;
            @Button_Right.canceled += instance.OnButton_Right;
        }

        private void UnregisterCallbacks(IAdaptive_Controller_XboxActions instance)
        {
            @Left_Button.started -= instance.OnLeft_Button;
            @Left_Button.performed -= instance.OnLeft_Button;
            @Left_Button.canceled -= instance.OnLeft_Button;
            @Right_Button.started -= instance.OnRight_Button;
            @Right_Button.performed -= instance.OnRight_Button;
            @Right_Button.canceled -= instance.OnRight_Button;
            @Pause_Button.started -= instance.OnPause_Button;
            @Pause_Button.performed -= instance.OnPause_Button;
            @Pause_Button.canceled -= instance.OnPause_Button;
            @Start_Button.started -= instance.OnStart_Button;
            @Start_Button.performed -= instance.OnStart_Button;
            @Start_Button.canceled -= instance.OnStart_Button;
            @Button_Up.started -= instance.OnButton_Up;
            @Button_Up.performed -= instance.OnButton_Up;
            @Button_Up.canceled -= instance.OnButton_Up;
            @Button_Down.started -= instance.OnButton_Down;
            @Button_Down.performed -= instance.OnButton_Down;
            @Button_Down.canceled -= instance.OnButton_Down;
            @Button_Left.started -= instance.OnButton_Left;
            @Button_Left.performed -= instance.OnButton_Left;
            @Button_Left.canceled -= instance.OnButton_Left;
            @Button_Right.started -= instance.OnButton_Right;
            @Button_Right.performed -= instance.OnButton_Right;
            @Button_Right.canceled -= instance.OnButton_Right;
        }

        public void RemoveCallbacks(IAdaptive_Controller_XboxActions instance)
        {
            if (m_Wrapper.m_Adaptive_Controller_XboxActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IAdaptive_Controller_XboxActions instance)
        {
            foreach (var item in m_Wrapper.m_Adaptive_Controller_XboxActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_Adaptive_Controller_XboxActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public Adaptive_Controller_XboxActions @Adaptive_Controller_Xbox => new Adaptive_Controller_XboxActions(this);
    public interface IAdaptive_Controller_GamePadActions
    {
        void OnLeft_Button(InputAction.CallbackContext context);
        void OnRight_Button(InputAction.CallbackContext context);
        void OnPause_Button(InputAction.CallbackContext context);
        void OnStart_Button(InputAction.CallbackContext context);
        void OnGamePad_Up(InputAction.CallbackContext context);
        void OnGamePad_Down(InputAction.CallbackContext context);
        void OnGamePad_Left(InputAction.CallbackContext context);
        void OnGamePad_Right(InputAction.CallbackContext context);
    }
    public interface IAdaptive_Controller_XboxActions
    {
        void OnLeft_Button(InputAction.CallbackContext context);
        void OnRight_Button(InputAction.CallbackContext context);
        void OnPause_Button(InputAction.CallbackContext context);
        void OnStart_Button(InputAction.CallbackContext context);
        void OnButton_Up(InputAction.CallbackContext context);
        void OnButton_Down(InputAction.CallbackContext context);
        void OnButton_Left(InputAction.CallbackContext context);
        void OnButton_Right(InputAction.CallbackContext context);
    }
}
