using System;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CameraScriptableObject _cameraData;

    private PlayerController _target;
    private float _rotationRadius;
    private float _rotationSpeed;
    private float _yOffset;
    private float _rotationOffsetAlongXAxis;

    private Vector3 _offsetVector;
    private float _positionOnUnitCircle;
    private float _finalPosOnRotation;
    private bool _rotateAroundCorner;
    private float _cameraRotationDirection;

    private static float _zOffset = 5f;
    private readonly float _digitsForRotationDecimal = 1000f;


    private void Awake()
    {
        InitData();
    }

    private void InitData()
    {
        _target = _cameraData.Target;
        _rotationRadius = _cameraData.RotationRadius;
        _rotationSpeed = _cameraData.RotationSpeed;
        _yOffset = _cameraData.Y_Offset;
        _rotationOffsetAlongXAxis = _cameraData.RotationOffsetAlongXAxis;
    }

    private void Start()
    {
        _target = FindAnyObjectByType<PlayerController>();
        _offsetVector = new Vector3(0f, _yOffset, -_zOffset);
        GetCamOffsetFromPlayer();
        GameManager.Instance.EventService.OnPlayerEnteredWorldRotationTrigger += StartRotateAround;
    }

    private void OnDestroy()
    {
        GameManager.Instance.EventService.OnPlayerEnteredWorldRotationTrigger -= StartRotateAround;
    }

    void Update()
    {
        if (_rotateAroundCorner)
            RotateAround();
        else
        {
            Vector3 camPosVector = _target.transform.position + _offsetVector;
            transform.position = camPosVector;
        }
    }

    private void RotateAround()
    {
        float finalPosCheck;
        _positionOnUnitCircle =
            Mathf.Round(_positionOnUnitCircle * _digitsForRotationDecimal) / _digitsForRotationDecimal;
        _finalPosOnRotation = Mathf.Round(_finalPosOnRotation * _digitsForRotationDecimal) / _digitsForRotationDecimal;

        _positionOnUnitCircle += Time.deltaTime * _rotationSpeed * Mathf.Sign(_cameraRotationDirection);
        Vector3 currentRotPosition =
            new Vector3(Mathf.Cos(_positionOnUnitCircle), 0f, Mathf.Sin(_positionOnUnitCircle)) * _rotationRadius;
        transform.position += currentRotPosition * Time.deltaTime;

        Vector3 camPositionInWorldSpaceWithHeight = transform.position;
        camPositionInWorldSpaceWithHeight.y = _target.transform.position.y + _yOffset;

        transform.position = camPositionInWorldSpaceWithHeight;
        transform.LookAt(_target.gameObject.transform.position);
        transform.eulerAngles =
            new Vector3(_rotationOffsetAlongXAxis, transform.eulerAngles.y, transform.eulerAngles.z);

        if (_finalPosOnRotation == 0f)
            finalPosCheck = _positionOnUnitCircle;
        else
            finalPosCheck = Mathf.Abs(_finalPosOnRotation) - Mathf.Abs(_positionOnUnitCircle);

        if (finalPosCheck <= 0f)
        {
            GetCamOffsetFromPlayer();
            GameManager.Instance.EventService.InvokeCameraFinishedRotationEvent();
            _rotateAroundCorner = false;
        }
    }

    private float GetOffsetMagnitudeAlongZAxis(float dotProductOnXAxis)
    {
        if (dotProductOnXAxis > 0f)
        {
            if (_target.CurrentRotationDirection == RotationDirection.FORWARD)
            {
                _zOffset = _zOffset > 0f ? _zOffset * -1f : _zOffset;
                transform.forward = Vector3.forward;
            }
            else
            {
                _zOffset = _zOffset < 0f ? _zOffset * -1f : _zOffset;
                transform.forward = -Vector3.forward;
            }
        }
        else
        {
            if (_target.CurrentRotationDirection == RotationDirection.FORWARD)
            {
                _zOffset = _zOffset < 0f ? _zOffset * -1f : _zOffset;
                transform.forward = -Vector3.forward;
            }
            else
            {
                _zOffset = _zOffset > 0f ? _zOffset * -1f : _zOffset;
                transform.forward = Vector3.forward;
            }
        }

        return _zOffset;
    }

    private float GetOffsetMagnitudeAlongXAxis(float dotProductOnZAxis)
    {
        if (dotProductOnZAxis > 0f)
        {
            if (_target.CurrentRotationDirection == RotationDirection.FORWARD)
            {
                _zOffset = _zOffset < 0f ? _zOffset * -1f : _zOffset;
                transform.forward = -Vector3.right;
            }
            else
            {
                _zOffset = _zOffset > 0f ? _zOffset * -1f : _zOffset;
                transform.forward = Vector3.right;
            }
        }

        else
        {
            if (_target.CurrentRotationDirection == RotationDirection.FORWARD)
            {
                _zOffset = _zOffset > 0f ? _zOffset * -1f : _zOffset;
                transform.forward = Vector3.right;
            }
            else
            {
                _zOffset = _zOffset < 0f ? _zOffset * -1f : _zOffset;
                transform.forward = -Vector3.right;
            }
        }

        return _zOffset;
    }

    private void GetCamOffsetFromPlayer()
    {
        float dotProductOnXAxis = Vector3.Dot(_target.gameObject.transform.forward, Vector3.right);
        float dotProductOnZAxis = Vector3.Dot(_target.gameObject.transform.forward, Vector3.forward);

        if (dotProductOnXAxis > 0.01f || dotProductOnXAxis < -0.01f)
            _offsetVector = new Vector3(0f, _yOffset, GetOffsetMagnitudeAlongZAxis(dotProductOnXAxis));
        else if (dotProductOnZAxis > 0.01f || dotProductOnZAxis < -0.01f)
            _offsetVector = new Vector3(GetOffsetMagnitudeAlongXAxis(dotProductOnZAxis), _yOffset, 0f);

        transform.eulerAngles =
            new Vector3(_rotationOffsetAlongXAxis, transform.eulerAngles.y, transform.eulerAngles.z);
    }

    private void StartRotateAround(RotationDirection rotationDirection)
    {
        if (rotationDirection == RotationDirection.FORWARD)
        {
            _cameraRotationDirection = 1f;
            _positionOnUnitCircle = Mathf.Atan2(transform.right.z, transform.right.x);
            _finalPosOnRotation = _positionOnUnitCircle + Mathf.PI / 2f;
        }
        else
        {
            _cameraRotationDirection = -1f;
            _positionOnUnitCircle =
                Mathf.Atan2(-transform.right.z,
                    -transform.right.x); //YOU ARE SETTING THE AXIS OF THE CIRCLE TO BE X-Z AXIS
            _finalPosOnRotation = _positionOnUnitCircle - Mathf.PI / 2f;
        }

        _rotateAroundCorner = true;
    }
}