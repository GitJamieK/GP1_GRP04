using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Image _startGamePointer;
    [SerializeField] private Image _settingsPagePointer;
    [SerializeField] private Image _quitGamePointer;
    
    //inside settings container
    [SerializeField] private Image _settingsPageBackPointer;
    [SerializeField] private Image _settingsPageTEMPPointer;
    
    [SerializeField] private GameObject _settingsContainer;
    [SerializeField] private GameObject _mainContainer;
    
    private MenuOptions _currentMenuOptionSelected;
    private MenuOptions _currentSettingsMenuOptionSelected;
    private int currentOption = 0;
    private int currentSettingsOption = 0;

    private void Start()
    {
        _startGamePointer.gameObject.SetActive(true);
        _quitGamePointer.gameObject.SetActive(false);
        _settingsPagePointer.gameObject.SetActive(false);
        _currentMenuOptionSelected = MenuOptions.START_GAME;
        
        _settingsPageBackPointer.gameObject.SetActive(true);
        _settingsPageTEMPPointer.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentOption++;
            currentSettingsOption++;
            if(currentOption >= 3)
                currentOption = 0;
            if (currentSettingsOption >= 2)
                currentSettingsOption = 0;
            
            CycleOptions();
        }
        if(Input.GetKeyDown(KeyCode.A))
            DoSelection();
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
                _currentSettingsMenuOptionSelected = MenuOptions.BACK;
                break;
                
            case 1:
                _currentSettingsMenuOptionSelected = MenuOptions.TEMP;
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
            if (_currentSettingsMenuOptionSelected == MenuOptions.BACK)
            {
                // Reload the main menu by reloading the scene
                Debug.Log("Back button pressed - Reloading main menu scene");
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else if (_currentSettingsMenuOptionSelected == MenuOptions.TEMP)
            {
                //TEMP setting (can be used for future accessibility settings)
                Debug.Log("TEMP option selected in settings");
            }
        }
    }

    private void UpdateSelectorUI()
    {
        switch (currentOption)
        {
            case 0:
                _currentMenuOptionSelected = MenuOptions.START_GAME;
                _startGamePointer.gameObject.SetActive(true);
                _quitGamePointer.gameObject.SetActive(false);
                _settingsPagePointer.gameObject.SetActive(false);
                break;
            
            case 1:
                _currentMenuOptionSelected = MenuOptions.SETTINGS;
                _startGamePointer.gameObject.SetActive(false);
                _quitGamePointer.gameObject.SetActive(false);
                _settingsPagePointer.gameObject.SetActive(true);
                break;
            
            case 2:
                _currentMenuOptionSelected = MenuOptions.QUIT_GAME;
                _startGamePointer.gameObject.SetActive(false);
                _quitGamePointer.gameObject.SetActive(true);
                _settingsPagePointer.gameObject.SetActive(false);
                break;
        }

        switch (currentSettingsOption)
        {
            case 0:
                _currentSettingsMenuOptionSelected = MenuOptions.BACK;
                _settingsPageBackPointer.gameObject.SetActive(true);
                _settingsPageTEMPPointer.gameObject.SetActive(false);
                break;
            
            case 1:
                _currentSettingsMenuOptionSelected = MenuOptions.TEMP;
                _settingsPageBackPointer.gameObject.SetActive(false);
                _settingsPageTEMPPointer.gameObject.SetActive(true);
                break;
        }
    }
}
