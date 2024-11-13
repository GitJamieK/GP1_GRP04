using System;
using System.Collections.Generic;
using UnityEngine;
using Jesper.GeneralStateMachine;
using Jesper.PlayerStateMachine;
using UnityEngine.SceneManagement;

public class GameManager : StateMachine
{
    public float TimeScale;
    private static GameManager instance;

    public static GameManager Instance
    {
        get { return instance; }
    }
    
    public EventService EventService;
    public PlayerController Player;
    public UIService UIService;
    public int NumberOfSeedsCollected;
    
    private int _seedsAtStartOfLevel;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);
        
        DontDestroyOnLoad(this);
        InitializeServices();
        CreateStates();
        Time.timeScale = TimeScale;
    }

    private void Start()
    {
        Player = FindAnyObjectByType<PlayerController>();
        UIService = FindAnyObjectByType<UIService>();
        UIService.UpdateSeedsCollected(NumberOfSeedsCollected);
        SubscribeToEvents();
        SwitchState<GamePausedState>();
    }

    private void OnDestroy()
    {
        UnsubscribeFromEvents();
    }
    private void SubscribeToEvents()
    {
        EventService.OnPlayerEnteredWorldRotationTrigger += OnPlayerEnteredWorldRotationTrigger;
        EventService.OnCameraFinishedRotation += SwitchState<GamePlayingState>;
        EventService.OnPlayerCollectedSeed += UpdateSeeds;
        EventService.OnPlayerFinishedEnteringLevel += SwitchState<GamePlayingState>;
        SceneManager.activeSceneChanged += OnNewSceneChange;
    }

    private void UnsubscribeFromEvents()
    {
        EventService.OnPlayerEnteredWorldRotationTrigger -= OnPlayerEnteredWorldRotationTrigger;
        EventService.OnCameraFinishedRotation -= SwitchState<GamePlayingState>;
        EventService.OnPlayerCollectedSeed -= UpdateSeeds;
        EventService.OnPlayerFinishedEnteringLevel -= SwitchState<GamePlayingState>;
        SceneManager.activeSceneChanged -= OnNewSceneChange;
    }

    private void OnNewSceneChange(Scene currentScene, Scene nextScene)
    {
        Player = FindAnyObjectByType<PlayerController>();
        if (nextScene.buildIndex != 0 || nextScene.buildIndex == SceneManager.sceneCountInBuildSettings - 1)
            SwitchState<GamePlayingState>();
        else
        {
            NumberOfSeedsCollected = 0;
            SwitchState<GamePausedState>();
        }
        
        UIService = FindAnyObjectByType<UIService>();
        UIService.UpdateSeedsCollected(NumberOfSeedsCollected);
        PlayerPrefs.SetInt("NumberOfSeedsCollected", NumberOfSeedsCollected);
    }
    private void InitializeServices()
    {
        EventService = new EventService();
    }
    
    private void CreateStates()
    {
        states = new List<ManagerStates>();
        states.Add(new GamePausedState(this, "", ""));
        states.Add(new GamePlayingState(this, "", ""));
        states.Add(new GameRotationState(this, "", ""));
    }

    private void OnPlayerEnteredWorldRotationTrigger(RotationDirection rotationDirection)
    {
        SwitchState<GameRotationState>();
    }

    private void UpdateSeeds()
    {
        NumberOfSeedsCollected++;
        UIService.UpdateSeedsCollected(NumberOfSeedsCollected);
    }
}
