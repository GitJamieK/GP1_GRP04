using System;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [FormerlySerializedAs("moveSpeed")] [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;

    private bool _isRotating;
    private float _currentMoveSpeed;
    private Quaternion _targetRotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CameraMoveTrigger.OnPlayerEnteredTriggerEvent += InitateRotation;
        _currentMoveSpeed = _moveSpeed;
    }

    private void OnDestroy()
    {
        CameraMoveTrigger.OnPlayerEnteredTriggerEvent -= InitateRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(_isRotating)
            RotatePlayer();
        Vector3 movementVector = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.position += _currentMoveSpeed * Time.deltaTime * movementVector;
    }

    private void InitateRotation()
    {
        _isRotating = true;
        _currentMoveSpeed = 0f;
        Vector3 lookVector = Quaternion.AngleAxis(-90f, Vector3.up) * transform.forward;
        _targetRotation = Quaternion.LookRotation(lookVector, Vector3.up);
    }
    private void RotatePlayer()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _targetRotation, Mathf.Min(_rotationSpeed * Time.deltaTime, 1f));
        if(transform.rotation == _targetRotation)
            _isRotating = false;
    }
}
