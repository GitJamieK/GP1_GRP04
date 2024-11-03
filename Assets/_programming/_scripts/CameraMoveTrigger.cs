using System;
using UnityEngine;

public class CameraMoveTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerController player))
        {
            RotationDirection rotationDirection = player.PlayerIsMovingInReverseDirection
                ? RotationDirection.REVERSE
                : RotationDirection.FORWARD;
            GameManager.Instance.EventService.InvokeOnPlayerEnteredWorldRotationTriggerEvent(rotationDirection);
        }
    }
}
