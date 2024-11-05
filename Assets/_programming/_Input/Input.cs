namespace _programming._input
{
    using UnityEngine;
    using UnityEngine.InputSystem;

    public class Input : MonoBehaviour
    {
        [Header("Input Action Asset")] [SerializeField]
        private InputActionAsset inputActions;

        [Header("Action Map Name References")] [SerializeField]
        private string actionMapName = "Adaptive_Controller_Gamepad";


        [Header("Action Name references")] [SerializeField]
        private string interaction = "Left_Button";

        [SerializeField] private string jump = "Right_Button";

        [Header("DeadZone Value")] [SerializeField]
        private float rightButtonDeadZoneValue;

        [SerializeField] private float leftButtonDeadZoneValue;

        [SerializeField] private float jumpDelay;
        private InputAction _jumpAction;

        private InputAction _interactionAction;


        public bool JumpTriggered { get; private set; }
        private bool _interactionState;
        private static Input Instance { get; set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                Debug.Log("Instance is created");
            }
            else
            {
                Destroy(gameObject);
                Debug.Log("Instance already exists");
            }

            InputSystem.settings.defaultDeadzoneMin = 0;
            Debug.Log("Dead Zone Log");

            PrintDevices();
        }

        private void Update()
        {
            RegisterInputActions();
        }


        void RegisterInputActions()
        {
            _jumpAction = InputSystem.actions.FindAction("Right_Button");
            _jumpAction.performed += Jump;
            _jumpAction.canceled += Jump;

            _interactionAction = InputSystem.actions.FindAction("Left_Button");
            _interactionAction.performed += Interact;
            _interactionAction.canceled += Interact;
        }

        private void Jump(InputAction.CallbackContext ctx)
        {
            //Do a thing
            Debug.Log("Jump");
        }

        private void Interact(InputAction.CallbackContext ctx)
        {
            Debug.Log("Interact");
        }

        //Enable / Disable

        private void OnEnable()
        {
            _jumpAction.Enable();
            _interactionAction.Enable();

            InputSystem.onDeviceChange += OnDeviceChange;
        }

        private void OnDisable()
        {
            _jumpAction.Disable();
            _interactionAction.Disable();
            InputSystem.onDeviceChange -= OnDeviceChange;
        }

        //
        //Device Handling
        //
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

        private void OnDeviceChange(InputDevice device, InputDeviceChange change)
        {
            switch (change)
            {
                case InputDeviceChange.Disconnected:
                    Debug.Log("Device has been disconnected" + device.name);
                    //Handling a disconnection of any device / Here we can add a thing to alert the player that the device isn't connected.
                    break;
                case InputDeviceChange.Reconnected:
                    Debug.Log("Device has been reconnected" + device.name);
                    // Handling Reconnecting of a controller.
                    OnEnable();
                    break;
            }
        }
    }
}