using System;
using UnityEngine;

public class CameraMoveTrigger : MonoBehaviour
{
    private bool _playerIsGoingUp;
    private bool _playerTriggeredCamMovement;
    private PlayerController _newPlayer;
    private bool _collidedWithPlayer;
    private readonly float _playerReachThreshold = 0.3f;
    private readonly float _digitsForPositionDecimal = 10f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerController player) && !_collidedWithPlayer)
        {
            _newPlayer = player;
            _playerIsGoingUp = !_playerIsGoingUp;
            _collidedWithPlayer = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (_newPlayer == null)
            return;
        
        if (PosCheck(_newPlayer.transform) && !_playerTriggeredCamMovement)
        {
            _playerTriggeredCamMovement = true;
            Vector3 newPlayerPos = new Vector3(transform.position.x, _newPlayer.transform.position.y, transform.position.z);
            _newPlayer.transform.position = newPlayerPos;
            RotationDirection rotationDirection =
                _playerIsGoingUp ? RotationDirection.FORWARD : RotationDirection.REVERSE;
            GameManager.Instance.EventService.InvokePlayerEnteredWorldRotationTriggerEvent(rotationDirection);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_newPlayer)
            _newPlayer = null;
        _playerTriggeredCamMovement = false;
        _collidedWithPlayer = false;
    }

    private bool PosCheck(Transform playerTransform)
    {
        float playerX = RoundPosition(playerTransform.position.x);
        float playerZ = RoundPosition(playerTransform.position.z);
        float myX = RoundPosition(transform.position.x);
        float myZ = RoundPosition(transform.position.z);
        return Mathf.Abs(myX) - Mathf.Abs(playerX) <= _playerReachThreshold && Mathf.Abs(myZ) - Mathf.Abs(playerZ) <= _playerReachThreshold; 
    }
    
    private float RoundPosition(float position) => Mathf.Round(position * _digitsForPositionDecimal) / _digitsForPositionDecimal;
}
