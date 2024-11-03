using UnityEngine;

public class EventService
{
    public delegate void OnPlayerEnteredWorldRotationTriggerDelegate(RotationDirection rotationDirection);
    public delegate void OnCameraFinishedRotationDelegate();
    
    public event OnPlayerEnteredWorldRotationTriggerDelegate OnPlayerEnteredWorldRotationTrigger;
    public event OnCameraFinishedRotationDelegate OnCameraFinishedRotation;
    
    public void InvokePlayerEnteredWorldRotationTriggerEvent(RotationDirection rotationDirection) => OnPlayerEnteredWorldRotationTrigger?.Invoke(rotationDirection);
    public void InvokeCameraFinishedRotationEvent() => OnCameraFinishedRotation?.Invoke();
}
