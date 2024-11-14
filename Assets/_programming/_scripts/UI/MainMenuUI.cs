using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.InputSystem;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Image _startGamePointer;
    [SerializeField] private Image _settingsPagePointer;
    [SerializeField] private Image _quitGamePointer;

    //inside settings container
    [SerializeField] private Image _settingsPageBackPointer;
    [SerializeField] private Image _settingsPageFullscreenPointer;
    [SerializeField] private Image _settingsPageVolumePointer;

    //inside sound container
    [SerializeField] private Image _soundSettingsBackPointer;
    [SerializeField] private Image _soundSettingsVolume100Pointer;
    [SerializeField] private Image _soundSettingsVolume50Pointer;
    [SerializeField] private Image _soundSettingsVolume0Pointer;

    [SerializeField] private GameObject _settingsContainer;
    [SerializeField] private GameObject _mainContainer;
    [SerializeField] private GameObject _volumeContainer;

    private MenuOptions _currentMenuOptionSelected;
    private MenuOptions _currentSettingsMenuOptionSelected;
    private MenuOptions _currentVolumeMenuOptionSelected;
    private int currentOption = 0;
    private int currentSettingsOption = 0;
    private int currentVolumeOption = 0;

    [SerializeField]
    public InputActionAsset _inputActions;
    private InputAction leftButtonAction;

    private void OnEnable()
    {
        if (_inputActions == null)
        {
            Debug.LogError("Input Actions not set");
            return;
        }

        var uiActionMap = _inputActions.FindActionMap("Adaptive_Controller_Gamepad");

        if (uiActionMap == null)
        {
            Debug.LogError(" Adaptive_Controller_Gamepad action not found");
        }
        
        leftButtonAction = uiActionMap.FindAction("Left_Button");

        if (leftButtonAction == null)
        {
            Debug.LogError(" Left_Button action not found");
            return;
        }
        leftButtonAction.Enable();
    }

    private void OnDisable()
    {
        // Disable the action when no longer needed
        if (leftButtonAction != null)
        {
            leftButtonAction.Disable();
        }
    }

    private void Start()
    {
        if (_startGamePointer != null) _startGamePointer.gameObject.SetActive(true);
        if (_quitGamePointer != null) _quitGamePointer.gameObject.SetActive(false);
        if (_settingsPagePointer != null) _settingsPagePointer.gameObject.SetActive(false);
        //_currentMenuOptionSelected = MenuOptions.START_GAME;

        if (_settingsPageBackPointer != null) _settingsPageBackPointer.gameObject.SetActive(false);
        if (_settingsPageFullscreenPointer != null) _settingsPageFullscreenPointer.gameObject.SetActive(false);
        if (_settingsPageVolumePointer != null) _settingsPageVolumePointer.gameObject.SetActive(false);
    }

    private void Update()
    {
        // Ensure that the action has been initialized before accessing it
        if (leftButtonAction == null)
        {
            Debug.LogError("Left_Button action is not initialized!");
            return;
        }

        // Check if Fire1 button or Space key is pressed, or Left_Button action is triggered
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space) || leftButtonAction.triggered)
        {
            Debug.Log("Left_Button Triggered");

            // Increment menu options
            currentOption++;
            currentSettingsOption++;
            currentVolumeOption++;

            // Wrap-around logic for options
            if (currentOption >= 3) currentOption = 0;
            if (currentSettingsOption >= 3) currentSettingsOption = 0;
            if (currentVolumeOption >= 4) currentVolumeOption = 0;

            CycleOptions(); // Call to cycle through menu options
        }

        // Check if A button or Fire2 button is pressed for selection
        if (Input.GetKeyDown(KeyCode.A) || Input.GetButtonDown("Fire2"))
        {
            DoSelection();  // Perform the selection action
        }
    }

    public void CycleOptions()
    {
        switch (currentOption)
        {
            case 0:
                _currentMenuOptionSelected = MenuOptions.START_GAME;
                break;

            case 1:
                _currentMenuOptionSelected = MenuOptions.SETTINGS;
                break;

            case 2:
                _currentMenuOptionSelected = MenuOptions.QUIT_GAME;
                break;
        }

        switch (currentSettingsOption)
        {
            case 0:
                _currentSettingsMenuOptionSelected = MenuOptions.SETTINGS_BACK;
                break;

            case 1:
                _currentSettingsMenuOptionSelected = MenuOptions.FULLSCREEN;
                break;
            case 2:
                _currentSettingsMenuOptionSelected = MenuOptions.SOUND;
                break;
        }

        switch (currentVolumeOption)
        {
            case 0:
                _currentVolumeMenuOptionSelected = MenuOptions.VOLUME_BACK;
                break;
            case 1:
                _currentVolumeMenuOptionSelected = MenuOptions.VOLUME_100;
                break;
            case 2:
                _currentVolumeMenuOptionSelected = MenuOptions.VOLUME_50;
                break;
            case 3:
                _currentVolumeMenuOptionSelected = MenuOptions.VOLUME_0;
                break;
        }

        UpdateSelectorUI();
    }

    public void DoSelection()
    {
        if (_mainContainer.activeSelf)
        {
            if (_currentMenuOptionSelected == MenuOptions.START_GAME)
            {
                if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1)
                    SceneManager.LoadScene(0);
                else
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else if (_currentMenuOptionSelected == MenuOptions.SETTINGS)
            {
                Debug.Log("Settings Selected");
                _settingsContainer.SetActive(true);
                _mainContainer.SetActive(false);
                currentSettingsOption = 0;
                UpdateSelectorUI();
            }
            else if (_currentMenuOptionSelected == MenuOptions.QUIT_GAME)
            {
                Application.Quit();
            }
        }
        else if (_settingsContainer.activeSelf)
        {
            if (_currentSettingsMenuOptionSelected == MenuOptions.SETTINGS_BACK)
            {
                if (Input.GetKeyDown(KeyCode.A) || Input.GetButtonDown("Fire2"))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
            else if (_currentSettingsMenuOptionSelected == MenuOptions.FULLSCREEN)
            {
#if UNITY_EDITOR
                ToggleMaximizeGameViewInEditor();
#else
                    Screen.fullScreen = !Screen.fullScreen;
                    Debug.Log("Toggled fullscreen mode to: " + Screen.fullScreen);
#endif
            }
            else if (_currentSettingsMenuOptionSelected == MenuOptions.SOUND)
            {
                _volumeContainer.SetActive(true);
                _settingsContainer.SetActive(false);
                currentVolumeOption = 0; //start at 100% volume
                UpdateSelectorUI();
            }
        }
        else if (_volumeContainer.activeSelf)
        {
            if (_currentVolumeMenuOptionSelected == MenuOptions.VOLUME_BACK)
            {
                Debug.Log("Back button pressed - Reloading main menu scene");
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

            if (_currentVolumeMenuOptionSelected == MenuOptions.VOLUME_100)
            {
                audioMixer.SetFloat("MasterVolume", 0f);
            }
            else if (_currentVolumeMenuOptionSelected == MenuOptions.VOLUME_50)
            {
                audioMixer.SetFloat("MasterVolume", -20f);
            }
            else if (_currentVolumeMenuOptionSelected == MenuOptions.VOLUME_0)
            {
                audioMixer.SetFloat("MasterVolume", -40f);
            }
        }
    }

    private void UpdateSelectorUI()
    {
        switch (currentOption)
        {
            case 0:
                _currentMenuOptionSelected = MenuOptions.START_GAME;
                if (_startGamePointer != null) _startGamePointer.gameObject.SetActive(true);
                if (_quitGamePointer != null) _quitGamePointer.gameObject.SetActive(false);
                if (_settingsPagePointer != null) _settingsPagePointer.gameObject.SetActive(false);
                break;

            case 1:
                _currentMenuOptionSelected = MenuOptions.SETTINGS;
                if (_startGamePointer != null) _startGamePointer.gameObject.SetActive(false);
                if (_quitGamePointer != null) _quitGamePointer.gameObject.SetActive(false);
                if (_settingsPagePointer != null) _settingsPagePointer.gameObject.SetActive(true);
                break;

            case 2:
                _currentMenuOptionSelected = MenuOptions.QUIT_GAME;
                if (_startGamePointer != null) _startGamePointer.gameObject.SetActive(false);
                if (_quitGamePointer != null) _quitGamePointer.gameObject.SetActive(true);
                if (_settingsPagePointer != null) _settingsPagePointer.gameObject.SetActive(false);
                break;
        }

        switch (currentSettingsOption)
        {
            case 0:
                _currentSettingsMenuOptionSelected = MenuOptions.SETTINGS_BACK;
                if (_settingsPageBackPointer != null) _settingsPageBackPointer.gameObject.SetActive(true);
                if (_settingsPageFullscreenPointer != null) _settingsPageFullscreenPointer.gameObject.SetActive(false);
                if (_settingsPageVolumePointer != null) _settingsPageVolumePointer.gameObject.SetActive(false);
                break;

            case 1:
                _currentSettingsMenuOptionSelected = MenuOptions.FULLSCREEN;
                if (_settingsPageBackPointer != null) _settingsPageBackPointer.gameObject.SetActive(false);
                if (_settingsPageFullscreenPointer != null) _settingsPageFullscreenPointer.gameObject.SetActive(true);
                if (_settingsPageVolumePointer != null) _settingsPageVolumePointer.gameObject.SetActive(false);
                break;
            case 2:
                _currentSettingsMenuOptionSelected = MenuOptions.SOUND;
                if (_settingsPageBackPointer != null) _settingsPageBackPointer.gameObject.SetActive(false);
                if (_settingsPageFullscreenPointer != null) _settingsPageFullscreenPointer.gameObject.SetActive(false);
                if (_settingsPageVolumePointer != null) _settingsPageVolumePointer.gameObject.SetActive(true);
                break;
        }

        switch (currentVolumeOption)
        {
            case 0:
                _currentVolumeMenuOptionSelected = MenuOptions.VOLUME_BACK;
                if (_soundSettingsBackPointer != null) _soundSettingsBackPointer.gameObject.SetActive(true);
                if (_soundSettingsVolume100Pointer != null) _soundSettingsVolume100Pointer.gameObject.SetActive(false);
                if (_soundSettingsVolume50Pointer != null) _soundSettingsVolume50Pointer.gameObject.SetActive(false);
                if (_soundSettingsVolume0Pointer != null) _soundSettingsVolume0Pointer.gameObject.SetActive(false);
                break;
            case 1:
                _currentVolumeMenuOptionSelected = MenuOptions.VOLUME_100;
                if (_soundSettingsBackPointer != null) _soundSettingsBackPointer.gameObject.SetActive(false);
                if (_soundSettingsVolume100Pointer != null) _soundSettingsVolume100Pointer.gameObject.SetActive(true);
                if (_soundSettingsVolume50Pointer != null) _soundSettingsVolume50Pointer.gameObject.SetActive(false);
                if (_soundSettingsVolume0Pointer != null) _soundSettingsVolume0Pointer.gameObject.SetActive(false);
                break;

            case 2:
                _currentVolumeMenuOptionSelected = MenuOptions.VOLUME_50;
                if (_soundSettingsBackPointer != null) _soundSettingsBackPointer.gameObject.SetActive(false);
                if (_soundSettingsVolume100Pointer != null) _soundSettingsVolume100Pointer.gameObject.SetActive(false);
                if (_soundSettingsVolume50Pointer != null) _soundSettingsVolume50Pointer.gameObject.SetActive(true);
                if (_soundSettingsVolume0Pointer != null) _soundSettingsVolume0Pointer.gameObject.SetActive(false);
                break;

            case 3:
                _currentVolumeMenuOptionSelected = MenuOptions.VOLUME_0;
                if (_soundSettingsBackPointer != null) _soundSettingsBackPointer.gameObject.SetActive(false);
                if (_soundSettingsVolume100Pointer != null) _soundSettingsVolume100Pointer.gameObject.SetActive(false);
                if (_soundSettingsVolume50Pointer != null) _soundSettingsVolume50Pointer.gameObject.SetActive(false);
                if (_soundSettingsVolume0Pointer != null) _soundSettingsVolume0Pointer.gameObject.SetActive(true);
                break;
        }
    }

#if UNITY_EDITOR
    private void ToggleMaximizeGameViewInEditor()
    {
        System.Type gameViewType = typeof(Editor).Assembly.GetType("UnityEditor.GameView");
        EditorWindow gameView = EditorWindow.GetWindow(gameViewType);

        // Toggle the maximized property
        gameView.maximized = !gameView.maximized;
    }
#endif
}