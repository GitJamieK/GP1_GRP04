using UnityEngine;

public class EventService
{
    public delegate void ZeroParameterDelegate();
    public delegate void SingleParameterDelegate<T>(T arg1);
    
    
    public event SingleParameterDelegate<RotationDirection> OnPlayerEnteredWorldRotationTrigger;
    public event ZeroParameterDelegate OnCameraFinishedRotation;
    public event ZeroParameterDelegate OnPlayerToggledPlatformTrigger;
    public event ZeroParameterDelegate OnPlayerCollectedSeed;
    public event ZeroParameterDelegate OnPlayerFinishedEnteringLevel;
    public event ZeroParameterDelegate OnPlayerReachedFinishDoor;
    public event ZeroParameterDelegate OnPlayerStartedOpeningDoor;

    public event ZeroParameterDelegate InitiateNextSceneLoad;
    
    public void InvokePlayerEnteredWorldRotationTriggerEvent(RotationDirection rotationDirection) => OnPlayerEnteredWorldRotationTrigger?.Invoke(rotationDirection);
    public void InvokeCameraFinishedRotationEvent() => OnCameraFinishedRotation?.Invoke();
    public void InvokePlayerToggledPlatformTriggerEvent() => OnPlayerToggledPlatformTrigger?.Invoke();
    public void InvokePlayerCollectedSeedEvent() => OnPlayerCollectedSeed?.Invoke();
    public void InvokePlayerFinishedEnteringLevelEvent() => OnPlayerFinishedEnteringLevel?.Invoke();
    public void InvokePlayerReachedFinishDoorEvent() => OnPlayerReachedFinishDoor?.Invoke();
    public void InvokePlayerStartedOpeningDoorEvent() => OnPlayerStartedOpeningDoor?.Invoke();
    public void InvokeInitiateNextSceneLoadEvent() => InitiateNextSceneLoad?.Invoke();
}
