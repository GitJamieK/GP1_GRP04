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
    public AudioService AudioService;
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
        AudioService = FindAnyObjectByType<AudioService>();
        SwitchState<GamePausedState>();
        SubscribeToEvents();
        Instance.EventService.InvokeOnAmbientAudioPlay(AudioService.musicSounds[0].name);
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
        EventService.OnPlayerStartedOpeningDoor += SwitchState<GamePausedState>;
        EventService.OnAmbientAudioPlay += PlayAmbientAudio;
        EventService.OnSfxPlay += PlaySfxAudio;
        SceneManager.activeSceneChanged += OnNewSceneChange;
    }

    private void UnsubscribeFromEvents()
    {
        EventService.OnPlayerEnteredWorldRotationTrigger -= OnPlayerEnteredWorldRotationTrigger;
        EventService.OnCameraFinishedRotation -= SwitchState<GamePlayingState>;
        EventService.OnPlayerCollectedSeed -= UpdateSeeds;
        EventService.OnPlayerFinishedEnteringLevel -= SwitchState<GamePlayingState>;
        EventService.OnPlayerStartedOpeningDoor -= SwitchState<GamePausedState>;
        EventService.OnAmbientAudioPlay -= PlayAmbientAudio;
        EventService.OnSfxPlay -= PlaySfxAudio;
        SceneManager.activeSceneChanged -= OnNewSceneChange;
    }

    private void OnNewSceneChange(Scene currentScene, Scene nextScene)
    {
        if (nextScene.buildIndex < (int)GameScenes.LEVEL_1 || nextScene.buildIndex == (int)GameScenes.OUTRO || nextScene.buildIndex == (int)GameScenes.THANK_YOU)
        {
            SwitchState<GameSuspendedState>();
            if(nextScene.buildIndex == (int)GameScenes.MAIN_MENU)
                NumberOfSeedsCollected = 0;
            return;
        }

        Player = FindAnyObjectByType<PlayerController>();
        if (nextScene.buildIndex != 0 || nextScene.buildIndex == SceneManager.sceneCountInBuildSettings - 1)
            SwitchState<GamePausedState>();
        else
        {
            NumberOfSeedsCollected = 0;
            SwitchState<GamePausedState>();
        }
        
        
        PlayerPrefs.SetInt("NumberOfSeedsCollected", NumberOfSeedsCollected);
        UIService = FindAnyObjectByType<UIService>();
        UIService.UpdateSeedsCollected(NumberOfSeedsCollected);
        AudioService = FindAnyObjectByType<AudioService>();
        EventService.InvokeOnAmbientAudioPlay(AudioService.musicSounds[0].name);
        
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
        states.Add(new GameSuspendedState(this, "", ""));
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

    private void PlayAmbientAudio(string ambientAudio) => AudioService.PlayMusic(ambientAudio);

    private void PlaySfxAudio(string SFXAudio) => AudioService.PlaySFX(SFXAudio);
}
