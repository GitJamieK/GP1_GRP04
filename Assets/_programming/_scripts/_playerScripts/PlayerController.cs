using System;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;

    private bool _isRotating;
    private float _currentMoveSpeed;
    private float _movementInput;
    private Quaternion _targetRotation;
    private bool _rotationChanged;
    private Vector3 _currentPositiveAxis;
    private Vector3 _currentNegativeAxis;

    public bool PlayerIsMovingInReverseDirection;

    void Start()
    {
        GameManager.Instance.EventService.OnPlayerEnteredWorldRotationTrigger += InitiateRotation;
        _currentMoveSpeed = _moveSpeed;
        RefreshCurrentAxes();
    }

    private void RefreshCurrentAxes()
    {
        float dotProductWithZAxis = Vector3.Dot(transform.forward, Vector3.forward);
        float dotProductWithXAxis = Vector3.Dot(transform.forward, Vector3.right);
        
        if (dotProductWithZAxis > 0.01f || dotProductWithZAxis < -0.01f)
        {
            _currentPositiveAxis = dotProductWithZAxis > 0f ? Vector3.forward : Vector3.back;
            _currentNegativeAxis = dotProductWithZAxis > 0f ? Vector3.back : Vector3.forward;
        }

        else if(dotProductWithXAxis > 0.01f || dotProductWithXAxis < -0.01f)
        {
            _currentPositiveAxis = dotProductWithXAxis > 0f ? Vector3.right : Vector3.left;
            _currentNegativeAxis = dotProductWithXAxis > 0f ? Vector3.left : Vector3.right;
        }
    }
    private void OnDestroy()
    {
        GameManager.Instance.EventService.OnPlayerEnteredWorldRotationTrigger -= InitiateRotation;
    }
    
    void Update()
    {
        if (_isRotating)
        {
            RotatePlayer();
            return;
        }
        _movementInput = Input.GetKey(KeyCode.Space) ? -1f : 1f;
        UpdateRotation();
        UpdateMovement();
    }

    private void UpdateMovement()
    {
        PlayerIsMovingInReverseDirection = _movementInput < 0f;
        transform.position += _currentMoveSpeed * Time.deltaTime * transform.forward;
    }

    private void UpdateRotation()
    {
        transform.forward = _movementInput > 0f ? _currentPositiveAxis : _currentNegativeAxis;
    }

    private void InitiateRotation(RotationDirection rotationDirection)
    {
        float rotationAngle = rotationDirection == RotationDirection.FORWARD ? -90f : 90f;
        _isRotating = true;
        _currentMoveSpeed = 0f;
        Vector3 lookVector = Quaternion.AngleAxis(rotationAngle, Vector3.up) * transform.forward;
        _targetRotation = Quaternion.LookRotation(lookVector, Vector3.up);
    }

    private void RotatePlayer()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _targetRotation, 1f);
        _currentMoveSpeed = _moveSpeed;
        _isRotating = false;
        _rotationChanged = true;
        RefreshCurrentAxes();
    }
}