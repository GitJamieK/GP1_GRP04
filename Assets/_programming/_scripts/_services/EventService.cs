using UnityEngine;

public class EventService
{
    public delegate void OnPlayerEnteredWorldRotationTriggerDelegate(RotationDirection rotationDirection);
    
    
    
    public event OnPlayerEnteredWorldRotationTriggerDelegate OnPlayerEnteredWorldRotationTrigger;
    
    
    
    public void InvokeOnPlayerEnteredWorldRotationTriggerEvent(RotationDirection rotationDirection) => OnPlayerEnteredWorldRotationTrigger?.Invoke(rotationDirection);
}
