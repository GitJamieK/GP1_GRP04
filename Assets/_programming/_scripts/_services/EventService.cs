using UnityEngine;

public class EventService
{
    public delegate void OnPlayerEnteredWorldRotationTriggerDelegate(RotationDirection rotationDirection);
    public delegate void OnCameraFinishedRotationDelegate();
    public delegate void OnPlayerToggledPlatformTriggerDelegate();
    
    public event OnPlayerEnteredWorldRotationTriggerDelegate OnPlayerEnteredWorldRotationTrigger;
    public event OnCameraFinishedRotationDelegate OnCameraFinishedRotation;
    public event OnPlayerToggledPlatformTriggerDelegate OnPlayerToggledPlatformTrigger;
    
    public void InvokePlayerEnteredWorldRotationTriggerEvent(RotationDirection rotationDirection) => OnPlayerEnteredWorldRotationTrigger?.Invoke(rotationDirection);
    public void InvokeCameraFinishedRotationEvent() => OnCameraFinishedRotation?.Invoke();
    public void InvokePlayerToggledPlatformTriggerEvent() => OnPlayerToggledPlatformTrigger?.Invoke();
}
