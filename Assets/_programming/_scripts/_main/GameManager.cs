using System;
using System.Collections.Generic;
using UnityEngine;
using Jesper.GeneralStateMachine;
using Jesper.PlayerStateMachine;

public class GameManager : StateMachine
{
    private static GameManager instance;

    public static GameManager Instance
    {
        get { return instance; }
    }
    
    public EventService EventService;
    public PlayerController Player;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);
        
        InitializeServices();
        CreateStates();
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
        EventService.OnPlayerEnteredWorldRotationTrigger += OnPlayerEnteredWorldRotationTrigger;
        EventService.OnCameraFinishedRotation += SwitchState<GamePlayingState>;
    }

    private void UnsubscribeFromEvents()
    {
        EventService.OnPlayerEnteredWorldRotationTrigger -= OnPlayerEnteredWorldRotationTrigger;
        EventService.OnCameraFinishedRotation -= SwitchState<GamePlayingState>;
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
    }

    private void OnPlayerEnteredWorldRotationTrigger(RotationDirection rotationDirection)
    {
        SwitchState<GamePausedState>();
    }
}
