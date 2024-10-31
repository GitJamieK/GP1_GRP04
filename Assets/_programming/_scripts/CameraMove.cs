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
    private Vector3 offsetVector;
    private bool _cameraMovementDone = false;
    private float _positionOnUnitCircle;
    private float _finalPosOnRotation;
    private bool _rotateAroundCorner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offsetVector = new Vector3(1f, 1f, _offsetMagnitude);
        CameraMoveTrigger.OnPlayerEnteredTriggerEvent += StartRotateAround;
    }

    private void OnDestroy()
    {
        CameraMoveTrigger.OnPlayerEnteredTriggerEvent -= StartRotateAround;
    }

    // Update is called once per frame
    void Update()
    {
        if (_rotateAroundCorner)
            RotateAround();
        else
        {
            Vector3 camPosVector = Vector3.Scale(_target.transform.position, offsetVector);
            transform.position = Vector3.Lerp(transform.position, camPosVector, _followSpeed);
        }
        
        if(Vector3.Angle(transform.forward, Vector3.forward) <= 180f)
            Debug.Log("On Positive X-axis");
    }

    private void RotateAround()
    {
        _positionOnUnitCircle += _cameraPanRate * Time.deltaTime;
        Vector3 currentRotPosition = new Vector3(Mathf.Cos(_positionOnUnitCircle), 0f, Mathf.Sin(_positionOnUnitCircle)) * 3f;
        transform.position += currentRotPosition * Time.deltaTime;
        transform.LookAt(_target.transform.position);
        if (_finalPosOnRotation - _positionOnUnitCircle <= 0f)
        {
            offsetVector = new Vector3(_offsetMagnitude, 1f, 1f);
            _rotateAroundCorner = false;   
        }
    }

    public void StartRotateAround()
    {
        _startingRotationVector = transform.position - _target.transform.position;
        _startingRotationVector.Normalize();
        Vector3 startVector = transform.position + _startingRotationVector;
        _positionOnUnitCircle = Mathf.Atan2(startVector.z, startVector.x);
        _finalPosOnRotation = _positionOnUnitCircle + Mathf.PI / 2f;
        _rotateAroundCorner = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if(_startingRotationVector != Vector3.zero)
            Gizmos.DrawLine(_target.transform.position, _target.transform.position + _startingRotationVector);
    }
}