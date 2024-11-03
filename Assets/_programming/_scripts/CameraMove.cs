using System;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraMove : MonoBehaviour
{
    [FormerlySerializedAs("target")] [SerializeField] private GameObject _target;
    [FormerlySerializedAs("cameraPanRate")] [SerializeField] private float _cameraPanRate;
    [FormerlySerializedAs("offsetMagnitude")] [SerializeField] private float _offsetMagnitude;
    [FormerlySerializedAs("followSpeed")] [SerializeField] private float _followSpeed;
    [SerializeField] private float _rotationRadius;
    
    private Vector3 _offsetVector;
    private float _positionOnUnitCircle;
    private float _finalPosOnRotation;
    private bool _rotateAroundCorner;
    private RotationDirection _rotationDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _offsetVector = new Vector3(0f, 0f, -_offsetMagnitude);
        GameManager.Instance.EventService.OnPlayerEnteredWorldRotationTrigger += StartRotateAround;
    }

    private void OnDestroy()
    {
        GameManager.Instance.EventService.OnPlayerEnteredWorldRotationTrigger -= StartRotateAround;
    }

    // Update is called once per frame
    void Update()
    {
        if (_rotateAroundCorner)
            RotateAround();
        else
        {
            Vector3 camPosVector = _target.transform.position + _offsetVector;
            transform.position = Vector3.Lerp(transform.position, camPosVector, _followSpeed);
        }
    }

    private void RotateAround()
    {
        _positionOnUnitCircle += _cameraPanRate * Time.deltaTime;
        Vector3 currentRotPosition = new Vector3(Mathf.Cos(_positionOnUnitCircle), 0f, Mathf.Sin(_positionOnUnitCircle)) * _rotationRadius;
        transform.position += currentRotPosition * Time.deltaTime;
        transform.LookAt(_target.transform.position);
            if (_finalPosOnRotation - _positionOnUnitCircle <= 0f)
            {
                float dotProductOnXAxis = Vector3.Dot(_target.transform.forward, Vector3.right);
                float dotProductOnZAxis = Vector3.Dot(_target.transform.forward, Vector3.forward);
                
                if (dotProductOnXAxis > 0.01f || dotProductOnXAxis < -0.01f)
                    _offsetVector = new Vector3(0f, 0f, GetOffsetMagnitudeAlongZAxis(dotProductOnXAxis));
                else if (dotProductOnZAxis > 0.01f || dotProductOnZAxis < -0.01f)
                    _offsetVector = new Vector3(GetOffsetMagnitudeAlongXAxis(dotProductOnZAxis), 0f, 0f);
                _rotateAroundCorner = false;   
            }
    }

    private float GetOffsetMagnitudeAlongZAxis(float dotProductOnXAxis)
    {
        if (dotProductOnXAxis < 0f)
        {
            if(_offsetMagnitude < 0f)
                _offsetMagnitude *= -1f;
            transform.forward = -Vector3.forward;
        }
        else
        {
            if(_offsetMagnitude > 0f)
                _offsetMagnitude *= -1f;
            transform.forward = Vector3.forward;   
        }
        
        return _offsetMagnitude;
    }

    private float GetOffsetMagnitudeAlongXAxis(float dotProductOnZAxis)
    {
        if (dotProductOnZAxis > 0f)
        {
            if(_offsetMagnitude < 0f)
                _offsetMagnitude *= -1f;
            transform.forward = -Vector3.right;   
        }

        else
        {
            if(_offsetMagnitude > 0f)
                _offsetMagnitude *= -1f;
            transform.forward = Vector3.right;
        }
        
        return _offsetMagnitude;
    }

    private void StartRotateAround(RotationDirection rotationDirection)
    {
        _rotationDirection = rotationDirection;
        _positionOnUnitCircle = Mathf.Atan2(transform.right.z, transform.right.x); //YOU ARE SETTING THE AXIS OF THE CIRCLE TO BE X-Z AXIS
        _finalPosOnRotation = _positionOnUnitCircle + Mathf.PI / 2f;
        _rotateAroundCorner = true;
    }
}