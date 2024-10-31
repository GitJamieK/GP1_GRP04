using System;
using UnityEngine;

public class CameraMoveTrigger : MonoBehaviour
{
    [SerializeField] private CameraMove cam;
    public static Action OnPlayerEnteredTriggerEvent;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerController player))
        {
            OnPlayerEnteredTriggerEvent?.Invoke();  
        }
    }
}
