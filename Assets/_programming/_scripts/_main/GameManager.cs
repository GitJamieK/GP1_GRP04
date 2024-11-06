using System;
using System.Collections.Generic;
using UnityEngine;
using Jesper.GeneralStateMachine;
using Jesper.PlayerStateMachine;
using UnityEngine.SceneManagement;

public class GameManager : StateMachine
{
    private static GameManager instance;

    public static GameManager Instance
    {
        get { return instance; }
    }
    
    public EventService EventService;
    public PlayerController Player;
    public int NumberOfAcornsCollected;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);
        
        DontDestroyOnLoad(this);
        InitializeServices();
        CreateStates();
    }

    private void Start()
    {
        SubscribeToEvents();
        SwitchState<GamePlayingState>();
    }

    private void OnDestroy()
    {
        UnsubscribeFromEvents();
    }
    private void SubscribeToEvents()
    {
        EventService.OnPlayerEnteredWorldRotationTrigger += OnPlayerEnteredWorldRotationTrigger;
        EventService.OnCameraFinishedRotation += SwitchState<GamePlayingState>;
        EventService.OnPlayerCollectedAcorn += UpdateAcorns;
        SceneManager.activeSceneChanged += OnNewSceneChange;
    }

    private void UnsubscribeFromEvents()
    {
        EventService.OnPlayerEnteredWorldRotationTrigger -= OnPlayerEnteredWorldRotationTrigger;
        EventService.OnCameraFinishedRotation -= SwitchState<GamePlayingState>;
        EventService.OnPlayerCollectedAcorn -= UpdateAcorns;
        SceneManager.activeSceneChanged -= OnNewSceneChange;
    }

    private void OnNewSceneChange(Scene currentScene, Scene nextScene)
    {
        Player = FindAnyObjectByType<PlayerController>();
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

    private void UpdateAcorns() => NumberOfAcornsCollected++;
}
