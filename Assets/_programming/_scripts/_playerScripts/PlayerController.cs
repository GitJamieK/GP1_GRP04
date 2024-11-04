using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour, IPausable
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;
    
    private bool _movementLocked;
    private float _currentMoveSpeed;
    private float _movementInput;
    private Quaternion _targetRotation;
    public Vector3 CurrentPositiveAxis { get; private set; }
    public Vector3 CurrentNegativeAxis { get; private set; }
    public RotationDirection CurrentRotationDirection { get; private set; }

    void Start()
    {
        SubscribeToEvents();
        _currentMoveSpeed = _moveSpeed;
        RefreshCurrentAxes();
    }
    
    private void OnDestroy()
    {
        UnsubscribeFromEvents();
    }
    
    private void SubscribeToEvents()
    {
        GameManager.Instance.EventService.OnPlayerEnteredWorldRotationTrigger += RotatePlayer;
    }

    private void UnsubscribeFromEvents()
    {
        GameManager.Instance.EventService.OnPlayerEnteredWorldRotationTrigger -= RotatePlayer;
    }

    public void Pause()
    {
        _currentMoveSpeed = 0f;
        _movementLocked = true;
    }

    public void Resume()
    {
        _currentMoveSpeed = _moveSpeed;
        _movementLocked = false;
    }

    private void RefreshCurrentAxes()
    {
        float dotProductWithZAxis = Vector3.Dot(transform.forward, Vector3.forward);
        float dotProductWithXAxis = Vector3.Dot(transform.forward, Vector3.right);
        
        if (dotProductWithZAxis > 0.01f || dotProductWithZAxis < -0.01f)
        {
            CurrentPositiveAxis = dotProductWithZAxis > 0f ? Vector3.forward : Vector3.back;
            CurrentNegativeAxis = dotProductWithZAxis > 0f ? Vector3.back : Vector3.forward;
        }

        else if(dotProductWithXAxis > 0.01f || dotProductWithXAxis < -0.01f)
        {
            CurrentPositiveAxis = dotProductWithXAxis > 0f ? Vector3.right : Vector3.left;
            CurrentNegativeAxis = dotProductWithXAxis > 0f ? Vector3.left : Vector3.right;
        }
    }
    
    void Update()
    {
        if (_movementLocked)
            return;
        _movementInput = Input.GetKey(KeyCode.Space) ? -1f : 1f;
        
        UpdateRotation();
        UpdateMovement();
    }

    private void UpdateMovement()
    {
        transform.position += _currentMoveSpeed * Time.deltaTime * transform.forward;
    }

    private void UpdateRotation()
    {
        transform.forward = _movementInput > 0f ? CurrentPositiveAxis : CurrentNegativeAxis;
    }

    private void RotatePlayer(RotationDirection rotationDirection)
    {
        CurrentRotationDirection = rotationDirection;
        transform.forward = rotationDirection == RotationDirection.FORWARD ? -transform.right : transform.right;
        RefreshCurrentAxes();
        _movementLocked = true;
    }
}