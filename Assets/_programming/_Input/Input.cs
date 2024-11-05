using System.Data;
using UnityEngine;
using UnityEngine.InputSystem;

public class Input : MonoBehaviour
{
    [Header("Input Action Asset")]

    [SerializeField]
    private InputActionAsset inputActions ;

    [Header("Action Map Name References")]
    [SerializeField]
    private string actionMapName = "Adaptive_Controller_Gamepad";

        
    [Header("Action Name references")]
    [SerializeField] private string interaction = "Left_Button";
    [SerializeField] private string jump = "Right_Button";

    [Header("Deadzone Values")] 
    [SerializeField]
    private float right_ButtonDeadZoneValue;
    [SerializeField]
    private float left_ButtonDeadZoneValue;
    
    
    private InputAction jumpAction;
    private InputAction interactionAction;

    
    public bool JumpTriggered { get; private set; }
    private bool interactionState = false;
    public static Input Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        jumpAction = inputActions.FindActionMap(actionMapName).FindAction(jump);
        interactionAction = inputActions.FindActionMap(actionMapName).FindAction(interaction);
        RegisterInputActions();

        InputSystem.settings.defaultDeadzoneMin = 0;

        PrintDevices();
    }

    void PrintDevices() //Checks for active devices
    {
        foreach (var device in InputSystem.devices)
        {
            if (device.enabled)
            {
                Debug.Log("Active Device: " + device.name);
            }
        }
    }

    void RegisterInputActions()
    {
        interactionAction.performed += context =>
        {
            if (interactionState)
            {
                interactionState = false;
                Debug.Log("Interacting failed: " + interaction);
            }
            else
            {
                //if inactive, active it
                interactionState = true;
                Debug.Log("Interaction Active:" + interaction);

            }
        };
        jumpAction.performed += context =>
        {
            JumpTriggered = true;
        };
        jumpAction.canceled += context =>
        {
            JumpTriggered = false;
        };
    }

    private void OnEnable()
    {
        jumpAction.Enable();
        interactionAction.Enable();

        InputSystem.onDeviceChange += OnDeviceChange;
    }
    private void OnDisable()
    {
        jumpAction.Disable();
        interactionAction.Disable();
        InputSystem.onDeviceChange -= OnDeviceChange;
    }

    private void OnDeviceChange(InputDevice device, InputDeviceChange change)
    {
        switch (change)
        {
            case InputDeviceChange.Disconnected:
                Debug.Log("Device has been disconnected" + device.name);
                //Handling a disconnection of any device / Here we can add a thing to alert the player that the device isnt connected.
                break;
            case InputDeviceChange.Reconnected:
                Debug.Log("Device has been reconnected" + device.name);
                // Handling Reconnecting of a controller.
                break;
                
        }
    }
    
}
