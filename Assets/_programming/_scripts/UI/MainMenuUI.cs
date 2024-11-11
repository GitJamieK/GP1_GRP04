using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Image _startGamePointer;
    [SerializeField] private Image _quitGamePointer;
    
    private MenuOptions _currentMenuOptionSelected;
    private int currentOption;

    private void Start()
    {
        _startGamePointer.gameObject.SetActive(true);
        _quitGamePointer.gameObject.SetActive(false);
        _currentMenuOptionSelected = MenuOptions.START_GAME; 
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            CycleOptions();
        if(Input.GetKeyDown(KeyCode.A))
            DoSelection();
    }

    public void CycleOptions()
    {
        if ((int)_currentMenuOptionSelected == 1)
            _currentMenuOptionSelected = MenuOptions.START_GAME;
        else
            _currentMenuOptionSelected = MenuOptions.QUIT_GAME;
        UpdateSelectorUI();
    }

    public void DoSelection()
    {
        if (_currentMenuOptionSelected == MenuOptions.START_GAME)
        {
            if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1)
                SceneManager.LoadScene(0);
            else
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
            Application.Quit();
    }

    private void UpdateSelectorUI()
    {
        if (_currentMenuOptionSelected == MenuOptions.START_GAME)
        {
            _startGamePointer.gameObject.SetActive(true);
            _quitGamePointer.gameObject.SetActive(false);
        }
        else
        {
            _startGamePointer.gameObject.SetActive(false);
            _quitGamePointer.gameObject.SetActive(true);
        }
    }
}
