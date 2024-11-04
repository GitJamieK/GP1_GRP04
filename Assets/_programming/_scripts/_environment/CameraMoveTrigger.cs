using System;
using UnityEngine;

public class CameraMoveTrigger : MonoBehaviour
{
    private bool _playerIsGoingUp = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerController player))
        {
            _playerIsGoingUp = !_playerIsGoingUp;
            RotationDirection rotationDirection =
                _playerIsGoingUp ? RotationDirection.FORWARD : RotationDirection.REVERSE;
            GameManager.Instance.EventService.InvokePlayerEnteredWorldRotationTriggerEvent(rotationDirection);
        }
    }
}
