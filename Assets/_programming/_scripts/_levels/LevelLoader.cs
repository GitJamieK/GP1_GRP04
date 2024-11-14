using System;
using jamie;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Animator _finishDoorAnimator;
    
    private int _firstSceneBuildIndex = 0;
    private int _numberOfScenes;
    private int _levelIndexToBeLoaded;
    private int _activeBuildIndex;
    private bool _playerEntered;

    private void Awake()
    {
        _numberOfScenes = SceneManager.sceneCountInBuildSettings;
        _activeBuildIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void Start()
    {
        SubscribeToEvents();
    }

    private void OnDestroy()
    {
        UnsubscribeFromEvents();
    }

    private void SubscribeToEvents()
    {
        GameManager.Instance.EventService.OnPlayerStartedOpeningDoor += OnPlayerStartedOpeningDoor;
        GameManager.Instance.EventService.InitiateNextSceneLoad += LoadNextScene;
    }

    private void UnsubscribeFromEvents()
    {
        GameManager.Instance.EventService.OnPlayerStartedOpeningDoor -= OnPlayerStartedOpeningDoor;
        GameManager.Instance.EventService.InitiateNextSceneLoad -= LoadNextScene;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerController player) && !_playerEntered)
        {
            _playerEntered = true;
            if (_activeBuildIndex != _numberOfScenes - 1)
                _levelIndexToBeLoaded = _activeBuildIndex + 1;
            else
                _levelIndexToBeLoaded = _firstSceneBuildIndex;
            GameManager.Instance.EventService.InvokePlayerReachedFinishDoorEvent();
        }
    }
    
    private void OnPlayerStartedOpeningDoor() => _finishDoorAnimator.SetTrigger("ExitLevel");

    private void LoadNextScene()
    {
        SceneManager.LoadScene(_levelIndexToBeLoaded);
    }
}
