using System;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraMove : MonoBehaviour
{
    [FormerlySerializedAs("target")] [SerializeField] private GameObject _target;
    [FormerlySerializedAs("cameraPanRate")] [SerializeField] private float _cameraPanRate;
    [FormerlySerializedAs("offsetMagnitude")] [SerializeField] private float _offsetMagnitude;
    [FormerlySerializedAs("followSpeed")] [SerializeField] private float _followSpeed;

    private Vector3 _startingRotationVector = Vector3.zero;
    private bool _cameraMovementDone = false;
    private float _positionOnUnitCircle;
    private float _finalPosOnRotation;
    private bool _rotateAroundCorner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (_rotateAroundCorner)
            RotateAround();
        else
        {
            Vector3 camPosVector = new Vector3(_target.transform.position.x, _target.transform.position.y,
                _target.transform.position.z * _offsetMagnitude);
            transform.position = Vector3.Lerp(transform.position, camPosVector, _followSpeed);
        }
    }

    private void RotateAround()
    {
        _positionOnUnitCircle += _cameraPanRate * Time.deltaTime;
        Vector3 currentRotPosition = new Vector3(Mathf.Cos(_positionOnUnitCircle), 0f, Mathf.Sin(_positionOnUnitCircle)) * 3f;
        transform.position += currentRotPosition * Time.deltaTime;
        Debug.Log("Current Pos: " + _positionOnUnitCircle + " Final pos: " + _finalPosOnRotation);
        transform.LookAt(_target.transform.position);
        if (_finalPosOnRotation - _positionOnUnitCircle <= 0f)
            _rotateAroundCorner = false;
    }

    public void StartRotateAround()
    {
        _startingRotationVector = transform.position - _target.transform.position;
        _startingRotationVector.Normalize();
        Vector3 startVector = transform.position + _startingRotationVector;
        _positionOnUnitCircle = Mathf.Atan2(startVector.y, startVector.x);
        _finalPosOnRotation = _positionOnUnitCircle + Mathf.PI / 2f;
        Debug.Log("Starting pos: " + _positionOnUnitCircle + " Final Pos: " + _finalPosOnRotation);
        _rotateAroundCorner = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if(_startingRotationVector != Vector3.zero)
            Gizmos.DrawLine(_target.transform.position, _target.transform.position + _startingRotationVector);
    }
}